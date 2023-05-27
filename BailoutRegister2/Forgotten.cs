using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BailoutRegister2
{
    public partial class Forgotten : Form
    {
        private Data data;
        public Forgotten(Data data)
        {
            this.data = data;   
            InitializeComponent();
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private string NewPass()
        {
            Random random = new Random();
            int randomNumber = random.Next(10000, 100000);
            return randomNumber.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sendr = "bailoutbank.info@gmail.com";
            string sendrpass = "aulwssemgfugozam";
            string distributedPass = NewPass();

            if (data.RegisterValidator(textBox1.Text) == 1)
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(sendr);
                message.Subject = "Bailout-New Password";
                message.To.Add(new MailAddress($"{textBox1.Text}"));
                message.Body = $"<html><body>Your new Password is: {distributedPass}.\n You can change it under the Change Password section.</body><html>";
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(sendr, sendrpass),
                    EnableSsl = true,

                };
                smtpClient.Send(message);
                data.UpdatePass(textBox1.Text, distributedPass);
                if (data.UpdatePass(textBox1.Text, distributedPass) == true){
                    MessageBox.Show("Proceed to your email account!");

                }

                this.Hide();

            }
            else
            {
                MessageBox.Show("Please register an account first!");
            }
                    
            
        }
    }
}
