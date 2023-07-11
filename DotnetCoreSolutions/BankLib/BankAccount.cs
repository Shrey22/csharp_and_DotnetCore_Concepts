using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLib
{
    //Base class 
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
            //set { }
        }

        private static int AccountNumberSeed = 1234567890;

        private List<Transactions> allTransactions = new List<Transactions>();

        public BankAccount(string owner, decimal initialBalance)
        {
            Number = AccountNumberSeed.ToString();
            AccountNumberSeed++;
            Owner = owner;
            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposits must be positive");
            }
            var deposit = new Transactions(amount, date, note);
            allTransactions.Add(deposit);
        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not Sufficient funds for this withdrwal!");
            }
            var withdrawal = new Transactions(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        //Get history of all transactions
        public string GetAccountTransationshistory()
        {
            var report = new System.Text.StringBuilder();
            decimal balance = 0;
            report.AppendLine("Date\t\t\tAmount\t\tBalance\t\t\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t\t{item.Amount}\t\t{balance}\t\t\t{item.Note}");
            }
            return report.ToString();
        }

        public virtual void PerformMonthEndTransactions() { }

    }


    //Derived Class (Inheritance)
    public class IntrestEarnAccount : BankAccount
    {

        public IntrestEarnAccount(string name,decimal initialBalance) : base(name,initialBalance)
        {

        }

        public override void PerformMonthEndTransactions()
        {
            if(Balance > 500m)   // here m stands for money.
            {
                decimal intrest = Balance * 0.05m;
                MakeDeposit(intrest, DateTime.Now, "Apply Monthly Intrest");
            }
        }
    }
    public class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string name, decimal initialBalance) : base(name, initialBalance)
        {

        }
    }
    public class GiftCardAccount : BankAccount
    {
        public GiftCardAccount(string name, decimal initialBalance) : base(name, initialBalance)
        {

        }
    }
}
