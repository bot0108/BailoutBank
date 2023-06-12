using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Mail;
using System.Net;

namespace BailoutRegister2
{
    public partial class Login : Form
    {
        private Data data;

        public Login(Data data)
        {
            this.data = data;
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        public static string Code()
        {
            Random random = new Random();
            int randomNumber = random.Next(10000, 100000);
            return randomNumber.ToString();
        }
        public static string globalEmail = "";
        public static string logMail = "";
        public void button1_Click(object sender, EventArgs e)
        {
            int id = data.ValidateLogin(uname.Text, pword.Text);
            if (id != 0)
            {
                logMail = uname.Text.ToString();
                string sendr = "bailoutbank.info@gmail.com";
                string sendrpass = "aulwssemgfugozam";
                string distributedPass = Code();
                globalEmail = distributedPass;

                if (data.IsActive(uname.Text))
                {
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(sendr);
                    message.Subject = "Bailout-Authentication";
                    message.To.Add(new MailAddress($"{uname.Text}"));
                    message.Body = $"<html><body>Your Two Factor authentication code is: {distributedPass}.</body><html>";
                    message.IsBodyHtml = true;

                    var smtpClient = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential(sendr, sendrpass),
                        EnableSsl = true,

                    };
                    smtpClient.Send(message);


                    MessageBox.Show("Login successful!");
                    User user = new User(id);
                    Factor authenticator = new Factor(data, user);
                    authenticator.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Account is inactive!");
                }

            }
            else
            {
                MessageBox.Show("Wrong credentials!");
            }
        }
        private void closer_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Forgotten form2 = new Forgotten(data);
            form2.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Register form3 = new Register(data);
            form3.Show();
        }

        public void uname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



    }
}

