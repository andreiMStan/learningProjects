using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HooBooApp
{
 public class StandardAccount : Account
 {
  public StandardAccount(string profileId, string customerName, int freeDeliveriesRemaining, double transactionAmountToDate) : base(profileId, customerName, freeDeliveriesRemaining, transactionAmountToDate)
  {

  }
  public override void printAccount()
  {
   Console.WriteLine("\nStandard Account");
   Console.WriteLine("------------------");

   base.printAccount();
   Console.WriteLine();
        }

  public override void processTransaction(double transactionAmount)
  {

   if (freeDeliveriesRemaining > 0)
   {
    freeDeliveriesRemaining--;
   }
    this.transactionAmountToDate += transactionAmount+
    costDelivery;

   Console.WriteLine($"\nFree Deliveries Remaining:{freeDeliveriesRemaining}" +
    $"\nDelivery Fees:{costDelivery.ToString("F2")}" +
    $"\nCurrent Transaction Amount(including Fees):${(transactionAmount + costDelivery).ToString("F2")}" +
    $"\nTotal Transaction Amount To Date:${this.transactionAmountToDate.ToString("F2")}");

  
        }

   double costDelivery = 0.00;
  public override void transactionCost(double transactionAmount)
  {
   if (freeDeliveriesRemaining > 0)
   {
    costDelivery = 0.00;
   }
   else
   {
    costDelivery = transactionAmount * 0.05;
   }
   Console.WriteLine("\nCost of delivery per transaction:$" + costDelivery.ToString("F2") + "\n");
  }
 }
}
