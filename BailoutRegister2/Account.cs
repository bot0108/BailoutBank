using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BailoutRegister2
{
    public class Account
    {
        private Data data;
        private int AccountId { get; set; }
        public string UserId { get; set; }
        public string AccountName { get; set; }
        public decimal Balance { get; set; }

        public Account(int id, Data data)
        {
            AccountId = id;
            this.data = data;
            UserId = GetUserId();
        }

        public string GetUserId()
        {
            string query = $"SELECT user_id FROM accounts WHERE account_id = {AccountId}";
            string id = data.GetData(query);
            Balance = Convert.ToDecimal(GetBalance());
            return id;
        }
        public string GetBalance()
        {
            try
            {
                string query = $"SELECT money FROM accounts WHERE account_id = {AccountId}";
                string balance = data.GetData(query);
                if (balance == null)
                {
                    balance = "0";
                    return balance;
                }
                else
                {
                    return balance;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "0";
            }
        }

        public void MakeTransaction(string to, decimal amount)
        {
            
            //takes from account works
            decimal newBalance = Balance - amount;
            Dictionary<string, object>  parameters = new Dictionary<string, object>
                {
                    {"account_id", AccountId },
                    {"money", newBalance }
                };
            bool k = data.Update(parameters, "accounts", $"account_id = {AccountId}");


            if (k)
            {
                //gives money
                Account acc = new Account(Convert.ToInt32(to), data);
                newBalance = acc.Balance + amount;
                parameters = new Dictionary<string, object>
                {
                    {"money", newBalance }
                };
                bool l = data.Update(parameters, "accounts", $"account_id = {to}");

                if (l)
                {
                    parameters = new Dictionary<string, object>
                    {
                        {"account_id", AccountId },
                        {"person", to },
                        {"money", amount },
                        {"date", DateTime.Now}
                    };

                    // Pass the table name, and parameters to the database class
                    k = data.Insert(parameters, "transactions");

                    if (!k)
                    {
                        newBalance = Balance + amount;
                        parameters = new Dictionary<string, object>
                        {
                            {"money", newBalance }
                        };
                        k = data.Update(parameters, "accounts", $"account_id = {AccountId}");

                        
                        newBalance = acc.Balance - amount;
                        parameters = new Dictionary<string, object>
                        {
                            {"money", newBalance }
                        };
                        l = data.Update(parameters, "accounts", $"account_id = {to}");
                    }

                }
                else
                {
                    newBalance = Balance + amount;
                    parameters = new Dictionary<string, object>
                    {
                        {"account_id", AccountId },
                        {"money", newBalance }
                    };
                    k = data.Update(parameters, "accounts", $"account_id = {to}");
                }
            }
            
            
            
        }
    }
}
