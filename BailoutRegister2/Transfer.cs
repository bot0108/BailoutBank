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
        Data data;
        public Transfer(User user, Data data)
        {
            InitializeComponent();
            this.user = user;
            this.data = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((from.Text == "")|| (to.Text == ""))
            {
                
            }
            else 
            {
                try
                {
                    decimal amount = Convert.ToDecimal(money.Text);
                    if (amount <= 0)
                    {
                        MessageBox.Show("Check the input!");
                    }
                    else
                    {
                        try
                        {
                            int accountId = Convert.ToInt32(from.Text.Split(':')[0].Split('#')[1]);
                            Account account = new Account(accountId, data);
                            if (account.Balance < Convert.ToDecimal(money.Text))
                            {
                                MessageBox.Show("Not enough money on account");
                            }
                            else
                            {
                                account.MakeTransaction(to.Text.Split('#')[1], Convert.ToDecimal(money.Text));
                                Main main = new Main(data,user);
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Check the input! something wrong");
                        }

                    }
                }
                catch
                {
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
                from.Items.Add($"{accountNumber}#{accountId}:{balance}");
            }
        }
    }
}
