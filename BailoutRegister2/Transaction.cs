using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BailoutRegister2
{
    public class Transaction
    {
        public int ID { get; set; }
        Data data;
        public Transaction(int id, Data data)
        {
            ID = id;
            this.data = new Data();
            this.data.Initialize();
        }

        public List<string> GetNames()
        {
            List<string> names = new List<string>();
            string query = "SELECT t.*, u1.firstname AS user1_firstname, u1.lastname AS user1_secondname, u2.firstname AS user2_firstname, u2.lastname AS user2_secondname " +
                "FROM transactions t JOIN accounts a1 ON t.account_id = a1.account_id JOIN accounts a2 ON t.person = a2.account_id " +
                "JOIN users u1 ON a1.user_id = u1.user_id JOIN users u2 ON a2.user_id = u2.user_id WHERE t.transaction_id = @Id";
            names = data.GetNames(query, ID);
            return names;
        }

        public List<object> GetTransactionData()
        {
            List<object> transactionData = new List<object>();
            try
            {
                string query = "SELECT * FROM transactions WHERE transaction_id = @Id";
                transactionData = data.GetTransactionData(query, ID);
                return transactionData;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return transactionData;
            }
            

        }
    }
}
