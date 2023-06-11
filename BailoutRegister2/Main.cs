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
    public partial class Main : Form
    {
        private Data data;
        private User user;
        private Account account;
        private string username;
        private string balance;
        private Dictionary<int, List<object>> accountData;
        public Main(Data data, User user, Account acc = null)
        {
            InitializeComponent();
            this.data = data;
            this.user = user;
            this.account = acc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginform = new Login(data);
            loginform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings settingsform = new Settings(data, user );
            settingsform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Create createrform = new Create(user);
            createrform.Show();
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            Loans loaner = new Loans(data);
            loaner.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Transfer transferform = new Transfer(user, data);
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
            BalanceBox.Text = balance;

            accountData = user.GetAccountData();

            accountPanel.FlowDirection = FlowDirection.TopDown;
            accountPanel.WrapContents = false;
            accountPanel.AutoScroll = true;

            foreach (KeyValuePair<int, List<object>> account in accountData)
            {
                int accountId = account.Key;
                List<object> accountInfo = account.Value;
                string accountNumber = (string)accountInfo[0];
                decimal balance = Convert.ToDecimal(accountInfo[1]);
               
                Button button = new Button();
                button.Text = $"{accountNumber}#{accountId} : {balance}";
                button.Name = $"btnAccount_{accountId}";
                button.Tag = accountId;

                button.Click += Button_Click;

                // Add the button to the panel or any other container
                accountPanel.Controls.Add(button);
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            // Handle button click event
            Button clickedButton = (Button)sender;
            int accountId = (int)clickedButton.Tag;
            Account acc = new Account(accountId, data);
            Main main = new Main(data, user, acc);
            this.Hide();
            main.Show();
        }
    }
}
