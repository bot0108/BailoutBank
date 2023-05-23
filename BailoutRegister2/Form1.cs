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

        private void button1_Click(object sender, EventArgs e)
        {
            if (data.ValidateLogin(uname.Text, pword.Text))
            {
                Console.WriteLine("ok");
                MessageBox.Show("Login successful!");

            }
            else
            {
                Console.WriteLine("ok");
                MessageBox.Show("Invalid username or password.");
            }
        }
        /*string query = $"INSERT INTO basic(user,pass)" + $"VALUES('{user}'," + $"'{pass}');";
        MySqlCommand command = new MySqlCommand(query, conn);
        int result = command.ExecuteNonQuery();*/
        /* this.Hide();
         Main ss= new Main();
         ss.Show();*/
        private string uname_TextChanged(object sender, EventArgs e)
        {
            string monke = "monke";
            return monke;
        }

        private void closer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

        
}

