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
    
    public partial class Terminate : Form
    {
        private Data data;
        private Main main;
        public Terminate(Data data, Main main)
        {
            InitializeComponent();
            this.data = data;
            this.main = main;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (data.setInactive(Login.logMail,"0")==true)
            {
                MessageBox.Show("Account deleted successfully!");
                this.Close();
                main.Close();
                Login loginpage = new Login(data);
                loginpage.Show();
            }
            else
            {
                MessageBox.Show("An error occured");
            }
            
        }
    }
}
