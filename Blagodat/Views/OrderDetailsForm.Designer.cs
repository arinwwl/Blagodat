namespace Blagodat.Views
{
    partial class OrderDetailsForm
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
            Button buttonClose;
            labelTitle = new Label();
            labelOrderCodeText = new Label();
            labelDateText = new Label();
            labelClientText = new Label();
            labelClientCodeText = new Label();
            labelStatusText = new Label();
            labelDurationText = new Label();
            labelClosedDateText = new Label();
            groupOrderInfo = new GroupBox();
            textBoxOrderCode = new TextBox();
            textBoxDate = new TextBox();
            textBoxClient = new TextBox();
            textBoxClientCode = new TextBox();
            textBoxStatus = new TextBox();
            textBoxDuration = new TextBox();
            textBoxClosedDate = new TextBox();
            groupServices = new GroupBox();
            dataGridViewServices = new DataGridView();
            labelTotal = new Label();
            buttonPrintBarcode = new Button();
            buttonClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).BeginInit();
            SuspendLayout();
           
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(23, 9);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(107, 20);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Детали заказа";
          
            labelOrderCodeText.AutoSize = true;
            labelOrderCodeText.Location = new Point(23, 50);
            labelOrderCodeText.Name = "labelOrderCodeText";
            labelOrderCodeText.Size = new Size(87, 20);
            labelOrderCodeText.TabIndex = 1;
            labelOrderCodeText.Text = "Код заказа:";
         
            labelDateText.AutoSize = true;
            labelDateText.Location = new Point(23, 94);
            labelDateText.Name = "labelDateText";
            labelDateText.Size = new Size(44, 20);
            labelDateText.TabIndex = 2;
            labelDateText.Text = "Дата:";
            
            labelClientText.AutoSize = true;
            labelClientText.Location = new Point(23, 138);
            labelClientText.Name = "labelClientText";
            labelClientText.Size = new Size(61, 20);
            labelClientText.TabIndex = 3;
            labelClientText.Text = "Клиент:";
           
            labelClientCodeText.AutoSize = true;
            labelClientCodeText.Location = new Point(23, 189);
            labelClientCodeText.Name = "labelClientCodeText";
            labelClientCodeText.Size = new Size(97, 20);
            labelClientCodeText.TabIndex = 4;
            labelClientCodeText.Text = "Код клиента:";
           
            labelStatusText.AutoSize = true;
            labelStatusText.Location = new Point(23, 236);
            labelStatusText.Name = "labelStatusText";
            labelStatusText.Size = new Size(55, 20);
            labelStatusText.TabIndex = 5;
            labelStatusText.Text = "Статус:";
          
            labelDurationText.AutoSize = true;
            labelDurationText.Location = new Point(23, 284);
            labelDurationText.Name = "labelDurationText";
            labelDurationText.Size = new Size(108, 20);
            labelDurationText.TabIndex = 6;
            labelDurationText.Text = "Длительность:";
         
            labelClosedDateText.AutoSize = true;
            labelClosedDateText.Location = new Point(23, 334);
            labelClosedDateText.Name = "labelClosedDateText";
            labelClosedDateText.Size = new Size(113, 20);
            labelClosedDateText.TabIndex = 7;
            labelClosedDateText.Text = "Дата закрытия:";
         
            groupOrderInfo.Location = new Point(390, 40);
            groupOrderInfo.Name = "groupOrderInfo";
            groupOrderInfo.Size = new Size(188, 118);
            groupOrderInfo.TabIndex = 8;
            groupOrderInfo.TabStop = false;
            groupOrderInfo.Text = "Информация о заказе";
         
            textBoxOrderCode.Location = new Point(134, 50);
            textBoxOrderCode.Name = "textBoxOrderCode";
            textBoxOrderCode.Size = new Size(125, 27);
            textBoxOrderCode.TabIndex = 9;
           
            textBoxDate.Location = new Point(134, 94);
            textBoxDate.Name = "textBoxDate";
            textBoxDate.Size = new Size(125, 27);
            textBoxDate.TabIndex = 10;
         
            textBoxClient.Location = new Point(134, 138);
            textBoxClient.Name = "textBoxClient";
            textBoxClient.Size = new Size(125, 27);
            textBoxClient.TabIndex = 11;
            
            textBoxClientCode.Location = new Point(134, 189);
            textBoxClientCode.Name = "textBoxClientCode";
            textBoxClientCode.Size = new Size(125, 27);
            textBoxClientCode.TabIndex = 12;
           
            textBoxStatus.Location = new Point(134, 236);
            textBoxStatus.Name = "textBoxStatus";
            textBoxStatus.Size = new Size(125, 27);
            textBoxStatus.TabIndex = 13;
          
            textBoxDuration.Location = new Point(137, 281);
            textBoxDuration.Name = "textBoxDuration";
            textBoxDuration.Size = new Size(125, 27);
            textBoxDuration.TabIndex = 14;
         
            textBoxClosedDate.Location = new Point(142, 331);
            textBoxClosedDate.Name = "textBoxClosedDate";
            textBoxClosedDate.Size = new Size(125, 27);
            textBoxClosedDate.TabIndex = 15;
          
            groupServices.Location = new Point(390, 164);
            groupServices.Name = "groupServices";
            groupServices.Size = new Size(250, 125);
            groupServices.TabIndex = 16;
            groupServices.TabStop = false;
            groupServices.Text = "Услуги в заказе";
         
            dataGridViewServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewServices.Location = new Point(390, 295);
            dataGridViewServices.Name = "dataGridViewServices";
            dataGridViewServices.RowHeadersWidth = 51;
            dataGridViewServices.Size = new Size(198, 119);
         
            labelTotal.AutoSize = true;
            labelTotal.Location = new Point(667, 54);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(50, 20);
            labelTotal.TabIndex = 18;
            labelTotal.Text = "Итого";
            
            buttonPrintBarcode.Location = new Point(661, 111);
            buttonPrintBarcode.Name = "buttonPrintBarcode";
            buttonPrintBarcode.Size = new Size(94, 29);
            buttonPrintBarcode.TabIndex = 19;
            buttonPrintBarcode.Text = "Печать штрих-кода";
            buttonPrintBarcode.UseVisualStyleBackColor = true;
          
            buttonClose.Location = new Point(661, 171);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(94, 25);
            buttonClose.TabIndex = 20;
            buttonClose.Text = "Закрыть";
            buttonClose.UseVisualStyleBackColor = true;
           
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonClose);
            Controls.Add(buttonPrintBarcode);
            Controls.Add(labelTotal);
            Controls.Add(dataGridViewServices);
            Controls.Add(groupServices);
            Controls.Add(textBoxClosedDate);
            Controls.Add(textBoxDuration);
            Controls.Add(textBoxStatus);
            Controls.Add(textBoxClientCode);
            Controls.Add(textBoxClient);
            Controls.Add(textBoxDate);
            Controls.Add(textBoxOrderCode);
            Controls.Add(groupOrderInfo);
            Controls.Add(labelClosedDateText);
            Controls.Add(labelDurationText);
            Controls.Add(labelStatusText);
            Controls.Add(labelClientCodeText);
            Controls.Add(labelClientText);
            Controls.Add(labelDateText);
            Controls.Add(labelOrderCodeText);
            Controls.Add(labelTitle);
            Name = "OrderDetailsForm";
            Text = "OrderDetailsForm";
            //Load += OrderDetailsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label labelOrderCodeText;
        private Label labelDateText;
        private Label labelClientText;
        private Label labelClientCodeText;
        private Label labelStatusText;
        private Label labelDurationText;
        private Label labelClosedDateText;
        private GroupBox groupOrderInfo;
        private TextBox textBoxOrderCode;
        private TextBox textBoxDate;
        private TextBox textBoxClient;
        private TextBox textBoxClientCode;
        private TextBox textBoxStatus;
        private TextBox textBoxDuration;
        private TextBox textBoxClosedDate;
        private GroupBox groupServices;
        private DataGridView dataGridViewServices;
        private Label labelTotal;
        private Button buttonPrintBarcode;
    }
}