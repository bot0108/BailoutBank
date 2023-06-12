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
    public partial class Settings : Form
    {
        private Data data;
        private User user;
        private Main main;
        public Settings(Data data, User user, Main main)
        {
            InitializeComponent();
            this.data = data;
            this.user = user;
            this.main = main;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Change pchange = new Change(data);
            pchange.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Terminate terminator = new Terminate(data, main); 
            terminator.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TerminateAcc acc = new TerminateAcc(user, main);
            acc.Show();
            this.Hide();
        }
    }
}
