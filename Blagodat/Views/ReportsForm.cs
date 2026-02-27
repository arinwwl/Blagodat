using Blagodat.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Blagodat.Views
{
    public partial class ReportsForm : Form
    {
        private BlagodatContext _context;

        public ReportsForm()
        {
            InitializeComponent();
            _context = new BlagodatContext();

            this.Text = "Отчеты";
            this.StartPosition = FormStartPosition.CenterParent;
            this.WindowState = FormWindowState.Maximized;

            // Настройка цветов
            btnGenerate.BackColor = Color.FromArgb(73, 140, 81);
            btnExport.BackColor = Color.FromArgb(73, 140, 81);
            btnPrint.BackColor = Color.FromArgb(73, 140, 81);

            // Шрифт
            SetComicSansFont(this);

            // Заполнение типов отчетов
            comboBoxReportType.Items.AddRange(new string[]
            {
                "Отчет по заказам за период",
                "Отчет по услугам",
                "Отчет по клиентам",
                "Отчет по доходу"
            });
            comboBoxReportType.SelectedIndex = 0;

            // Установка дат по умолчанию (текущий месяц)
            dateTimePickerFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateTimePickerTo.Value = DateTime.Now;

            // Настройка DataGridView
            SetupDataGridView();
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
            dataGridViewReport.AutoGenerateColumns = true;
            dataGridViewReport.ReadOnly = true;
            dataGridViewReport.AllowUserToAddRows = false;
            dataGridViewReport.AllowUserToDeleteRows = false;
            dataGridViewReport.RowHeadersVisible = false;
        }

        private void comboBoxReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void GenerateReport()
        {
            switch (comboBoxReportType.SelectedIndex)
            {
                case 0:
                    GenerateOrdersReport();
                    break;
                case 1:
                    GenerateServicesReport();
                    break;
                case 2:
                    GenerateClientsReport();
                    break;
                case 3:
                    GenerateIncomeReport();
                    break;
            }
        }

        private void GenerateOrdersReport()
        {
            var from = dateTimePickerFrom.Value.Date;
            var to = dateTimePickerTo.Value.Date.AddDays(1).AddSeconds(-1);

            var orders = _context.Orders
                .Where(o => o.CreatedDate >= from && o.CreatedDate <= to)
                .Include(o => o.Client)
                .Include(o => o.OrderServices)
                .ToList();

            var reportData = orders.Select(o => new
            {
                КодЗаказа = o.OrderCode,
                Дата = o.CreatedDate.ToShortDateString(),
                Время = o.CreatedTime.ToString(),
                Клиент = o.Client?.LastName ?? "Не указан",
                КоличествоУслуг = o.OrderServices.Sum(s => s.Quantity),
                Статус = o.Status,
                Длительность = o.RentalDuration
            }).ToList();

            dataGridViewReport.DataSource = reportData;
            labelTotal.Text = $"Всего заказов: {orders.Count}";
        }

        private void GenerateServicesReport()
        {
            var from = dateTimePickerFrom.Value.Date;
            var to = dateTimePickerTo.Value.Date.AddDays(1).AddSeconds(-1);

            var services = _context.OrderServices
                .Where(os => os.Order.CreatedDate >= from && os.Order.CreatedDate <= to)
                .Include(os => os.Service)
                .Include(os => os.Order)
                .GroupBy(os => os.ServiceId)
                .Select(g => new
                {
                    Услуга = g.First().Service.Name,
                    Количество = g.Sum(x => x.Quantity),
                    КоличествоЗаказов = g.Select(x => x.OrderId).Distinct().Count(),
                    Доход = g.Sum(x => x.Quantity * (x.PriceAtTime ?? 0))
                })
                .ToList();

            dataGridViewReport.DataSource = services;
            labelTotal.Text = $"Всего услуг: {services.Count}";
        }

        private void GenerateClientsReport()
        {
            var from = dateTimePickerFrom.Value.Date;
            var to = dateTimePickerTo.Value.Date.AddDays(1).AddSeconds(-1);

            var clients = _context.Clients
                .Select(c => new
                {
                    Клиент = $"{c.LastName} {c.FirstName} {c.MiddleName}",
                    Email = c.Email,
                    КоличествоЗаказов = c.Orders.Count(o => o.CreatedDate >= from && o.CreatedDate <= to),
                    Потрачено = c.Orders
                        .Where(o => o.CreatedDate >= from && o.CreatedDate <= to)
                        .SelectMany(o => o.OrderServices)
                        .Sum(os => os.Quantity * (os.PriceAtTime ?? 0))
                })
                .Where(c => c.КоличествоЗаказов > 0)
                .ToList();

            dataGridViewReport.DataSource = clients;
            labelTotal.Text = $"Всего клиентов: {clients.Count}";
        }

        private void GenerateIncomeReport()
        {
            var from = dateTimePickerFrom.Value.Date;
            var to = dateTimePickerTo.Value.Date.AddDays(1).AddSeconds(-1);

            var orders = _context.Orders
                .Where(o => o.CreatedDate >= from && o.CreatedDate <= to)
                .Include(o => o.OrderServices)
                .ToList();

            decimal totalIncome = orders
                .SelectMany(o => o.OrderServices)
                .Sum(os => os.Quantity * (os.PriceAtTime ?? 0));

            var byStatus = orders
                .GroupBy(o => o.Status)
                .Select(g => new { Статус = g.Key, Количество = g.Count() })
                .ToList();

            var reportData = new[]
            {
                new { Показатель = "Период", Значение = $"{from:dd.MM.yyyy} - {to:dd.MM.yyyy}" },
                new { Показатель = "Всего заказов", Значение = orders.Count.ToString() },
                new { Показатель = "Общий доход", Значение = $"{totalIncome:F2} руб." },
                new { Показатель = "Средний чек", Значение = orders.Count > 0 ? $"{(totalIncome / orders.Count):F2} руб." : "0" }
            }.Concat(byStatus.Select(s => new { Показатель = $"Заказов {s.Статус}", Значение = s.Количество.ToString() })).ToList();

            dataGridViewReport.DataSource = reportData;
            labelTotal.Text = $"Доход: {totalIncome:F2} руб.";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveDialog.FilterIndex = 1;
            saveDialog.RestoreDirectory = true;

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var writer = new StreamWriter(saveDialog.FileName))
                    {
                        // Заголовки
                        for (int i = 0; i < dataGridViewReport.Columns.Count; i++)
                        {
                            writer.Write(dataGridViewReport.Columns[i].HeaderText);
                            if (i < dataGridViewReport.Columns.Count - 1)
                                writer.Write(";");
                        }
                        writer.WriteLine();

                        // Данные
                        foreach (DataGridViewRow row in dataGridViewReport.Rows)
                        {
                            for (int i = 0; i < dataGridViewReport.Columns.Count; i++)
                            {
                                writer.Write(row.Cells[i].Value?.ToString() ?? "");
                                if (i < dataGridViewReport.Columns.Count - 1)
                                    writer.Write(";");
                            }
                            writer.WriteLine();
                        }
                    }

                    MessageBox.Show("Отчет экспортирован", "Экспорт",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при экспорте: {ex.Message}",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Функция печати будет доступна в следующей версии",
                "Печать", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}