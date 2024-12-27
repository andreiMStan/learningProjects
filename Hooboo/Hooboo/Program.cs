using System.Collections.Generic;
using System.Security.AccessControl;

namespace HooBooApp
{
 public class Program
 {
  static void Main(string[] args)
  {
   List<Account> customersAccounts = new List<Account>();

   string? profileId;
   double amount;
   Console.WriteLine($"** Welcome to HooBoo **");

   int option = 0;
   do
   {
    displayMenu();
    
    option = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(option);
    Console.WriteLine();
    
    switch (option)
    {
     case 1:
      {
       setUpAccounts();
       break;
      }
     case 2:
      {
       displayAccounts();
       break;
      }

     case 3:
      {
       Console.WriteLine("Input Account to be searched for:");
       profileId = Console.ReadLine();
       Account acc = searchAccountById(profileId);
       if (acc==null)
       {
        Console.WriteLine("\nAccount has not been found\n");
        break;
       }
       
       acc.printAccount();
       break;
      }

     case 4:
      {
       Console.WriteLine("Input Account to be deleted:");
       profileId = Console.ReadLine();
       deleteAccount(profileId);
       break;
      }

     case 5:
      {
       Console.WriteLine("Input Account :");
       profileId = Console.ReadLine();
       Console.WriteLine("Input Amount :");
       amount = Convert.ToDouble(Console.ReadLine());
       processTransaction(profileId, amount);

       break;
      }

     case 6:
      {
       displayAccountBreakdown();
       break;
      }

     case 7:
      Console.WriteLine("Thank you for using our service");
      break;

     default:
      {
       Console.WriteLine("option not implemented");
       break;
      }
    }

   } while (option != 7);
   
   void displayAccounts()
   {
    foreach (Account acc in customersAccounts)
    {
     acc.printAccount();
    }
   }
   Account searchAccountById(string profileId)
   {
    
    foreach (Account acc in customersAccounts)
    {
     if (acc.profileId.Equals(profileId))
     {

      return acc;
     }
     
    }
    return null;
   }
   void deleteAccount(string profileId)
   {
    Account? accountToBeDeleted = null;
    accountToBeDeleted = searchAccountById(profileId);
    if (accountToBeDeleted==null)
    {
     Console.WriteLine("\nAccount has not been found\n");
     return;
    }
    Console.WriteLine("\nAccount has been deleted\n");
    customersAccounts.Remove(accountToBeDeleted);
   }
   void processTransaction(string profileId, double amount)
   {
    Account accountToBeProcessed = searchAccountById(profileId);
    if (accountToBeProcessed == null)
    {
     Console.WriteLine("\nAccount not found\n ");
     return;
    }
    String accountType = accountToBeProcessed.GetType().Name;

    switch (accountType)
    {
     case "StandardAccount":
      accountToBeProcessed.transactionCost(amount);
      process(accountToBeProcessed);
      break;

     case "PremiumAccount":
      accountToBeProcessed.transactionCost(amount);
      process(accountToBeProcessed);
      break;

     case "PlusAccount":
      accountToBeProcessed.transactionCost(amount);
      process(accountToBeProcessed);
      break;
     default:
      break;
    }

   }
   void displayAccountBreakdown()
   {
    double totalAccounts = customersAccounts.Count;
    int stdAccounts = 0;
    double stdAccountsTransactions = 0;
    int plusAccounts = 0;
    double plusAccountsTransactions = 0;
    int premAccounts = 0;
    double premAccountsTransactions = 0;
    int otherAccounts = 0;
    foreach (Account account in customersAccounts)
    {
     String accountType = account.GetType().Name;

     switch (accountType)
     {
      case "StandardAccount":
       stdAccounts++;
       stdAccountsTransactions += account.transactionAmountToDate;
       break;

      case "PremiumAccount":
       premAccounts++;
       premAccountsTransactions += account.transactionAmountToDate;
       break;

      case "PlusAccount":
       plusAccounts++;
       plusAccountsTransactions += account.transactionAmountToDate;
       break;

      default:
       otherAccounts++;
       break;
     }

     
    }
    Console.WriteLine($"Management Report \n" +
      $"-------------------------------------\n" +
      $"1.Total Number of Accounts: \n" +
      $"-------------------------------------\n" +
      $"*Standard Accounts:{stdAccounts}\n" +
      $"*Plus Accounts:{plusAccounts}\n" +
      $"*Premium Accounts:{premAccounts}\n" +
      $"\n" +
      $"-------------------------------------\n" +
      $"Percentage Breakdown by Account Type:\n" +
      $"-------------------------------------\n" +
      $"Standard Accounts: {stdAccounts / totalAccounts * 100}%\n" +
      $"Plus Accounts: {plusAccounts / totalAccounts * 100}%\n" +
      $"Premium Accounts: {premAccounts / totalAccounts * 100}%\n" +
      $"-------------------------------------\n" +
      $"\nTotal Transaction Amounts:\n" +
      $"-------------------------------------\n" +
      $"Standard Accounts: ${stdAccountsTransactions.ToString("F2")}\n" +
      $"Plus Accounts: ${plusAccountsTransactions.ToString("F2")}\n" +
      $"Premium Accounts: ${premAccountsTransactions.ToString("F2")}\n" +
      $"-------------------------------------\n" +
      $"Total Transactions Amount: ${(stdAccountsTransactions + plusAccountsTransactions + premAccountsTransactions).ToString("F2")}"+
      $"\n------------------------------------");


   }
   void setUpAccounts()
   {
    StandardAccount s1 = new StandardAccount
        ("001", "Alice Smith", 0, 200.00);
    StandardAccount s2 = new StandardAccount
        ("004", "Dana Lee", 2, 1200.00);
    StandardAccount s3 = new StandardAccount
        ("008", "Hannah Wright", 0, 50.00);

    PlusAccount p1 = new PlusAccount
        ("002", "Bob Jahnson", 0, 500.00, 30.00, 50, 4.0);
    PlusAccount p2 = new PlusAccount
      ("006", "Fiona Carter", 0, 800.00, 30.00, 50, 4.0);
    PlusAccount p3 = new PlusAccount
      ("009", "Ian Thompson", 0, 200.00, 30.00, 50, 4.0);

    PremiumAccount pr1 = new PremiumAccount
         ("003", "Charlie Evans", 0, 1500.00, 100.00, 100, 2.0, 150);
    PremiumAccount pr2 = new PremiumAccount
         ("005", "Ethan Walker", 0, 2500.00, 100.00, 100, 2.0, 250);
    PremiumAccount pr3 = new PremiumAccount
         ("007", "George Harris", 100, 100.00, 100.00, 100, 2.0, 10);
    PremiumAccount pr4 = new PremiumAccount
         ("010", "Jack Foster", 50, 3000.00, 100.00, 100, 2.0, 300);


    customersAccounts.Add(s1);
    customersAccounts.Add(s2);
    customersAccounts.Add(s3);
    customersAccounts.Add(p1);
    customersAccounts.Add(p2);
    customersAccounts.Add(p3);
    customersAccounts.Add(pr1);
    customersAccounts.Add(pr2);
    customersAccounts.Add(pr3);
    customersAccounts.Add(pr4);
    Console.WriteLine("Accounts has been set up \n");


   }
   void process(Account account)
   {
    string answer = "";
    Console.WriteLine("Do you wish to proceed with the transaction Y or N");
    answer = Console.ReadLine().ToUpper();

    if (answer == "Y")
    {
     Console.WriteLine("\nTransaction Processed");
     account.processTransaction(amount);
    // account.printAccount();
    }
    else
    {
     return;
    }
   }
   void displayMenu()
   {
    Console.WriteLine($"_____________________________");
    Console.WriteLine($"| 1.Create Accounts          |");
    Console.WriteLine($"| 2.Show All Account Details |");
    Console.WriteLine($"| 3.Display account by ID    |");
    Console.WriteLine($"| 4.Delete Account           |");
    Console.WriteLine($"| 5.Process Transaction      |");
    Console.WriteLine($"| 6.Display Account Breakdown|");
    Console.WriteLine($"| 7.Exit                     |");
    Console.WriteLine($"|____________________________|");

   }
  }
 }
}
