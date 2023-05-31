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
        public Terminate(Data data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (data.setInactive(Login.globalEmail,"0")==true)
            {
                MessageBox.Show("Account deleted successfully!");
                this.Hide();

                
                Main mainpage = new Main(data);
                mainpage.Hide();
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
