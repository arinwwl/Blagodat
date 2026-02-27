namespace Blagodat.Views
{
    partial class OrderForm
    {
       
        private System.ComponentModel.IContainer components = null;

 
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

  
        private void InitializeComponent()
        {
            labelTitle = new Label();
            labelOrderCode = new Label();
            labelDate = new Label();
            labelTime = new Label();
            labelClient = new Label();
            labelDuration = new Label();
            labelStatus = new Label();
            labelTotal = new Label();
            groupOrderInfo = new GroupBox();
            textBoxOrderCode = new TextBox();
            dateTimePickerDate = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            comboBoxClient = new ComboBox();
            textBoxDuration = new TextBox();
            comboBoxStatus = new ComboBox();
            groupServices = new GroupBox();
            comboBoxServices = new ComboBox();
            numericUpDownQuantity = new NumericUpDown();
            btnAddService = new Button();
            dataGridViewServices = new DataGridView();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).BeginInit();
            SuspendLayout();
           
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(29, 24);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(125, 20);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Создание заказа";
          
            labelOrderCode.AutoSize = true;
            labelOrderCode.Location = new Point(32, 58);
            labelOrderCode.Name = "labelOrderCode";
            labelOrderCode.Size = new Size(84, 20);
            labelOrderCode.TabIndex = 1;
            labelOrderCode.Text = "Код заказа";
           
            labelDate.AutoSize = true;
            labelDate.Location = new Point(32, 129);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(41, 20);
            labelDate.TabIndex = 2;
            labelDate.Text = "\tДата";
          
            labelTime.AutoSize = true;
            labelTime.Location = new Point(29, 196);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(54, 20);
            labelTime.TabIndex = 3;
            labelTime.Text = "Время";
          
            labelClient.AutoSize = true;
            labelClient.Location = new Point(29, 268);
            labelClient.Name = "labelClient";
            labelClient.Size = new Size(58, 20);
            labelClient.TabIndex = 4;
            labelClient.Text = "Клиент";
          
            labelDuration.AutoSize = true;
            labelDuration.Location = new Point(29, 314);
            labelDuration.Name = "labelDuration";
            labelDuration.Size = new Size(105, 20);
            labelDuration.TabIndex = 5;
            labelDuration.Text = "Длительность";
           
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(33, 379);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(52, 20);
            labelStatus.TabIndex = 6;
            labelStatus.Text = "Статус";
         
            labelTotal.AutoSize = true;
            labelTotal.Location = new Point(565, 196);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(50, 20);
            labelTotal.TabIndex = 7;
            labelTotal.Text = "Итого";
         
            groupOrderInfo.Location = new Point(283, 24);
            groupOrderInfo.Name = "groupOrderInfo";
            groupOrderInfo.Size = new Size(250, 125);
            groupOrderInfo.TabIndex = 8;
            groupOrderInfo.TabStop = false;
            groupOrderInfo.Text = "Информация о заказе";
           
            textBoxOrderCode.Location = new Point(32, 81);
            textBoxOrderCode.Name = "textBoxOrderCode";
            textBoxOrderCode.Size = new Size(125, 27);
            textBoxOrderCode.TabIndex = 9;
           
            dateTimePickerDate.Location = new Point(32, 155);
            dateTimePickerDate.Name = "dateTimePickerDate";
            dateTimePickerDate.Size = new Size(184, 27);
            dateTimePickerDate.TabIndex = 10;
            dateTimePickerDate.Value = new DateTime(2026, 2, 26, 0, 0, 0, 0);
           
            dateTimePicker1.Location = new Point(29, 219);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(111, 27);
            dateTimePicker1.TabIndex = 11;
            dateTimePicker1.Value = new DateTime(2026, 2, 26, 16, 58, 0, 0);
          
            comboBoxClient.FormattingEnabled = true;
            comboBoxClient.Location = new Point(112, 265);
            comboBoxClient.Name = "comboBoxClient";
            comboBoxClient.Size = new Size(151, 28);
            comboBoxClient.TabIndex = 12;
           
            textBoxDuration.Location = new Point(138, 314);
            textBoxDuration.Name = "textBoxDuration";
            textBoxDuration.Size = new Size(125, 27);
            textBoxDuration.TabIndex = 13;
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Location = new Point(91, 379);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(151, 28);
            comboBoxStatus.TabIndex = 14;
            // 
            // groupServices
            // 
            groupServices.Location = new Point(305, 165);
            groupServices.Name = "groupServices";
            groupServices.Size = new Size(228, 66);
            groupServices.TabIndex = 15;
            groupServices.TabStop = false;
            groupServices.Text = "Услуги";
            // 
            // comboBoxServices
            // 
            comboBoxServices.FormattingEnabled = true;
            comboBoxServices.Location = new Point(305, 252);
            comboBoxServices.Name = "comboBoxServices";
            comboBoxServices.Size = new Size(151, 28);
            comboBoxServices.TabIndex = 16;
            // 
            // numericUpDownQuantity
            // 
            numericUpDownQuantity.Location = new Point(306, 312);
            numericUpDownQuantity.Name = "numericUpDownQuantity";
            numericUpDownQuantity.Size = new Size(150, 27);
            numericUpDownQuantity.TabIndex = 17;
           
            // 
            // btnAddService
            // 
            btnAddService.Location = new Point(305, 370);
            btnAddService.Name = "btnAddService";
            btnAddService.Size = new Size(151, 29);
            btnAddService.TabIndex = 18;
            btnAddService.Text = "Добавить услугу";
            btnAddService.UseVisualStyleBackColor = true;
            // 
            // dataGridViewServices
            // 
            dataGridViewServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewServices.Location = new Point(565, 34);
            dataGridViewServices.Name = "dataGridViewServices";
            dataGridViewServices.RowHeadersWidth = 51;
            dataGridViewServices.Size = new Size(223, 130);
            dataGridViewServices.TabIndex = 19;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(565, 370);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 20;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(684, 370);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 21;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(dataGridViewServices);
            Controls.Add(btnAddService);
            Controls.Add(numericUpDownQuantity);
            Controls.Add(comboBoxServices);
            Controls.Add(groupServices);
            Controls.Add(comboBoxStatus);
            Controls.Add(textBoxDuration);
            Controls.Add(comboBoxClient);
            Controls.Add(dateTimePicker1);
            Controls.Add(dateTimePickerDate);
            Controls.Add(textBoxOrderCode);
            Controls.Add(groupOrderInfo);
            Controls.Add(labelTotal);
            Controls.Add(labelStatus);
            Controls.Add(labelDuration);
            Controls.Add(labelClient);
            Controls.Add(labelTime);
            Controls.Add(labelDate);
            Controls.Add(labelOrderCode);
            Controls.Add(labelTitle);
            Name = "OrderForm";
            Text = "OrderForm";
            //Load += OrderForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label labelOrderCode;
        private Label labelDate;
        private Label labelTime;
        private Label labelClient;
        private Label labelDuration;
        private Label labelStatus;
        private Label labelTotal;
        private GroupBox groupOrderInfo;
        private TextBox textBoxOrderCode;
        private DateTimePicker dateTimePickerDate;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBoxClient;
        private TextBox textBoxDuration;
        private ComboBox comboBoxStatus;
        private GroupBox groupServices;
        private ComboBox comboBoxServices;
        private NumericUpDown numericUpDownQuantity;
        private Button btnAddService;
        private DataGridView dataGridViewServices;
        private Button btnSave;
        private Button btnCancel;
    }
}