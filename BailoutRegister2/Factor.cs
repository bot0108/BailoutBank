﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BailoutRegister2
{
    public partial class Factor : Form
    {
        private Data data;
        private User user;
        public Factor(Data data, User user)
        {
            InitializeComponent();
            this.data = data;
            this.user = user;
        }

        private void Factor_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==Login.globalEmail.ToString())
            {
                if (Login.logMail == "bailoutbank.info@gmail.com")
                {
                    Admin adminpage = new Admin();
                    adminpage.Show();
                    this.Hide();
                }
                else
                {
                    Main mainpage = new Main(user);
                    mainpage.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login loginpage = new Login();
            loginpage.Show();
            this.Hide();
        }
    }
}
