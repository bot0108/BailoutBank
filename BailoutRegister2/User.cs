using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BailoutRegister2
{
    public class User
    {
        private Data data;
        private int ID { get; set; }

        public User(int id, Data data)
        {
            ID = id;
            this.data = data;
            this.data.Initialize();
        }

        public bool CreateAccount(string name, int type)
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                {"user_id", ID },
                {"name", name },
                {"acctype_id", type }
                };

                // Pass the table name, query, and parameters to the database class
                bool k = data.Insert(parameters, "accounts");
                return k;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }

        public string UserName()
        {
            try
            {
                string query = $"SELECT firstname FROM users WHERE user_id={ID}";
                string name = data.GetData(query);
                return name;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }            
        }

        public string GetBalance()
        {
            try
            {
                string query = $"SELECT SUM(money) FROM accounts WHERE user_id = {ID}";
                string balance = data.GetData(query);
                if (balance == "")
                {
                    return "0";
                }
                else
                {
                    return balance;
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
        public int GetId()
        {
            return ID;
        }
        public Dictionary<int, List<object>> GetAccountData()
        {
            Dictionary<int, List<object>> accountData = new Dictionary<int, List<object>>();
            string query = "SELECT account_id, name, money FROM accounts WHERE user_id = @UserId AND act = 1";
            accountData = data.GetAccounts(query, ID);
            return accountData;
        }

        public Dictionary<int, List<object>> GetAccountDataFull()
        {
            Dictionary<int, List<object>> accountData = new Dictionary<int, List<object>>();
            string query = "SELECT account_id, name, money FROM accounts WHERE user_id = @UserId";
            accountData = data.GetAccounts(query, ID);
            return accountData;
        }

        public Dictionary<int, List<object>> GetTransData()
        {
            Dictionary<int, List<object>> transData = new Dictionary<int, List<object>>();
            string query = "SELECT * FROM transactions WHERE account_id IN ( SELECT account_id FROM accounts WHERE user_id = @Id ) OR person IN ( SELECT account_id FROM accounts WHERE user_id = @Id );";

            transData = data.GetTransactions(query, ID);
            return transData;
        }

        public bool UploadPicture(byte[] imageData)
        {
            try
            {
                string table = "users";
                string condition = $"user_id = {ID}";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"picture", imageData }
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public byte[] GetPicture()
        {
            try
            {
                string query = $"SELECT picture FROM users WHERE user_id = {ID}";
                byte[] picture = data.GetImage(query);
                return picture;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
