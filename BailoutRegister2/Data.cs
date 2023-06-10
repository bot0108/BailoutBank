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

namespace BailoutRegister2
{
    public class Data
    {
        private MySqlConnection connection;
        private string connectionString = "datasource=ID386628_testing.db.webhosting.be;port=3306;username=ID386628_testing;password=Qcass2203!;database=ID386628_testing;";
        public void Initialize()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }
        public int RegisterValidator(string email)
        {
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

            string query = $"INSERT INTO users (firstname, lastname, email, password, dob, gender_id) VALUES (@Firstname, @Lastname, @Email, @Password, @Dob, @Gender_id);";
            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@Firstname", firstname);
            command.Parameters.AddWithValue("@Lastname", lastname);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@Dob", dob);
            command.Parameters.AddWithValue("@Gender_id", gender_id);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected != 1)
            {
                return 2;
            }

            return 0;
        }
        public bool Updater(string email, string password, string firstname, string lastname, DateTime dob, int gender_id,int user_id)
        {
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
            string query = "UPDATE users set password=@Newpassword WHERE email = @Email";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Newpassword", newpassword);
            try {
                int result = command.ExecuteNonQuery();
                return true;

            }
            catch(Exception ex) { Console.WriteLine(ex.Message); return false; }

        }
        

        public bool setInactive(string email,string status)
        {
            string query = "UPDATE users set act=@Status WHERE email=@Email";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Status", status);
            try
            {
                int result = command.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
        }
        public bool setInactiveID(int id)
        {
            string query = "UPDATE users set act=0 WHERE user_id=@ID";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", id);
            try
            {
                int result = command.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
        }


        public bool Insert(Dictionary<string, object> parameters, string table)
        {

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
            catch
            {
                return false;
            }
        }


        public string GetData(string query)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                string info = command.ExecuteScalar()?.ToString();
                return info;
            }
            catch (Exception ex)
            {
                Console.WriteLine("MySQL Exception: " + ex.Message);
                return "";
            }
        }

    }
}
