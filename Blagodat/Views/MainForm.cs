using Blagodat.Data;
using Blagodat.Model;
using Blagodat.Views.Controls;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Blagodat.Views
{
    public partial class MainForm : Form
    {
        private BlagodatContext _context;
        private List<Order> _orders;
        private string _userRole;

        public MainForm()
        {
            InitializeComponent();
            _context = new BlagodatContext();
            _userRole = LoginForm.CurrentUser?.Role ?? "Продавец";

            this.Text = "Главная - Горнолыжный комплекс Благодать";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

          
            panelTop.BackColor = Color.FromArgb(118, 227, 131);
            panelBottom.BackColor = Color.FromArgb(118, 227, 131);
            btnCreateOrder.BackColor = Color.FromArgb(73, 140, 81);
            btnCreateOrder.ForeColor = Color.White;
            btnReports.BackColor = Color.FromArgb(73, 140, 81);
            btnReports.ForeColor = Color.White;
            btnUsers.BackColor = Color.FromArgb(73, 140, 81);
            btnUsers.ForeColor = Color.White;
            btnMaterials.BackColor = Color.FromArgb(73, 140, 81);
            btnMaterials.ForeColor = Color.White;

            SetComicSansFont(this);

            cmbSort.Items.Clear();
            cmbSort.Items.AddRange(new[] { "По дате (новые)", "По дате (старые)", "По статусу", "По клиенту" });
            cmbSort.SelectedIndex = 0;

            if (LoginForm.CurrentUser != null)
            {
                labelWelcome.Text = $"Добро пожаловать, {LoginForm.CurrentUser.FullName} ({_userRole})";
            }
            else
            {
                labelWelcome.Text = "Добро пожаловать!";
            }

            this.Load += MainForm_Load;
            txtSearch.TextChanged += txtSearch_TextChanged;
            cmbSort.SelectedIndexChanged += cmbSort_SelectedIndexChanged;
            btnCreateOrder.Click += btnCreateOrder_Click;
            btnReports.Click += btnReports_Click;
            btnUsers.Click += btnUsers_Click;
            btnMaterials.Click += btnMaterials_Click;

            ConfigureUIBasedOnRole();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadOrders();
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

        private void ConfigureUIBasedOnRole()
        {
            switch (_userRole)
            {
                case "Продавец":
                    btnReports.Visible = false;
                    btnUsers.Visible = false;
                    btnMaterials.Visible = false;
                    break;
                case "Старший смены":
                    btnReports.Visible = false;
                    btnUsers.Visible = false;
                    break;
                case "Администратор":
                  
                    break;
            }
        }

        private void LoadOrders()
        {
            try
            {
               
                _orders = _context.Orders
                    .Include(o => o.OrderServices)
                        .ThenInclude(os => os.Service)
                    .ToList();

                var clients = _context.Clients.ToDictionary(c => c.Id.ToString());

               
                foreach (var order in _orders)
                {
                    if (!string.IsNullOrEmpty(order.ClientCode) &&
                        clients.TryGetValue(order.ClientCode, out var client))
                    {
                        order.Client = client;
                    }
                }

                UpdateOrdersList(_orders);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заказов: {ex.Message}\n\n{ex.StackTrace}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateOrdersList(List<Order> orders)
        {
            flowLayoutPanelOrders.Controls.Clear();

            foreach (var order in orders)
            {
                var orderControl = new OrderControl(order, this);
                flowLayoutPanelOrders.Controls.Add(orderControl);
            }

            labelOrdersCount.Text = $"Всего заказов: {orders.Count}";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_orders == null) return;

            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                UpdateOrdersList(_orders);
                return;
            }

            var filtered = _orders.Where(o =>
                o.OrderCode.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase) ||
                (o.Client != null && (o.Client.LastName.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase) ||
                                      o.Client.FirstName.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase))) ||
                o.Status.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            UpdateOrdersList(filtered);
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_orders == null) return;

            switch (cmbSort.SelectedIndex)
            {
                case 0: 
                    _orders = _orders.OrderByDescending(o => o.CreatedDate).ThenByDescending(o => o.CreatedTime).ToList();
                    break;
                case 1: 
                    _orders = _orders.OrderBy(o => o.CreatedDate).ThenBy(o => o.CreatedTime).ToList();
                    break;
                case 2: 
                    _orders = _orders.OrderBy(o => o.Status).ToList();
                    break;
                case 3: 
                    _orders = _orders.OrderBy(o => o.Client?.LastName ?? "").ThenBy(o => o.Client?.FirstName ?? "").ToList();
                    break;
            }
            UpdateOrdersList(_orders);
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            var orderForm = new OrderForm(new Order());
            if (orderForm.ShowDialog() == DialogResult.OK)
            {
                LoadOrders();
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            var reportsForm = new ReportsForm();
            reportsForm.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            //Раскомментируйте, когда создадите UsersForm
            //var usersForm = new UsersForm();
            //usersForm.ShowDialog();
            MessageBox.Show("Форма управления пользователями будет доступна в следующей версии",
                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMaterials_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Функционал управления материалами будет доступен в следующей версии",
                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context?.Dispose();
            Application.Exit();
        }
    }
}