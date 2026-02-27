namespace Blagodat.Views
{
    partial class ReportsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelTitle = new Label();
            labelFrom = new Label();
            labelTo = new Label();
            labelReportType = new Label();
            labelTotal = new Label();
            groupPeriod = new GroupBox();
            dateTimePickerFrom = new DateTimePicker();
            dateTimePickerTo = new DateTimePicker();
            comboBoxReportType = new ComboBox();
            btnGenerate = new Button();
            btnExport = new Button();
            btnPrint = new Button();
            btnClose = new Button();
            dataGridViewReport = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport).BeginInit();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(13, 16);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(59, 20);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Отчеты";
            // 
            // labelFrom
            // 
            labelFrom.AutoSize = true;
            labelFrom.Location = new Point(20, 62);
            labelFrom.Name = "labelFrom";
            labelFrom.Size = new Size(18, 20);
            labelFrom.TabIndex = 1;
            labelFrom.Text = "С";
            // 
            // labelTo
            // 
            labelTo.AutoSize = true;
            labelTo.Location = new Point(20, 114);
            labelTo.Name = "labelTo";
            labelTo.Size = new Size(29, 20);
            labelTo.TabIndex = 2;
            labelTo.Text = "По";
            // 
            // labelReportType
            // 
            labelReportType.AutoSize = true;
            labelReportType.Location = new Point(22, 160);
            labelReportType.Name = "labelReportType";
            labelReportType.Size = new Size(84, 20);
            labelReportType.TabIndex = 3;
            labelReportType.Text = "Тип отчета";
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Location = new Point(22, 411);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(169, 20);
            labelTotal.TabIndex = 4;
            labelTotal.Text = "\tИтоговая информация";
            // 
            // groupPeriod
            // 
            groupPeriod.Location = new Point(357, 16);
            groupPeriod.Name = "groupPeriod";
            groupPeriod.Size = new Size(250, 125);
            groupPeriod.TabIndex = 5;
            groupPeriod.TabStop = false;
            groupPeriod.Text = "Период";
            // 
            // dateTimePickerFrom
            // 
            dateTimePickerFrom.Location = new Point(104, 69);
            dateTimePickerFrom.Name = "dateTimePickerFrom";
            dateTimePickerFrom.Size = new Size(110, 27);
            dateTimePickerFrom.TabIndex = 6;
            // 
            // dateTimePickerTo
            // 
            dateTimePickerTo.Location = new Point(104, 114);
            dateTimePickerTo.Name = "dateTimePickerTo";
            dateTimePickerTo.Size = new Size(110, 27);
            dateTimePickerTo.TabIndex = 7;
            // 
            // comboBoxReportType
            // 
            comboBoxReportType.FormattingEnabled = true;
            comboBoxReportType.Location = new Point(124, 157);
            comboBoxReportType.Name = "comboBoxReportType";
            comboBoxReportType.Size = new Size(151, 28);
            comboBoxReportType.TabIndex = 8;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(20, 210);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(134, 31);
            btnGenerate.TabIndex = 9;
            btnGenerate.Text = "Сгенерировать";
            btnGenerate.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(351, 176);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(136, 29);
            btnExport.TabIndex = 10;
            btnExport.Text = "Экспорт в CSV";
            btnExport.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(350, 235);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(94, 29);
            btnPrint.TabIndex = 11;
            btnPrint.Text = "Печать";
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(352, 287);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 12;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // dataGridViewReport
            // 
            dataGridViewReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReport.Location = new Point(22, 260);
            dataGridViewReport.Name = "dataGridViewReport";
            dataGridViewReport.RowHeadersWidth = 51;
            dataGridViewReport.Size = new Size(253, 136);
            dataGridViewReport.TabIndex = 13;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewReport);
            Controls.Add(btnClose);
            Controls.Add(btnPrint);
            Controls.Add(btnExport);
            Controls.Add(btnGenerate);
            Controls.Add(comboBoxReportType);
            Controls.Add(dateTimePickerTo);
            Controls.Add(dateTimePickerFrom);
            Controls.Add(groupPeriod);
            Controls.Add(labelTotal);
            Controls.Add(labelReportType);
            Controls.Add(labelTo);
            Controls.Add(labelFrom);
            Controls.Add(labelTitle);
            Name = "ReportsForm";
            Text = "ReportsForm";
            //Load += ReportsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label labelFrom;
        private Label labelTo;
        private Label labelReportType;
        private Label labelTotal;
        private GroupBox groupPeriod;
        private DateTimePicker dateTimePickerFrom;
        private DateTimePicker dateTimePickerTo;
        private ComboBox comboBoxReportType;
        private Button btnGenerate;
        private Button btnExport;
        private Button btnPrint;
        private Button btnClose;
        private DataGridView dataGridViewReport;
    }
}