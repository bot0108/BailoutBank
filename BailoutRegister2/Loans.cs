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
    public partial class Loans : Form
    {
        private Data data;
        public Loans(Data data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Terms andconditions = new Terms();
            andconditions.Show();
        }

        private void Loans_Load(object sender, EventArgs e)
        {

        }
    }
}
