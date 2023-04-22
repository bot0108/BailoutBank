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
            string user = uname.Text;
            string pass = pword.Text;
            MySqlDataAdapter sda = new MySqlDataAdapter($"SELECT Count(*) From basic where user='" + user + "' and pass='" + pass +"'",conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString()=="1")
            {
                this.Hide();
                Main ss = new Main();
                ss.Show();

            }
            else
            {
                MessageBox.Show("Check credentials");
            }
            /*string query = $"INSERT INTO basic(user,pass)" + $"VALUES('{user}'," + $"'{pass}');";
            MySqlCommand command = new MySqlCommand(query, conn);
            int result = command.ExecuteNonQuery();*/
           /* this.Hide();
            Main ss= new Main();
            ss.Show();*/

            
        }

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
