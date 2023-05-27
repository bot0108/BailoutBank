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
    public partial class Factor : Form
    {
        private Data data;
        public Factor(Data data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void Factor_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==Login.asd.ToString())
            {
                Main mainpage = new Main(data);
                mainpage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(Login.asd);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login loginpage = new Login(data);
            loginpage.Show();
            this.Hide();
        }
    }
}
