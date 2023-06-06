using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BailoutRegister2
{
    public class User
    {
        private Data data;
        public int ID { get; set; }

        public User(int id, Data data)
        {
            ID = id;
            this.data = data;
        }

        public bool CreateAccount(string name, int type)
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

        public string UserName()
        {
            try
            {
                string query = $"SELECT firstname FROM users WHERE user_id={ID}";
                string name = data.GetData(query);
                return name;
            }
            catch
            {
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
            catch
            {
                return "";
            }
        }

        
    }
}
