//include bank library
using BankLib;

//Console.WriteLine("Hello, From Bank!");

//create new account
//var account = new BankAccount("Shrey", 1000);
//Console.WriteLine($"Account {account.Number} was created for user {account.Owner} with opening Bal of {account.Balance}");
//var account1 = new BankAccount("Jack", 5000);
//Console.WriteLine($"Account {account1.Number} was created for user {account1.Owner} with opening Bal of {account1.Balance}");

//account.MakeWithdrawal(500, DateTime.Now, "Rent of month");
//Console.WriteLine($" Your account bal is : {account.Balance}");
//account.MakeDeposit(200, DateTime.Now, "Dividend of my stocks recived");
//Console.WriteLine($" Your account bal is : {account.Balance}");

//Test for negative balance
//try
//{
//    account.MakeWithdrawal(100, DateTime.Now, "Attempt to overdraw");
//}
//catch (InvalidOperationException ex)
//{
//    Console.WriteLine("Tryinhg to overdraw!");
//    Console.WriteLine(ex.ToString());
//    return;
//}

//Test initial balance must be positive
//BankAccount invalidAccount;
//try
//{
//    invalidAccount = new BankAccount("Invalid", -55);
//}
//catch (ArgumentOutOfRangeException ex)
//{
//    Console.WriteLine("Exception raised while creating an account!");
//    Console.WriteLine(ex.ToString());
//    return;
//}

//Console.WriteLine(account.GetAccountTransationshistory());

var savings = new IntrestEarnAccount("Saving Account", 10000);
savings.MakeDeposit(750, DateTime.Now, "save some money");
savings.MakeDeposit(1200, DateTime.Now, "Add more savings");
savings.MakeWithdrawal(250, DateTime.Now, "Need to pay bills");
savings.PerformMonthEndTransactions();
Console.WriteLine(savings.GetAccountTransationshistory());



Console.ReadLine();