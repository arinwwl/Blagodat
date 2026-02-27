using Blagodat.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Blagodat.Views.Controls
{
    public partial class OrderControl : UserControl
    {
        private Order _order;
        private MainForm _mainForm;

        public OrderControl(Order order, MainForm mainForm)
        {
            InitializeComponent();
            _order = order;
            _mainForm = mainForm;

            this.Size = new Size(280, 150);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Margin = new Padding(5);
            SetComicSansFont(this);

            DisplayOrder();
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

        private void DisplayOrder()
        {
            lblOrderCode.Text = $"Заказ: {_order.OrderCode}";
            string clientName = "Не указан";
            if (_order.Client != null)
            {
                clientName = $"{_order.Client.LastName} {_order.Client.FirstName}";
            }
            else if (!string.IsNullOrEmpty(_order.ClientCode))
            {
                clientName = $"Код: {_order.ClientCode}";
            }

            lblClient.Text = $"Клиент: {clientName}";
            lblDate.Text = $"Дата: {_order.CreatedDate:dd.MM.yyyy} {_order.CreatedTime}";
            lblStatus.Text = $"Статус: {_order.Status}";
            lblDuration.Text = $"Время: {_order.RentalDuration}";
            switch (_order.Status)
            {
                case "Новая":
                    this.BackColor = Color.FromArgb(255, 255, 200);
                    break;
                case "В прокате":
                    this.BackColor = Color.FromArgb(200, 255, 200);
                    break;
                case "Закрыта":
                    this.BackColor = Color.FromArgb(200, 200, 255);
                    break;
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            var detailsForm = new OrderDetailsForm(_order);
            detailsForm.ShowDialog();
        }

        private void btnPrintBarcode_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Штрих-код для заказа {_order.OrderCode} отправлен на печать",
                "Печать", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}