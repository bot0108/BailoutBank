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
        public Main(Data data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginform = new Login(data);
            loginform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings settingsform = new Settings(data);
            settingsform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Create createrform = new Create();
            createrform.Show();
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
