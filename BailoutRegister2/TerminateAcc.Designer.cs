namespace BailoutRegister2
{
    partial class TerminateAcc
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.accounts = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(118, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 41);
            this.button1.TabIndex = 24;
            this.button1.Text = "Terminate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(59, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 28);
            this.label1.TabIndex = 25;
            this.label1.Text = "Terminate an account";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 96);
            this.label3.TabIndex = 26;
            this.label3.Text = "By terminating your account,\r\nyou aknowledge \r\nthat you won\'t be able to\r\n access" +
    " your account anymore.\r\nThe remaining balance will be\r\n sent out to one of your " +
    "accounts.";
            // 
            // accounts
            // 
            this.accounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accounts.FormattingEnabled = true;
            this.accounts.Location = new System.Drawing.Point(50, 121);
            this.accounts.Name = "accounts";
            this.accounts.Size = new System.Drawing.Size(313, 24);
            this.accounts.TabIndex = 27;
            // 
            // TerminateAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 568);
            this.Controls.Add(this.accounts);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "TerminateAcc";
            this.Text = "TrerminateAcc";
            this.Load += new System.EventHandler(this.TerminateAcc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox accounts;
    }
}