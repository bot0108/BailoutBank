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
    public partial class Create : Form
    {
        private User user;
        public Create(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (accname.Text == "")
            {
                MessageBox.Show("Add a name, dummy");
            }
            else if (checkBox1.Checked || checkBox2.Checked)
            {
                if (checkBox1.Checked)
                {
                    int typ = 1;
                    if (user.CreateAccount(accname.Text, typ))
                    {
                        MessageBox.Show("Account made");
                    }
                    else
                    {
                        MessageBox.Show("it's like YOU ARE THE PROBLEM");
                    }
                }
                else
                {
                    int typ = 2;
                    if (user.CreateAccount(accname.Text, typ))
                    {
                        MessageBox.Show("Account made");
                    }
                    else
                    {
                        MessageBox.Show("it's like YOU ARE THE PROBLEM");
                    }
                }

            }
            else
            {
                MessageBox.Show("Add a type, dummy");
            }
        }
    }
}
