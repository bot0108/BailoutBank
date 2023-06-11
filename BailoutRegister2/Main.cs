using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BailoutRegister2
{
    public partial class Main : Form
    {
        private Data data;
        private User user;
        private Account account;
        private string username;
        private string balance;
        private Account account;
        private Dictionary<int, List<object>> accountData;
        public Main(Data data, User user, Account acc = null)
            this.account = acc;
     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginform = new Login(data);
            loginform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings settingsform = new Settings(data, user);
            settingsform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Create createrform = new Create(user);
            createrform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Loans loaner = new Loans(data);
            loaner.Show();
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MySqlConnection conn;
            string connectionString = "datasource=ID386628_testing.db.webhosting.be;port=3306;username=ID386628_testing;password=Qcass2203!;database=ID386628_testing;";
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();

                // Check if the image already exists in the database
                MySqlCommand checkCommand = new MySqlCommand("SELECT COUNT(*) FROM images", conn);
                int imageCount = (int)checkCommand.ExecuteNonQuery();
                if (imageCount > 0)
                {
                    // Retrieve the image data from the database
                    MySqlCommand retrieveCommand = new MySqlCommand("SELECT image FROM images", conn);
                    byte[] imageData = (byte[])retrieveCommand.ExecuteScalar();

                    // Load the image from the byte array
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        //pictureBox3.Image = Image.FromStream(ms);
                        pictureBox3.Image = new Bitmap(Image.FromStream(ms));
                    }
                }
                else
                {
                    // No image found in the database
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedImagePath = openFileDialog.FileName;

                        // Load the selected image into the PictureBox
                        pictureBox3.Image = new Bitmap(selectedImagePath);

                        // Save the image to the database
                        byte[] imageData;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureBox3.Image.Save(ms, pictureBox3.Image.RawFormat);
                            imageData = ms.ToArray();
                        }

                        MySqlCommand insertCommand = new MySqlCommand("INSERT INTO images (image) VALUES (@ImageData)", conn);
                        insertCommand.Parameters.AddWithValue("@ImageData", imageData);
                        insertCommand.ExecuteNonQuery();
                    }
                }

            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            username = user.UserName();
            if (account == null)
            {
                balance = user.GetBalance();
            }
            else
            {
                balance = account.GetBalance();
            }
            
            UserNameB.Text = username;
            UserNameBox.Text = username;
            BalanceBox.Text = balance;

            accountData = user.GetAccountData();

            accountPanel.FlowDirection = FlowDirection.TopDown;
            accountPanel.WrapContents = false;
            accountPanel.AutoScroll = true;

            foreach (KeyValuePair<int, List<object>> account in accountData)
            {
                int accountId = account.Key;
                List<object> accountInfo = account.Value;
                string accountNumber = (string)accountInfo[0];
                decimal balance = Convert.ToDecimal(accountInfo[1]);
               
                Button button = new Button();
                button.Text = $"{accountNumber}#{accountId} : {balance}";
                button.Name = $"btnAccount_{accountId}";
                button.Tag = accountId;

                button.Click += Button_Click;

                // Add the button to the panel or any other container
                accountPanel.Controls.Add(button);
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            // Handle button click event
            Button clickedButton = (Button)sender;
            int accountId = (int)clickedButton.Tag;
            Account acc = new Account(accountId, data);
            Main main = new Main(data, user, acc);
            this.Hide();
            main.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Transfer transferform = new Transfer(user, data);
            transferform.Show();
        }
    }
}
