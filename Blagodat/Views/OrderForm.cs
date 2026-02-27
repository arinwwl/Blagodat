using Blagodat.Data;
using Blagodat.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Blagodat.Views
{
    public partial class OrderForm : Form
    {
        private BlagodatContext _context;
        private Order _currentOrder;
        private List<Service> _availableServices;
        private List<OrderService> _selectedServices;

        public Order CurrentOrder => _currentOrder;

        public OrderForm(Order order)
        {
            InitializeComponent();
            _context = new BlagodatContext();
            _currentOrder = order;
            _selectedServices = new List<OrderService>();

            this.Text = _currentOrder.Id == 0 ? "Создание заказа" : "Редактирование заказа";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

          
            btnSave.BackColor = Color.FromArgb(73, 140, 81);
            btnSave.ForeColor = Color.White;

            SetComicSansFont(this);

            SetupDataGridView();

            comboBoxStatus.Items.AddRange(new[] { "Новая", "В прокате", "Закрыта", "Отменена" });

            LoadData();
        }

        private void SetComicSansFont(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c.HasChildren)
                    SetComicSansFont(c);

                c.Font = new Font("Comic Sans MS", c.Font.Size);
            }
        }

        private void SetupDataGridView()
        {
            dataGridViewServices.AutoGenerateColumns = false;
            dataGridViewServices.Columns.Clear();

            dataGridViewServices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ServiceName",
                HeaderText = "Услуга",
                DataPropertyName = "ServiceName",
                Width = 200
            });

            dataGridViewServices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Кол-во",
                DataPropertyName = "Quantity",
                Width = 60
            });

            dataGridViewServices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "Цена",
                DataPropertyName = "Price",
                Width = 80
            });

            dataGridViewServices.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "",
                Text = "Удалить",
                UseColumnTextForButtonValue = true,
                Width = 60
            });
        }

        private void LoadData()
        {
    
            _availableServices = _context.Services.ToList();
            comboBoxServices.DataSource = _availableServices;
            comboBoxServices.DisplayMember = "Name";
            comboBoxServices.ValueMember = "Id";


            var clients = _context.Clients.ToList();
            comboBoxClient.DataSource = clients;
            comboBoxClient.DisplayMember = "LastName";
            comboBoxClient.ValueMember = "Id";

            if (_currentOrder.Id != 0)
            {
                textBoxOrderCode.Text = _currentOrder.OrderCode;
                dateTimePickerDate.Value = _currentOrder.CreatedDate;
                comboBoxClient.SelectedValue = _currentOrder.ClientCode;
                textBoxDuration.Text = _currentOrder.RentalDuration;
                comboBoxStatus.Text = _currentOrder.Status;

                _selectedServices = _context.OrderServices
                    .Where(os => os.OrderId == _currentOrder.Id)
                    .Include(os => os.Service)
                    .ToList();
                UpdateServicesGrid();
            }
            else
            {
               
                textBoxOrderCode.Text = GenerateOrderCode();
                textBoxOrderCode.ReadOnly = true;
                dateTimePickerDate.Value = DateTime.Now;
              
                comboBoxStatus.SelectedItem = "Новая";
            }
        }

        private string GenerateOrderCode()
        {
            return $"{DateTime.Now:yyyyMMddHHmmss}{new Random().Next(100, 999)}";
        }

        private void UpdateServicesGrid()
        {
            dataGridViewServices.Rows.Clear();

            foreach (var item in _selectedServices)
            {
                int rowIndex = dataGridViewServices.Rows.Add();
                dataGridViewServices.Rows[rowIndex].Cells["ServiceName"].Value = item.Service?.Name;
                dataGridViewServices.Rows[rowIndex].Cells["Quantity"].Value = item.Quantity;
                dataGridViewServices.Rows[rowIndex].Cells["Price"].Value = item.PriceAtTime?.ToString("F2");
                dataGridViewServices.Rows[rowIndex].Tag = item;
            }

            decimal total = _selectedServices.Sum(s => (s.Quantity * (s.PriceAtTime ?? 0)));
            labelTotal.Text = $"Итого: {total:F2} руб.";
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            if (comboBoxServices.SelectedItem == null)
            {
                MessageBox.Show("Выберите услугу");
                return;
            }

            var service = (Service)comboBoxServices.SelectedItem;
            int quantity = (int)numericUpDownQuantity.Value;

         
            var existing = _selectedServices.FirstOrDefault(s => s.ServiceId == service.Id);
            if (existing != null)
            {
                existing.Quantity += quantity;
            }
            else
            {
                _selectedServices.Add(new OrderService
                {
                    ServiceId = service.Id,
                    Service = service,
                    Quantity = quantity,
                    PriceAtTime = service.PricePerHour
                });
            }

            UpdateServicesGrid();
        }

        private void dataGridViewServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewServices.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                var item = dataGridViewServices.Rows[e.RowIndex].Tag as OrderService;
                if (item != null)
                {
                    _selectedServices.Remove(item);
                    UpdateServicesGrid();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

        
            _currentOrder.OrderCode = textBoxOrderCode.Text;
            _currentOrder.CreatedDate = dateTimePickerDate.Value.Date;
            _currentOrder.CreatedTime = dateTimePickerDate.Value.TimeOfDay;


            if (comboBoxClient.SelectedItem != null)
            {
                var client = (Client)comboBoxClient.SelectedItem;
                _currentOrder.ClientCode = client.Email; 
            }

            _currentOrder.RentalDuration = textBoxDuration.Text;
            _currentOrder.Status = comboBoxStatus.Text;

  
            _currentOrder.Services = string.Join(", ", _selectedServices.Select(s => s.ServiceId));

            if (_currentOrder.Id == 0)
            {
                _context.Orders.Add(_currentOrder);
            }
            _context.SaveChanges();

         
            var existingServices = _context.OrderServices.Where(os => os.OrderId == _currentOrder.Id).ToList();
            _context.OrderServices.RemoveRange(existingServices);

            foreach (var item in _selectedServices)
            {
                item.OrderId = _currentOrder.Id;
                _context.OrderServices.Add(item);
            }

            _context.SaveChanges();

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(textBoxOrderCode.Text))
            {
                MessageBox.Show("Введите код заказа");
                return false;
            }

            if (comboBoxClient.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента");
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxDuration.Text))
            {
                MessageBox.Show("Введите длительность проката");
                return false;
            }

            if (_selectedServices.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы одну услугу");
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}