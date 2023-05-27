using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using System.Data.SqlClient;

namespace BailoutRegister2
{
    public partial class Login : Form
    {
        private Data data;
       
        public Login(Data data)
        {
            this.data = data;
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }
        
        public void button1_Click(object sender, EventArgs e)
        {
            if (data.ValidateLogin(uname.Text, pword.Text))
            {
                MessageBox.Show("Login successful!");
                Main mainform = new Main(data);
                mainform.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void closer_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Forgotten form2 = new Forgotten(data);
            form2.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Register form3 = new Register(data);
            form3.Show();
        }
        public string globalUser = "";
        private void uname_TextChanged(object sender, EventArgs e)
        {
            globalUser += uname.Text;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

        
}

