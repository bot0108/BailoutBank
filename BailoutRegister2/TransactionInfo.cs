using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace BailoutRegister2
{
    public partial class TransactionInfo : Form
    {
        Transaction trans;
        List<object> transData;
        List<string> transName;
        public TransactionInfo(Transaction trans)
        {
            InitializeComponent();
            this.trans = trans;
        }

        private void TransactionInfo_Load(object sender, EventArgs e)
        {
            transName = trans.GetNames();
            transData = trans.GetTransactionData();
            this.Text = "Transaction";

            int accountId = (int)transData[0];
            int person = (int)transData[1];
            decimal money = Convert.ToDecimal(transData[2]);
            string message = (string)transData[3];
            DateTime date = (DateTime)transData[4];

            fromname.Text = transName[0];
            fromacc.Text = "#" + Convert.ToString(accountId);

            toname.Text = transName[1];
            toacc.Text = "#" + Convert.ToString(person);

            amount.Text = Convert.ToString(money) + "$";
            messagebox.Text = message;
            datelable.Text = date.Date.ToString("yyyy-MM-dd");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
