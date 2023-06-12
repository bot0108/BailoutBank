using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BailoutRegister2
{
    public partial class Admin : Form
    {
        public Data data = new Data();
        public Admin()
        {
            InitializeComponent();
            data.Initialize();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=ID386628_testing.db.webhosting.be;port=3306;username=ID386628_testing;password=Qcass2203!;database=ID386628_testing;");

            string query = "SELECT * FROM users";

            using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, con))
            {

                DataSet dset = new DataSet();

                adpt.Fill(dset);

                dataGridView1.DataSource = dset.Tables[0];

            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (ider.Text=="")
            {
                MessageBox.Show("Please fill out the ID field!");
            }
            else
            {
            data.setInactiveID(Convert.ToInt32(ider.Text));
                MessageBox.Show("Account deleted successfully!");
            }

        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            data.Register(textBox1.Text,textBox4.Text,textBox2.Text,textBox3.Text, dateTimePicker1.Value,Convert.ToInt32(textBox5.Text));
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            try
            {
                data.Updater(textBox1.Text, textBox4.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Value, Convert.ToInt32(textBox5.Text), Convert.ToInt32(ider.Text));

            }
            catch (Exception)
            {
                MessageBox.Show("Please fill out each field");
                return;
            }
        }

        
    }
    }

