using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BailoutRegister2
{
    public partial class Main : Form
    {
        private Data data;
        private User user;
        private string username;
        private string balance;
        private List<int> transactionsid;
        private List<int> accountsid;
        public Main(Data data, User user)
        {
            
            InitializeComponent();
            this.data = data;
            this.user = user;

            username = user.UserName();
            balance = user.GetBalance();
            UserNameB.Text = username;
            UserNameBox.Text = username;
            BalanceBox.Text = balance;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginform = new Login(data);
            loginform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings settingsform = new Settings(data, user );
            settingsform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Create createrform = new Create(user);
            createrform.Show();
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            Loans loaner = new Loans(data);
            loaner.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Transfer transferform = new Transfer();
            transferform.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;

                pictureBox3.Image = new Bitmap(selectedImagePath);
            }
        }
        
    }
}
