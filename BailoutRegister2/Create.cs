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
        private Main main;
        public Create(User user, Main main)
        {
            InitializeComponent();
            this.user = user;
            this.main = main;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (accname.Text == "")
            {
                MessageBox.Show("Add a name");
            }
            else if (checkBox1.Checked || checkBox2.Checked)
            {
                if (checkBox1.Checked)
                {
                    int typ = 1;
                    if (user.CreateAccount(accname.Text, typ))
                    {
                        MessageBox.Show("Account made");
                        main.Close();
                        Main main1 = new Main(user);
                        main1.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Error occured");
                    }
                }
                else
                {
                    int typ = 2;
                    if (user.CreateAccount(accname.Text, typ))
                    {
                        MessageBox.Show("Account made");
                        main.Close();
                        Main main1 = new Main(user);
                        main1.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Error occured");
                    }
                }

            }
            else
            {
                MessageBox.Show("Choose a type");
            }
        }
    }
}
