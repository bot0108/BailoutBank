using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
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

        public bool ValidateLogin(string email, string password)
        {

            string query = "SELECT COUNT(*) FROM users WHERE email = @Email AND password = @Password";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", password);

            int count = Convert.ToInt32(command.ExecuteScalar());
            return count > 0;
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
        public bool TerminateAcc(string email) {
            string query = "";
        }
        

        /*public bool Register(string email, string password, string firstname, string lastname, int dob, int gender_id)
        {
                try
                {
                    connection.Open();

                    // Check if the username already exists

                    string query = "SELECT COUNT(*) FROM users WHERE email=" + email + ";";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        throw new Exception("Username already exists");
                    }

                    // Add the new customer
                    query = $"INSERT INTO users (firstname, lastname, email, password, dob, gender_id) VALUES ({firstname}, {lastname}, {email}, {password}, {dob}, {gender_id})";
                    command = new MySqlCommand(query, connection);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected != 1)
                    {
                        throw new Exception("Error adding customer");
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }*/
    }
}
