using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BailoutRegister2
{
    public partial class Main : Form
    {
        private Data data;
        private User user;
        private Account account;
        private string username;
        private string balance;
        private Dictionary<int, List<object>> accountData;
        private Dictionary<int, List<object>> transData;
        private bool acco = false;
        private byte[] picture;
        public Main(Data data, User user, Account acc = null) 
        { 
            InitializeComponent();
            this.data = data;
            this.user = user;
            if (acc == null)
            {
                acco = true;
            }
            else
            {
                this.account = acc;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginform = new Login(data);
            loginform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings settingsform = new Settings(data, user, this);
            settingsform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Create createrform = new Create(user);
            createrform.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox3.Image = new Bitmap(openFileDialog.FileName);

                    byte[] imageData;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBox3.Image.Save(ms, pictureBox3.Image.RawFormat);
                        imageData = ms.ToArray();
                    }
                    if (user.UploadPicture(imageData))
                    {
                        MessageBox.Show("Picture updated");
                    }
                    else
                    {
                        MessageBox.Show("Error occured");
                    }
                }
                catch
                {
                    MessageBox.Show("Error occured");
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Transfer transferform = new Transfer(user);
            transferform.Show();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            username = user.UserName();
            if (account == null)
            {
                balance = user.GetBalance();
            }
            else
            {
                balance = account.GetBalance();
            }
            
            UserNameB.Text = username;
            UserNameBox.Text = username;
            BalanceBox.Text = balance + "$";

            picture = user.GetPicture();

            if (picture != null)
            {
                using (MemoryStream ms = new MemoryStream(picture))
                {
                    pictureBox3.Image = new Bitmap(ms);
                }
            }



            accountData = user.GetAccountData();

            accountPanel.FlowDirection = FlowDirection.TopDown;
            accountPanel.WrapContents = false;
            accountPanel.AutoScroll = true;
            int k = accountPanel.ClientSize.Width;
            if (accountData.Count > 6)
            {
                k = accountPanel.Width - SystemInformation.VerticalScrollBarWidth - 7;
            }
            foreach (KeyValuePair<int, List<object>> account in accountData)
            {
                int accountId = account.Key;
                List<object> accountInfo = account.Value;
                string accountNumber = (string)accountInfo[0];
                decimal balance = Convert.ToDecimal(accountInfo[1]);
               
                Button button = new Button();

                button.AutoSize = false;
                button.Width = accountPanel.Width - SystemInformation.VerticalScrollBarWidth - 7;
                

                button.Text = $"{accountNumber}#{accountId} : {balance}$";
                button.Name = $"btnAccount_{accountId}";
                button.Tag = accountId;

                button.Click += Button_Click;

                // Add the button to the panel or any other container
                accountPanel.Controls.Add(button);
            }

            if (acco)
            {
                transData = user.GetTransData();
            }
            else
            {
                transData = account.GetTransData();
            }
            //Sort the transactions by date
            
            var sortedTransactions = transData.OrderBy(t => ((DateTime)t.Value[4]));

                try
                {
                    transpanel.FlowDirection = FlowDirection.TopDown;
                    transpanel.AutoScroll = true;
                    transpanel.Margin = new Padding(10);
                    foreach (var transaction in sortedTransactions)
                    {

                        int transactionId = (int)transaction.Key;
                        int accountId = (int)transaction.Value[0];
                        int person = (int)transaction.Value[1];
                        decimal money = Convert.ToDecimal(transaction.Value[2]);
                        string message = (string)transaction.Value[3];
                        DateTime date = (DateTime)transaction.Value[4];

                        Button button = new Button();

                        button.AutoSize = false;
                        button.Width = transpanel.Width - SystemInformation.VerticalScrollBarWidth - 7;

                        Transaction trans = new Transaction(transactionId);
                        List<string> names = trans.GetNames();
                        if (accountData.Keys.Contains(accountId) & accountData.Keys.Contains(person))
                        {
                            button.Text = $"From: {accountData[accountId][0]}#{accountId}    To: {accountData[person][0]}#{person}    Amount: {money}$";
                        }
                        else
                        {
                            if (accountData.Keys.Contains(accountId))
                            {
                                button.Text = $"To: {names[1]}      Account: -{money}$";
                            }
                            else
                            {
                                button.Text = $"From: {names[0]}      Account: +{money}$";
                            }
                        }

                        button.Tag = transactionId; // Store the account ID in the Tag property of the button
                        button.Click += Button_Click2; // Attach the event handler

                        transpanel.Controls.Add(button);

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            
            
            
        }
        private void Button_Click(object sender, EventArgs e)
        {
            // Handle button click event
            Button clickedButton = (Button)sender;
            int accountId = (int)clickedButton.Tag;
            Account acc = new Account(accountId);
            Main main = new Main(data, user, acc);
            this.Hide();
            main.Show();
        }
        private void Button_Click2(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int transactionId = (int)clickedButton.Tag;
            Transaction transaction = new Transaction(transactionId);
            TransactionInfo trans = new TransactionInfo(transaction);
            trans.Show();
        }

        private void UserNameB_Click(object sender, EventArgs e)
        {
            Main main = new Main(data, user);
            main.Show();
            this.Hide();

        }

        private void UserNameBox_Click(object sender, EventArgs e)
        {
            Main main = new Main(data, user);
            main.Show();
            this.Hide();
        }
    }
}
