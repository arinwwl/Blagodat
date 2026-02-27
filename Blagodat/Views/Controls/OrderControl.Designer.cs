namespace Blagodat.Views.Controls
{
    partial class OrderControl
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

        #region Код, автоматически созданный конструктором компонентов
        private void InitializeComponent()
        {
            lblOrderCode = new Label();
            lblClient = new Label();
            lblDate = new Label();
            lblStatus = new Label();
            lblDuration = new Label();
            btnViewDetails = new Button();
            btnPrintBarcode = new Button();
            SuspendLayout();
          
            lblOrderCode.AutoSize = true;
            lblOrderCode.Location = new Point(19, 25);
            lblOrderCode.Name = "lblOrderCode";
            lblOrderCode.Size = new Size(84, 20);
            lblOrderCode.TabIndex = 0;
            lblOrderCode.Text = "Код заказа";

            lblClient.AutoSize = true;
            lblClient.Location = new Point(19, 71);
            lblClient.Name = "lblClient";
            lblClient.Size = new Size(58, 20);
            lblClient.TabIndex = 1;
            lblClient.Text = "Клиент";
  
            lblDate.AutoSize = true;
            lblDate.Location = new Point(19, 125);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(41, 20);
            lblDate.TabIndex = 2;
            lblDate.Text = "Дата";

            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(19, 184);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 20);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Статус";
        
            lblDuration.AutoSize = true;
            lblDuration.Location = new Point(19, 237);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(105, 20);
            lblDuration.TabIndex = 4;
            lblDuration.Text = "Длительность";
         
            btnViewDetails.Location = new Point(19, 301);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new Size(94, 29);
            btnViewDetails.TabIndex = 5;
            btnViewDetails.Text = "Детали";
            btnViewDetails.UseVisualStyleBackColor = true;
        
            btnPrintBarcode.Location = new Point(19, 362);
            btnPrintBarcode.Name = "btnPrintBarcode";
            btnPrintBarcode.Size = new Size(94, 29);
            btnPrintBarcode.TabIndex = 6;
            btnPrintBarcode.Text = "Штрих-код";
            btnPrintBarcode.UseVisualStyleBackColor = true;
          
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnPrintBarcode);
            Controls.Add(btnViewDetails);
            Controls.Add(lblDuration);
            Controls.Add(lblStatus);
            Controls.Add(lblDate);
            Controls.Add(lblClient);
            Controls.Add(lblOrderCode);
            Name = "OrderControl";
            Size = new Size(418, 482);
            //Load += OrderControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblOrderCode;
        private Label lblClient;
        private Label lblDate;
        private Label lblStatus;
        private Label lblDuration;
        private Button btnViewDetails;
        private Button btnPrintBarcode;
    }
}
