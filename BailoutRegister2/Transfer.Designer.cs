namespace BailoutRegister2
{
    partial class Transfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transfer));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.to = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox123 = new System.Windows.Forms.Label();
            this.money = new System.Windows.Forms.TextBox();
            this.from = new System.Windows.Forms.ComboBox();
            this.mySqlCommand1 = new MySqlConnector.MySqlCommand();
            this.autotransactionbox = new System.Windows.Forms.CheckBox();
            this.start_dob = new System.Windows.Forms.DateTimePicker();
            this.end_dob = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.freque = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-3, -10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(409, 626);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(691, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Transfer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(478, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 36);
            this.label2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(474, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 36);
            this.label3.TabIndex = 3;
            this.label3.Text = "From:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(474, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 36);
            this.label4.TabIndex = 4;
            this.label4.Text = "To:";
            // 
            // to
            // 
            this.to.Location = new System.Drawing.Point(480, 279);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(314, 22);
            this.to.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(625, 552);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 44);
            this.button1.TabIndex = 8;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // message
            // 
            this.message.Location = new System.Drawing.Point(888, 111);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(258, 83);
            this.message.TabIndex = 9;
            this.message.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(882, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 36);
            this.label5.TabIndex = 10;
            this.label5.Text = "Message";
            // 
            // textBox123
            // 
            this.textBox123.AutoSize = true;
            this.textBox123.BackColor = System.Drawing.Color.Transparent;
            this.textBox123.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox123.Location = new System.Drawing.Point(474, 342);
            this.textBox123.Name = "textBox123";
            this.textBox123.Size = new System.Drawing.Size(159, 36);
            this.textBox123.TabIndex = 11;
            this.textBox123.Text = "Amount:";
            // 
            // money
            // 
            this.money.Location = new System.Drawing.Point(480, 398);
            this.money.Name = "money";
            this.money.Size = new System.Drawing.Size(314, 22);
            this.money.TabIndex = 12;
            // 
            // from
            // 
            this.from.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.from.FormattingEnabled = true;
            this.from.Location = new System.Drawing.Point(480, 155);
            this.from.Name = "from";
            this.from.Size = new System.Drawing.Size(313, 24);
            this.from.TabIndex = 13;
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CommandTimeout = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.Transaction = null;
            this.mySqlCommand1.UpdatedRowSource = System.Data.UpdateRowSource.None;
            // 
            // autotransactionbox
            // 
            this.autotransactionbox.AutoSize = true;
            this.autotransactionbox.BackColor = System.Drawing.Color.Transparent;
            this.autotransactionbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.autotransactionbox.Location = new System.Drawing.Point(858, 234);
            this.autotransactionbox.Name = "autotransactionbox";
            this.autotransactionbox.Size = new System.Drawing.Size(272, 29);
            this.autotransactionbox.TabIndex = 14;
            this.autotransactionbox.Text = "Make Auto - Transaction";
            this.autotransactionbox.UseVisualStyleBackColor = false;
            // 
            // start_dob
            // 
            this.start_dob.Location = new System.Drawing.Point(858, 320);
            this.start_dob.Name = "start_dob";
            this.start_dob.Size = new System.Drawing.Size(233, 22);
            this.start_dob.TabIndex = 15;
            // 
            // end_dob
            // 
            this.end_dob.Location = new System.Drawing.Point(858, 396);
            this.end_dob.Name = "end_dob";
            this.end_dob.Size = new System.Drawing.Size(233, 22);
            this.end_dob.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(853, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 25);
            this.label6.TabIndex = 17;
            this.label6.Text = "Starting Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(853, 368);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 25);
            this.label7.TabIndex = 18;
            this.label7.Text = "Ending Date";
            // 
            // freque
            // 
            this.freque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.freque.FormattingEnabled = true;
            this.freque.Items.AddRange(new object[] {
            "Weekly",
            "Monthly",
            "Yearly"});
            this.freque.Location = new System.Drawing.Point(858, 476);
            this.freque.Name = "freque";
            this.freque.Size = new System.Drawing.Size(233, 24);
            this.freque.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(853, 448);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 25);
            this.label8.TabIndex = 20;
            this.label8.Text = "Frequency";
            // 
            // Transfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1204, 608);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.freque);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.end_dob);
            this.Controls.Add(this.start_dob);
            this.Controls.Add(this.autotransactionbox);
            this.Controls.Add(this.from);
            this.Controls.Add(this.money);
            this.Controls.Add(this.textBox123);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.message);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.to);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Transfer";
            this.Text = "Transfer";
            this.Load += new System.EventHandler(this.Transfer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox to;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox message;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label textBox123;
        private System.Windows.Forms.TextBox money;
        private System.Windows.Forms.ComboBox from;
        private MySqlConnector.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.CheckBox autotransactionbox;
        private System.Windows.Forms.DateTimePicker start_dob;
        private System.Windows.Forms.DateTimePicker end_dob;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox freque;
        private System.Windows.Forms.Label label8;
    }
}