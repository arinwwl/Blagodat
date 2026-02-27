using Blagodat.Data;
using Blagodat.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Blagodat.Views
{
    public partial class OrderDetailsForm : Form
    {
        private BlagodatContext _context;
        private Order _order;

        public OrderDetailsForm(Order order)
        {
            InitializeComponent();
            _context = new BlagodatContext();

            this.Text = "Детали заказа";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            SetComicSansFont(this);

            SetupDataGridView();

            _order = _context.Orders
                .Include(o => o.Client)
                .Include(o => o.OrderServices)
                    .ThenInclude(os => os.Service)
                .FirstOrDefault(o => o.Id == order.Id);

            LoadOrderDetails();
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
                Width = 200
            });

            dataGridViewServices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Кол-во",
                Width = 60
            });

            dataGridViewServices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "Цена",
                Width = 80
            });

            dataGridViewServices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Total",
                HeaderText = "Сумма",
                Width = 100
            });
        }

        private void LoadOrderDetails()
        {
            if (_order == null) return;

            textBoxOrderCode.Text = _order.OrderCode;
            textBoxDate.Text = $"{_order.CreatedDate:dd.MM.yyyy} {_order.CreatedTime}";
            textBoxClient.Text = _order.Client != null
                ? $"{_order.Client.LastName} {_order.Client.FirstName} {_order.Client.MiddleName}"
                : "Не указан";
            textBoxClientCode.Text = _order.ClientCode;
            textBoxStatus.Text = _order.Status;
            textBoxDuration.Text = _order.RentalDuration;
            textBoxClosedDate.Text = _order.ClosedDate?.ToString("dd.MM.yyyy") ?? "-";

            dataGridViewServices.Rows.Clear();
            decimal total = 0;

            foreach (var item in _order.OrderServices)
            {
                int rowIndex = dataGridViewServices.Rows.Add();
                dataGridViewServices.Rows[rowIndex].Cells["ServiceName"].Value = item.Service?.Name;
                dataGridViewServices.Rows[rowIndex].Cells["Quantity"].Value = item.Quantity;
                dataGridViewServices.Rows[rowIndex].Cells["Price"].Value = item.PriceAtTime?.ToString("F2");

                decimal itemTotal = item.Quantity * (item.PriceAtTime ?? 0);
                dataGridViewServices.Rows[rowIndex].Cells["Total"].Value = itemTotal.ToString("F2");

                total += itemTotal;
            }

            labelTotal.Text = $"Итого: {total:F2} руб.";
        }

        private void buttonPrintBarcode_Click(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count > 0)
            {
                int index = dataGridViewServices.SelectedRows[0].Index;
                var service = _order.OrderServices.ElementAt(index);

                for (int i = 0; i < service.Quantity; i++)
                {
                    string barcode = $"{_order.OrderCode}-{service.ServiceId}-{i + 1}";
                
                    MessageBox.Show($"Штрих-код {barcode} отправлен на печать",
                        "Печать", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Выберите услугу для печати штрих-кода",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}