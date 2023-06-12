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
    public partial class Change : Form
    {
        private Data data;
        public Change(Data data)
        {
            this.data = data;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==textBox2.Text)
            {
                data.UpdatePass(textBox3.Text, textBox1.Text.ToString());
                if (data.UpdatePass(textBox3.Text, textBox1.Text.ToString()) == true)
                {
                    MessageBox.Show("Password changed successfully!");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Try again!");
                }
            }
            else
            {
                MessageBox.Show("The passwords are not matching!");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
