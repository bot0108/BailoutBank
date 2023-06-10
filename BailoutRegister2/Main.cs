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
        private string username;
        private string balance;

        public Main(Data data, User user)
        {

            InitializeComponent();
            this.data = data;
            this.user = user;

            username = user.UserName();
            balance = user.GetBalance();
            UserNameB.Text = username;
            UserNameBox.Text = username;
            BalanceBox.Text = balance;

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

        private void button5_Click(object sender, EventArgs e)
        {
            Transfer transferform = new Transfer();
            transferform.Show();
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
    }
}
