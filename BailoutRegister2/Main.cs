using System;
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
    public partial class Main : Form
    {
        private Data data;
        private User user;
        public Main(Data data, User user)
        {
            InitializeComponent();
            this.data = data;
            this.user = user;
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
        public void changeLabelText(string text)
        {
            this.label1.Text = text;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            label5.Text = "Boti";
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
    }
}
