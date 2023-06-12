using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BailoutRegister2
{
    public class Account
    {
        private Data data = new Data();
        private int AccountId { get; set; }
        public string UserId { get; set; }
        public string AccountName { get; set; }
        public decimal Balance { get; set; }

        public Account(int id)
        {
            AccountId = id;
            data.Initialize();
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

        public void MakeTransaction(int to, decimal amount, string message)
        {
            try
            {
                //takes from account works
                decimal newBalance = Balance - amount;
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"account_id", AccountId },
                    {"money", newBalance }
                };
                bool k = data.Update(parameters, "accounts", $"account_id = {AccountId}");

                if (k)
                {
                    //gives money
                    Account acc = new Account(to);
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
                            {"message", message },
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Dictionary<int, List<object>> GetTransData()
        {
            Dictionary<int, List<object>> transData = new Dictionary<int, List<object>>();
            try
            {
                string query = "SELECT * FROM transactions WHERE person = @Id OR account_id = @Id";
                transData = data.GetTransactions(query, AccountId);
                return transData;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return transData;
            }
            
        }
        public bool DeleteAccount()
        {
            try
            {
                string table = "accounts";
                string condition = $"account_id = {AccountId}";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"act", 0 }
                };
                if (data.Update(parameters, table, condition))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool IsActive()
        {
            string query = $"SELECT act FROM accounts WHERE account_id={AccountId}";
            try
            {
                if (data.AccActive(query))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message); 
                return false; 
            }
        }
        public void MakeAutoTransaction(int person, decimal amount, DateTime start, DateTime end, string frequency)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                            {"account_id", AccountId },
                            {"frequency", frequency },
                            {"money", amount },
                            {"start_date", start},
                            {"end_date", end},
                            {"account_id2", person },
            };
            data.Insert(parameters, "autotrans");
        }
    }
}
