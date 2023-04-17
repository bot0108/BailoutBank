namespace Bailout_Bank
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.BBlogo = new System.Windows.Forms.PictureBox();
            this.LogRegi = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.UserNameBox = new System.Windows.Forms.TextBox();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.ForgottenPass = new System.Windows.Forms.Button();
            this.LoginButton = new System.Windows.Forms.Button();
            this.PasswordText = new System.Windows.Forms.Label();
            this.UserNameText = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BBlogo)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 46;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.guna2GradientPanel1, "guna2GradientPanel1");
            this.guna2GradientPanel1.Controls.Add(this.BBlogo);
            this.guna2GradientPanel1.Controls.Add(this.LogRegi);
            this.guna2GradientPanel1.Controls.Add(this.panel2);
            this.guna2GradientPanel1.Controls.Add(this.guna2PictureBox1);
            this.guna2GradientPanel1.Controls.Add(this.pictureBox1);
            this.guna2GradientPanel1.ForeColor = System.Drawing.Color.Black;
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            // 
            // BBlogo
            // 
            resources.ApplyResources(this.BBlogo, "BBlogo");
            this.BBlogo.Name = "BBlogo";
            this.BBlogo.TabStop = false;
            // 
            // LogRegi
            // 
            resources.ApplyResources(this.LogRegi, "LogRegi");
            this.LogRegi.ForeColor = System.Drawing.Color.White;
            this.LogRegi.Name = "LogRegi";
            this.LogRegi.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.PasswordBox);
            this.panel2.Controls.Add(this.UserNameBox);
            this.panel2.Controls.Add(this.RegisterButton);
            this.panel2.Controls.Add(this.ForgottenPass);
            this.panel2.Controls.Add(this.LoginButton);
            this.panel2.Controls.Add(this.PasswordText);
            this.panel2.Controls.Add(this.UserNameText);
            this.panel2.Name = "panel2";
            // 
            // PasswordBox
            // 
            resources.ApplyResources(this.PasswordBox, "PasswordBox");
            this.PasswordBox.Name = "PasswordBox";
            // 
            // UserNameBox
            // 
            this.UserNameBox.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.UserNameBox, "UserNameBox");
            this.UserNameBox.Name = "UserNameBox";
            // 
            // RegisterButton
            // 
            this.RegisterButton.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.RegisterButton, "RegisterButton");
            this.RegisterButton.ForeColor = System.Drawing.Color.White;
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.Register_Click);
            // 
            // ForgottenPass
            // 
            this.ForgottenPass.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.ForgottenPass, "ForgottenPass");
            this.ForgottenPass.ForeColor = System.Drawing.Color.White;
            this.ForgottenPass.Name = "ForgottenPass";
            this.ForgottenPass.UseVisualStyleBackColor = true;
            this.ForgottenPass.Click += new System.EventHandler(this.button2_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.FlatAppearance.BorderSize = 2;
            resources.ApplyResources(this.LoginButton, "LoginButton");
            this.LoginButton.ForeColor = System.Drawing.Color.White;
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // PasswordText
            // 
            resources.ApplyResources(this.PasswordText, "PasswordText");
            this.PasswordText.ForeColor = System.Drawing.Color.White;
            this.PasswordText.Name = "PasswordText";
            // 
            // UserNameText
            // 
            resources.ApplyResources(this.UserNameText, "UserNameText");
            this.UserNameText.ForeColor = System.Drawing.Color.White;
            this.UserNameText.Name = "UserNameText";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.guna2PictureBox1, "guna2PictureBox1");
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            this.guna2PictureBox1.Click += new System.EventHandler(this.guna2PictureBox1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.guna2GradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BBlogo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.Label LogRegi;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label PasswordText;
        private System.Windows.Forms.Label UserNameText;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Button ForgottenPass;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.TextBox UserNameBox;
        private System.Windows.Forms.PictureBox BBlogo;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

