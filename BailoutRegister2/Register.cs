using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BailoutRegister2
    
{
    public partial class Register : Form
    {
        private Data data = new Data();
        public Register()
        {
            data.Initialize();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool k = false;
            DateTime now = DateTime.Now;
            int g = 2;
            while (k == false)
            {
                int age = now.Year - dob.Value.Year;
                if (now.Month < dob.Value.Month || (now.Month == dob.Value.Month && now.Day < dob.Value.Day))
                {
                    age--;
                }

                if ((firstname.Text == "") || (conemail.Text == "") || (password.Text == "") || (conpassword.Text == "") || (firstname.Text == "") || (lastname.Text == "") || (gender.Text == ""))
                {
                    MessageBox.Show("Please Fill Everything!");
                    return;
                }
                else if (age < 18)
                {
                    MessageBox.Show("You need to be older then 18!");
                    return;
                }
                else if (data.RegisterValidator(firstname.Text) == 1)
                {
                    MessageBox.Show("This e-mail is already in the system!");
                    return;
                }
                else if (email.Text != conemail.Text)
                {
                    MessageBox.Show("Confirmation E-mail is Wrong!");
                    return;
                }
                else if (password.Text != conpassword.Text)
                {
                    MessageBox.Show("Confirmation Password is Wrong!");
                    return;
                }
                else
                {
                    k = true;
                }
            }

            if (gender.Text == "Female")
            {
                g = 2;
            }
            else
            {
                g = 1;
            }

            if (data.Register(firstname.Text, password.Text, firstname.Text, lastname.Text, dob.Value, g) == 0)
            {
                MessageBox.Show("Account Created!");
                this.Hide();

            }
            else
            {
                MessageBox.Show("Something went wrong!");
            }
        }
    }
}
