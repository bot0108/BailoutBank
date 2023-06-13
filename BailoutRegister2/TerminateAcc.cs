﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BailoutRegister2
{
    public partial class TerminateAcc : Form
    {
        User user;
        Main main;
        Data data;
        List<int> accountIDs = new List<int>();
        public TerminateAcc(User user, Main main, Data data)
        {
            this.data = data;
            InitializeComponent();
            this.user = user;
            this.main = main;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (accounts.Text != "")
                {
                    Account acc = new Account(Convert.ToInt32(accounts.Text.Split('#')[1]), data);
                    if((accountIDs.Count == 1) & (acc.Balance != 0))
                    {
                        MessageBox.Show("Sorry, you have only one account,\nwe cannot transfer your money to any other account.\nIf you want to terminate your bank user,\nplease go to Terminate user");
                        this.Hide();
                    }
                    else
                    {
                        
                        foreach (int accountI in accountIDs)
                        {
                            if (accountI != Convert.ToInt32(accounts.Text.Split('#')[1]))
                            {
                                if(acc.Balance > 0)
                                {
                                    acc.MakeTransaction(accountI, acc.Balance, "Termination of the account");
                                }
                                break;
                            }
                        }

                        acc.DeleteAccount();
                        MessageBox.Show("Account terminated");
                        main.Close();

                        Main main1 = new Main(user);
                        main1.Show();
                        this.Close();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Please Pick the account");
                }

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error occured");
            }
            
        }

        private void TerminateAcc_Load(object sender, EventArgs e)
        {
            Dictionary<int, List<object>> accs = user.GetAccountData();
            foreach (KeyValuePair<int, List<object>> account in accs)
            {

                int accountId = account.Key;
                
                List<object> accountInfo = account.Value;
                string accountName = (string)accountInfo[0];
                accounts.Items.Add($"{accountName}#{accountId}");
                accountIDs.Add(accountId);
            }
        }
    }
}
