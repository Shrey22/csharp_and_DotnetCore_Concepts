using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLib
{
    //Base Class
    public class Transactions
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Note { get; set; }

        public Transactions(decimal amount, DateTime date, string note)
        {
            Amount = amount;
            Date = date;
            Note = note;
        }
    }
}
