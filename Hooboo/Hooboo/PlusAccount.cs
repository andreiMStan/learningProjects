using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HooBooApp
{
 public class PlusAccount : SubscriptionAccount
 {

  public double costPerTransactionAfterLimit { get; set; }

  public PlusAccount(string profileId, string customerName, int freeDeliveriesRemaining, double transactionAmountToDate, double annualFee, int freeDeliveriesLimit, double costPerTransactionAfterLimit) : 
   base(profileId, customerName, freeDeliveriesRemaining, transactionAmountToDate, annualFee, freeDeliveriesLimit)
  {
   this.costPerTransactionAfterLimit = costPerTransactionAfterLimit;
  }
  public override void printAccount()
  {
   Console.WriteLine("\nPlus Account ");
   Console.WriteLine("---------------");
   base.printAccount();
   Console.WriteLine("Annual fees:$"+this.annualFee.ToString("F2"));
   }
  
  public override void processTransaction(double transactionAmount)
  {
   if (freeDeliveriesRemaining > 0)
   {
    freeDeliveriesRemaining--;
   }
    this.transactionAmountToDate += transactionAmount+costDelivery;
   
   Console.WriteLine($"" +
    $"\nFree Deliveries Remaining:{freeDeliveriesRemaining}" 
    +$"\nDelivery Fees for this transaction:${costDelivery}" +
     $"\nCurrent Transaction Amount(including Fees)$:{(transactionAmount + costDelivery).ToString("F2")}" +
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
    costDelivery = transactionAmount * costPerTransactionAfterLimit /100;
   }
   Console.WriteLine("\nCost of delivery per transaction:$" + costDelivery + "\n");


  }
 }
}
