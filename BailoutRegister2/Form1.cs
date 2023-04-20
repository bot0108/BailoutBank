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

namespace BailoutRegister2
{
    public partial class Login : Form
    {
        private string connection = "datasource=127.0.0.1;port=8889;username=root;password=root;database=login";

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string user=uname.Text;
            string pass = pword.Text;
            string query = $"INSERT INTO basic(user,pass)" + $"VALUES('{user}'," + $"'{pass}');";
            MySqlCommand command = new MySqlCommand(query, conn);
            int result = command.ExecuteNonQuery();
        }

        private string uname_TextChanged(object sender, EventArgs e)
        {
            string monke = "monke";
            return monke;
        }
    }
}
