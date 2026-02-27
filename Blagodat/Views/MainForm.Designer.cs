namespace Blagodat.Views
{
    partial class MainForm
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
            panelTop = new Panel();
            panelBottom = new Panel();
            pictureBoxLogo = new PictureBox();
            labelWelcome = new Label();
            labelOrdersCount = new Label();
            txtSearch = new TextBox();
            cmbSort = new ComboBox();
            btnCreateOrder = new Button();
            btnReports = new Button();
            btnUsers = new Button();
            btnMaterials = new Button();
            flowLayoutPanelOrders = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
         
            panelTop.Location = new Point(21, 22);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(394, 43);
            panelTop.TabIndex = 0;
          
            panelBottom.Location = new Point(12, 389);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(403, 49);
            panelBottom.TabIndex = 1;
           
            pictureBoxLogo.Location = new Point(445, 22);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(111, 43);
            pictureBoxLogo.TabIndex = 2;
            pictureBoxLogo.TabStop = false;
         
            labelWelcome.AutoSize = true;
            labelWelcome.Location = new Point(21, 94);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(50, 20);
            labelWelcome.TabIndex = 3;
            labelWelcome.Text = "label1";
            labelOrdersCount.AutoSize = true;
            labelOrdersCount.Location = new Point(459, 418);
            labelOrdersCount.Name = "labelOrdersCount";
            labelOrdersCount.Size = new Size(50, 20);
            labelOrdersCount.TabIndex = 4;
            labelOrdersCount.Text = "label2";
           
            txtSearch.Location = new Point(24, 137);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(125, 27);
            txtSearch.TabIndex = 5;
         
            cmbSort.FormattingEnabled = true;
            cmbSort.Location = new Point(176, 136);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(55, 28);
            cmbSort.TabIndex = 6;
          
            btnCreateOrder.Location = new Point(21, 183);
            btnCreateOrder.Name = "btnCreateOrder";
            btnCreateOrder.Size = new Size(141, 29);
            btnCreateOrder.TabIndex = 7;
            btnCreateOrder.Text = "Создать заказ";
            btnCreateOrder.UseVisualStyleBackColor = true;
          
            btnReports.Location = new Point(21, 234);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(141, 29);
            btnReports.TabIndex = 8;
            btnReports.Text = "Отчеты";
            btnReports.UseVisualStyleBackColor = true;
         
            btnUsers.Location = new Point(24, 282);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(138, 27);
            btnUsers.TabIndex = 9;
            btnUsers.Text = "Пользователи";
            btnUsers.UseVisualStyleBackColor = true;
          
            btnMaterials.Location = new Point(24, 326);
            btnMaterials.Name = "btnMaterials";
            btnMaterials.Size = new Size(138, 29);
            btnMaterials.TabIndex = 10;
            btnMaterials.Text = "Материалы";
            btnMaterials.UseVisualStyleBackColor = true;
          
            flowLayoutPanelOrders.Location = new Point(315, 138);
            flowLayoutPanelOrders.Name = "flowLayoutPanelOrders";
            flowLayoutPanelOrders.Size = new Size(250, 125);
            flowLayoutPanelOrders.TabIndex = 11;
          
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flowLayoutPanelOrders);
            Controls.Add(btnMaterials);
            Controls.Add(btnUsers);
            Controls.Add(btnReports);
            Controls.Add(btnCreateOrder);
            Controls.Add(cmbSort);
            Controls.Add(txtSearch);
            Controls.Add(labelOrdersCount);
            Controls.Add(labelWelcome);
            Controls.Add(pictureBoxLogo);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            Name = "MainForm";
            Text = "MainForm";
            // Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelTop;
        private Panel panelBottom;
        private PictureBox pictureBoxLogo;
        private Label labelWelcome;
        private Label labelOrdersCount;
        private TextBox txtSearch;
        private ComboBox cmbSort;
        private Button btnCreateOrder;
        private Button btnReports;
        private Button btnUsers;
        private Button btnMaterials;
        private FlowLayoutPanel flowLayoutPanelOrders;
    }
}