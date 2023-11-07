namespace AppForRest_PIT
{
    partial class Seller
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
            this.label1 = new System.Windows.Forms.Label();
            this.posInOrderList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.isPaidBttn = new System.Windows.Forms.Button();
            this.posGroupBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.posInGroupList = new System.Windows.Forms.ListBox();
            this.addPosBttn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.activeTablesList = new System.Windows.Forms.ListBox();
            this.closeBoxBttn = new System.Windows.Forms.Button();
            this.tableNumber = new System.Windows.Forms.DomainUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Клиент №";
            // 
            // posInOrderList
            // 
            this.posInOrderList.FormattingEnabled = true;
            this.posInOrderList.ItemHeight = 26;
            this.posInOrderList.Location = new System.Drawing.Point(242, 91);
            this.posInOrderList.Name = "posInOrderList";
            this.posInOrderList.Size = new System.Drawing.Size(264, 368);
            this.posInOrderList.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 484);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Сумма:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(343, 481);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(162, 34);
            this.textBox1.TabIndex = 5;
            // 
            // isPaidBttn
            // 
            this.isPaidBttn.Location = new System.Drawing.Point(242, 521);
            this.isPaidBttn.Name = "isPaidBttn";
            this.isPaidBttn.Size = new System.Drawing.Size(263, 37);
            this.isPaidBttn.TabIndex = 6;
            this.isPaidBttn.Text = "Оплачено";
            this.isPaidBttn.UseVisualStyleBackColor = true;
            this.isPaidBttn.Click += new System.EventHandler(this.isPaidBttn_Click);
            // 
            // posGroupBox
            // 
            this.posGroupBox.FormattingEnabled = true;
            this.posGroupBox.Location = new System.Drawing.Point(19, 87);
            this.posGroupBox.Name = "posGroupBox";
            this.posGroupBox.Size = new System.Drawing.Size(217, 34);
            this.posGroupBox.TabIndex = 7;
            this.posGroupBox.SelectedIndexChanged += new System.EventHandler(this.posGroupBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 26);
            this.label3.TabIndex = 8;
            this.label3.Text = "Клиент";
            // 
            // posInGroupList
            // 
            this.posInGroupList.FormattingEnabled = true;
            this.posInGroupList.ItemHeight = 26;
            this.posInGroupList.Location = new System.Drawing.Point(18, 143);
            this.posInGroupList.Name = "posInGroupList";
            this.posInGroupList.Size = new System.Drawing.Size(218, 316);
            this.posInGroupList.TabIndex = 9;
            this.posInGroupList.SelectedIndexChanged += new System.EventHandler(this.posInGroupList_SelectedIndexChanged);
            // 
            // addPosBttn
            // 
            this.addPosBttn.Location = new System.Drawing.Point(18, 521);
            this.addPosBttn.Name = "addPosBttn";
            this.addPosBttn.Size = new System.Drawing.Size(218, 37);
            this.addPosBttn.TabIndex = 10;
            this.addPosBttn.Text = "Добавить";
            this.addPosBttn.UseVisualStyleBackColor = true;
            this.addPosBttn.Click += new System.EventHandler(this.addPosBttn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(513, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 26);
            this.label4.TabIndex = 11;
            this.label4.Text = "Текущие заказы";
            // 
            // activeTablesList
            // 
            this.activeTablesList.FormattingEnabled = true;
            this.activeTablesList.ItemHeight = 26;
            this.activeTablesList.Location = new System.Drawing.Point(518, 91);
            this.activeTablesList.Name = "activeTablesList";
            this.activeTablesList.Size = new System.Drawing.Size(274, 186);
            this.activeTablesList.TabIndex = 12;
            this.activeTablesList.SelectedIndexChanged += new System.EventHandler(this.activeTablesList_SelectedIndexChanged);
            // 
            // closeBoxBttn
            // 
            this.closeBoxBttn.Enabled = false;
            this.closeBoxBttn.Location = new System.Drawing.Point(518, 521);
            this.closeBoxBttn.Name = "closeBoxBttn";
            this.closeBoxBttn.Size = new System.Drawing.Size(273, 36);
            this.closeBoxBttn.TabIndex = 14;
            this.closeBoxBttn.Text = "Закрыть кассу";
            this.closeBoxBttn.UseVisualStyleBackColor = true;
            this.closeBoxBttn.Click += new System.EventHandler(this.closeBoxBttn_Click);
            // 
            // tableNumber
            // 
            this.tableNumber.Location = new System.Drawing.Point(195, 13);
            this.tableNumber.Name = "tableNumber";
            this.tableNumber.Size = new System.Drawing.Size(310, 34);
            this.tableNumber.TabIndex = 15;
            this.tableNumber.SelectedItemChanged += new System.EventHandler(this.tableNumber_SelectedItemChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(237, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(268, 26);
            this.label5.TabIndex = 16;
            this.label5.Text = "Формирование заказа";
            // 
            // Seller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 570);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tableNumber);
            this.Controls.Add(this.closeBoxBttn);
            this.Controls.Add(this.activeTablesList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.addPosBttn);
            this.Controls.Add(this.posInGroupList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.posGroupBox);
            this.Controls.Add(this.isPaidBttn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.posInOrderList);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Bookman Old Style", 13.8F);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Seller";
            this.Load += new System.EventHandler(this.Seller_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox posInOrderList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button isPaidBttn;
        private System.Windows.Forms.ComboBox posGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox posInGroupList;
        private System.Windows.Forms.Button addPosBttn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox activeTablesList;
        private System.Windows.Forms.Button closeBoxBttn;
        private System.Windows.Forms.DomainUpDown tableNumber;
        private System.Windows.Forms.Label label5;
    }
}