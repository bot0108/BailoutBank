﻿using System;
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
        public Settings(Data data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Change pchange = new Change(data);
            pchange.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Terminate terminator = new Terminate(); 
            terminator.Show();
            this.Hide();
        }
    }
}
