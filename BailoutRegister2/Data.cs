using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Collections;
using System.Security.Policy;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Data;

namespace BailoutRegister2
{
    public class Data
    {
        private MySqlConnection connection;
        private string connectionString = "datasource=ID386628_testing.db.webhosting.be;port=3306;username=ID386628_testing;password=Qcass2203!;database=ID386628_testing;";
        public void Initialize()
        {
            connection = new MySqlConnection(connectionString);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            
        }
        public int RegisterValidator(string email)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string query = "SELECT COUNT(*) FROM users WHERE email=@Email;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", email);
            int count = Convert.ToInt32(command.ExecuteScalar());
            if (count > 0)
            {
                return 1;
            }
            return 0;
        }
        public int Register(string email, string password, string firstname, string lastname, DateTime dob, int gender_id)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string query = $"INSERT INTO users (firstname, lastname, email, password, dob, gender_id) VALUES (@Firstname, @Lastname, @Email, @Password, @Dob, @Gender_id);";
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@Firstname", firstname);
                command.Parameters.AddWithValue("@Lastname", lastname);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Dob", dob);
                command.Parameters.AddWithValue("@Gender_id", gender_id);

                int rowsAffected = command.ExecuteNonQuery();
                if ((rowsAffected != 1))
                {
                    return 2;
                }
                return 0;

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 2;
            }
            
        }
        public bool Updater(string email, string password, string firstname, string lastname, DateTime dob, int gender_id, int user_id)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string query = "UPDATE users set firstname=@Firstname, lastname=@Lastname, email=@Email, password=@Password, dob=@Dob, gender_id=@Gender_id,user_id=@User_Id WHERE user_id=@User_Id;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Firstname", firstname);
            command.Parameters.AddWithValue("@Lastname", lastname);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@Dob", dob);
            command.Parameters.AddWithValue("@Gender_id", gender_id);
            command.Parameters.AddWithValue("User_Id", user_id);
            try
            {
                int result = command.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }

        }

        public int ValidateLogin(string email, string password)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string query = "SELECT user_id FROM users WHERE email = @Email AND password = @Password";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = reader.GetInt32("user_id");
                            return userId;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }

            return 0;

        }

        public bool IsActive(string email)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string query = "SELECT act FROM users WHERE email=@Email";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    int count = Convert.ToInt32(result);
                    return count == 1;
                }
            }

            return false;
        }

        public bool UpdatePass(string email, string newpassword)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string query = "UPDATE users set password=@Newpassword WHERE email = @Email";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Newpassword", newpassword);
                try
                {
                    int result = command.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
        }

        public bool setInactiveID(int id)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string query = "UPDATE users set act=0 WHERE user_id=@ID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);
                try
                {
                    int result = command.ExecuteNonQuery();

                    query = "UPDATE accounts set act=0 WHERE user_id=@ID";
                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID", id);

                    result = command.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
            
        }


        public bool Insert(Dictionary<string, object> parameters, string table)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string query = $"INSERT INTO {table} (";

                foreach (string columnName in parameters.Keys)
                {
                    query += columnName + ", ";
                }
                query = query.TrimEnd(',', ' ') + ") VALUES (";

                foreach (string columnName in parameters.Keys)
                {
                    query += "@" + columnName + ", ";
                }
                query = query.TrimEnd(',', ' ') + ")";

                MySqlCommand command = new MySqlCommand(query, connection);

                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.AddWithValue("@" + parameter.Key, parameter.Value);
                }
                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }


        public string GetData(string query)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                MySqlCommand command = new MySqlCommand(query, connection);
                string info = command.ExecuteScalar()?.ToString();
                return info;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Exception: " + ex.Message);
                return "";
            }
        }
        public bool AccActive(string query)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                MySqlCommand command = new MySqlCommand(query, connection);
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    int count = Convert.ToInt32(result);
                    return count == 1;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Exception: " + ex.Message);
                return false;
            }
        }
        public byte[] GetImage(string query)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                MySqlCommand command = new MySqlCommand(query, connection);
                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    return (byte[])result;
                }

                return null;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Exception: " + ex.Message);
                return null;
            }
        }

        public Dictionary<int, List<object>> GetAccounts(string query, int id)
        {
            Dictionary<int, List<object>> accountDict = new Dictionary<int, List<object>>();

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int accountId = reader.GetInt32("account_id");
                        string accountName = reader.GetString("name");
                        int balance = reader.GetInt32("money");

                        List<object> accountInfo = new List<object> { accountName, balance };

                        accountDict.Add(accountId, accountInfo);
                    }

                }
                return accountDict;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return accountDict;
            }

        }

        public Dictionary<int, List<object>> GetTransactions(string query, int id)
        {
            Dictionary<int, List<object>> transDict = new Dictionary<int, List<object>>();

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int transId = reader.GetInt32("transaction_id");
                        int accountId = reader.GetInt32("account_id");
                        int person = reader.GetInt32("person");
                        int money = reader.GetInt32("money");
                        object messageValue = reader["message"];
                        string message = messageValue != DBNull.Value ? (string)messageValue : string.Empty;
                        DateTime date = reader.GetDateTime("date");

                        List<object> transInfo = new List<object> { accountId, person, money, message, date };

                        transDict.Add(transId, transInfo);
                    }

                }

                return transDict;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return transDict;
            }
        }



        public bool Update(Dictionary<string, object> parameters, string table, string condition)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string query = $"UPDATE {table} SET ";

                foreach (string columnName in parameters.Keys)
                {
                    query += $"{columnName}=@{columnName}, ";
                }
                query = query.TrimEnd(',', ' ') + $" WHERE {condition}";

                MySqlCommand command = new MySqlCommand(query, connection);
                
                    foreach (KeyValuePair<string, object> parameter in parameters)
                    {
                        command.Parameters.AddWithValue("@" + parameter.Key, parameter.Value);
                    }
                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("MySQL Exception: " + ex.Message);
                        return false;
                    }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("MySQL Exception: " + ex.Message);
                return false;
            }
        }
        public List<string> GetNames(string query, int id)
        {
            List<string> names = new List<string>();
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        string user1FirstName = reader.GetString("user1_firstname");
                        string user1SecondName = reader.GetString("user1_secondname");
                        string user2FirstName = reader.GetString("user2_firstname");
                        string user2SecondName = reader.GetString("user2_secondname");

                        string user1name = user1FirstName + " " + user1SecondName;
                        string user2name = user2FirstName + " " +  user2SecondName;
                        names.Add(user1name);
                        names.Add(user2name);
                    }

                }

                return names;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return names;
            }
        }
        public List<object> GetTransactionData(string query, int id)
        {
            List<object> transaction = new List<object>();
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int accountId = reader.GetInt32("account_id");
                        int person = reader.GetInt32("person");
                        int money = reader.GetInt32("money");
                        object messageValue = reader["message"];
                        string message = messageValue != DBNull.Value ? (string)messageValue : string.Empty;
                        DateTime date = reader.GetDateTime("date");

                        List<object> transInfo = new List<object> { accountId, person, money, message, date };

                        transaction.Add(accountId);
                        transaction.Add(person);
                        transaction.Add(money);
                        transaction.Add(message);
                        transaction.Add(date);
                    }

                }
                return transaction;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return transaction;
            }
        }

    } 
}

