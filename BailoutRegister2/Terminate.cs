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
        private User user;
        public Terminate(Data data, Main main, User user)
        {
            InitializeComponent();
            this.data = data;
            this.main = main;
            this.user = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (data.setInactiveID(user.GetId())==true)
            {
                MessageBox.Show("Account deleted successfully!");
                this.Close();
                main.Close();
                Login loginpage = new Login();
                loginpage.Show();
            }
            else
            {
                MessageBox.Show("An error occured");
            }
            
        }
    }
}
