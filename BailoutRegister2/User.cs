using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
