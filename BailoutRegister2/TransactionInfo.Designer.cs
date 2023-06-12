namespace BailoutRegister2
{
    partial class TransactionInfo
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
            this.label2 = new System.Windows.Forms.Label();
            this.fromname = new System.Windows.Forms.Label();
            this.toname = new System.Windows.Forms.Label();
            this.fromacc = new System.Windows.Forms.Label();
            this.toacc = new System.Windows.Forms.Label();
            this.lablea = new System.Windows.Forms.Label();
            this.amount = new System.Windows.Forms.Label();
            this.messagebox = new System.Windows.Forms.RichTextBox();
            this.datelable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(31, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "FROM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(504, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "TO";
            // 
            // fromname
            // 
            this.fromname.AutoSize = true;
            this.fromname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.fromname.Location = new System.Drawing.Point(128, 41);
            this.fromname.Name = "fromname";
            this.fromname.Size = new System.Drawing.Size(23, 25);
            this.fromname.TabIndex = 2;
            this.fromname.Text = "1";
            // 
            // toname
            // 
            this.toname.AutoSize = true;
            this.toname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.toname.Location = new System.Drawing.Point(559, 41);
            this.toname.Name = "toname";
            this.toname.Size = new System.Drawing.Size(23, 25);
            this.toname.TabIndex = 3;
            this.toname.Text = "1";
            // 
            // fromacc
            // 
            this.fromacc.AutoSize = true;
            this.fromacc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.fromacc.Location = new System.Drawing.Point(128, 88);
            this.fromacc.Name = "fromacc";
            this.fromacc.Size = new System.Drawing.Size(23, 25);
            this.fromacc.TabIndex = 4;
            this.fromacc.Text = "1";
            this.fromacc.Click += new System.EventHandler(this.label5_Click);
            // 
            // toacc
            // 
            this.toacc.AutoSize = true;
            this.toacc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.toacc.Location = new System.Drawing.Point(559, 88);
            this.toacc.Name = "toacc";
            this.toacc.Size = new System.Drawing.Size(23, 25);
            this.toacc.TabIndex = 5;
            this.toacc.Text = "1";
            // 
            // lablea
            // 
            this.lablea.AutoSize = true;
            this.lablea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lablea.Location = new System.Drawing.Point(232, 198);
            this.lablea.Name = "lablea";
            this.lablea.Size = new System.Drawing.Size(80, 25);
            this.lablea.TabIndex = 7;
            this.lablea.Text = "Amount";
            // 
            // amount
            // 
            this.amount.AutoSize = true;
            this.amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.amount.Location = new System.Drawing.Point(354, 198);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(23, 25);
            this.amount.TabIndex = 8;
            this.amount.Text = "1";
            // 
            // messagebox
            // 
            this.messagebox.BackColor = System.Drawing.Color.White;
            this.messagebox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messagebox.Location = new System.Drawing.Point(190, 301);
            this.messagebox.Name = "messagebox";
            this.messagebox.ReadOnly = true;
            this.messagebox.Size = new System.Drawing.Size(417, 96);
            this.messagebox.TabIndex = 9;
            this.messagebox.Text = "";
            // 
            // datelable
            // 
            this.datelable.AutoSize = true;
            this.datelable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.datelable.Location = new System.Drawing.Point(760, 372);
            this.datelable.Name = "datelable";
            this.datelable.Size = new System.Drawing.Size(23, 25);
            this.datelable.TabIndex = 10;
            this.datelable.Text = "1";
            // 
            // TransactionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(973, 441);
            this.Controls.Add(this.datelable);
            this.Controls.Add(this.messagebox);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.lablea);
            this.Controls.Add(this.toacc);
            this.Controls.Add(this.fromacc);
            this.Controls.Add(this.toname);
            this.Controls.Add(this.fromname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TransactionInfo";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.TransactionInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label fromname;
        private System.Windows.Forms.Label toname;
        private System.Windows.Forms.Label fromacc;
        private System.Windows.Forms.Label toacc;
        private System.Windows.Forms.Label lablea;
        private System.Windows.Forms.Label amount;
        private System.Windows.Forms.RichTextBox messagebox;
        private System.Windows.Forms.Label datelable;
    }
}