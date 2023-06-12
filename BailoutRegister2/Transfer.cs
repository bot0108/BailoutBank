using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BailoutRegister2
{
    public partial class Transfer : Form
    {
        User user;
        Main main;
        public Transfer(User user, Main main)
        {
            InitializeComponent();
            this.user = user;
            this.main = main;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((from.Text == "")|| (to.Text == ""))
            {
                
            }
            else if ((from.Text.Split(':')[0].Split('#')[1] == to.Text.Split('#')[1])||(Convert.ToDecimal(money.Text) < 0))
            {
                MessageBox.Show("Check the input!");
            }
            else if (autotransactionbox.Checked)
            {
                try
                {
                    int accountId = Convert.ToInt32(from.Text.Split(':')[0].Split('#')[1]);
                    int person = Convert.ToInt32(to.Text.Split('#')[1]);
                    decimal amount = Convert.ToDecimal(money.Text);
                    DateTime start = start_dob.Value.Date;
                    DateTime end = end_dob.Value.Date;
                    string frequency = freque.Text;
                    Account account = new Account(accountId);
                    if (account.Balance < Convert.ToDecimal(money.Text))
                    {
                        MessageBox.Show("Not enough money on account");
                    }
                    else
                    {
                        Account acc = new Account(person);
                        if (acc.IsActive())
                        {
                            account.MakeAutoTransaction(person, amount, start, end, frequency);
                            MessageBox.Show("AutoTransaction was created");
                            main.Hide();
                            Main main1 = new Main(user);
                            main1.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Check the input!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Check the input!");
                }
                
            }
            else 
            {
                try
                {
                    decimal amount = Convert.ToDecimal(money.Text);
                    int accountId = Convert.ToInt32(from.Text.Split(':')[0].Split('#')[1]);
                    Account account = new Account(accountId);
                    if (account.Balance < Convert.ToDecimal(money.Text))
                    {
                        MessageBox.Show("Not enough money on account");
                    }
                    else
                    {
                        Account accc = new Account(Convert.ToInt32(to.Text.Split('#')[1]));
                        if (accc.IsActive())
                        {
                            account.MakeTransaction(Convert.ToInt32(to.Text.Split('#')[1]), Convert.ToDecimal(money.Text), message.Text);
                            MessageBox.Show("Transaction was successful");
                            main.Hide();
                            Main main1 = new Main(user);
                            main1.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Check the input!");
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Check the input!");
                }
            }            
        }

        private void Transfer_Load(object sender, EventArgs e)
        {
            Dictionary<int, List<object>> accs = user.GetAccountData();
            foreach (KeyValuePair<int, List<object>> account in accs)
            {
                int accountId = account.Key;
                List<object> accountInfo = account.Value;
                string accountNumber = (string)accountInfo[0];
                decimal balance = Convert.ToDecimal(accountInfo[1]);
                from.Items.Add($"{accountNumber}#{accountId} : {balance}$");
            }
        }
    }
}
