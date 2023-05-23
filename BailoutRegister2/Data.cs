using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

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

        public bool ValidateLogin(string email, string password)
        {
            
            string query = "SELECT COUNT(*) FROM users WHERE email=" + email + " AND password=" + password + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            int count = Convert.ToInt32(command.ExecuteScalar());
            return count > 0;         
        }

        /*public bool Register(string email, string password, string firstname, string lastname, int dob, int gender_id)
        {
                try
                {
                    

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
