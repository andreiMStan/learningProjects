namespace HooBooApp
{
 public class PremiumAccount : SubscriptionAccount

 {
  public int pointsEarned { get; set; }
  public double costPerTransactionAfterLimit { get; set; }

  public PremiumAccount(string profileId, string customerName, int freeDeliveriesRemaining, double transactionAmountToDate,
      double annualFee, int freeDeliveriesLimit, double costPerTransactionAfterLimit, int pointsEarned) :
      base(profileId, customerName, freeDeliveriesRemaining, transactionAmountToDate, annualFee, freeDeliveriesLimit)
  {
   this.costPerTransactionAfterLimit = costPerTransactionAfterLimit;
   this.pointsEarned = pointsEarned;
  }

  public override void processTransaction(double transactionAmount)
  {
   if (freeDeliveriesRemaining > 0)
   {
    freeDeliveriesRemaining--;
   }
    this.pointsEarned = Convert.ToInt32(transactionAmountToDate / 10);
    this.transactionAmountToDate += transactionAmount + costDelivery;

   Console.WriteLine($"" +
    $"\nFree Deliveries Remaining:{freeDeliveriesRemaining}" +
  $"\nDelivery Fees:${costDelivery.ToString("F2")}" +
  $"\nCurrent Transaction Amount(including Fee):${(transactionAmount + costDelivery).ToString("F2")}" +
  $"\nTotal Transaction Amount To Date:${this.transactionAmountToDate.ToString("F2")}\n"+
  $"\nPoints Earned{this.pointsEarned}");
  }
  public override void printAccount()
  {
   Console.WriteLine("\nPremium Account");
   Console.WriteLine("----------------");
   base.printAccount();
   Console.WriteLine("Points Earned:" +this.pointsEarned );
   Console.WriteLine("Annual fees:$" + this.annualFee.ToString("F2") + "\n");
  }
  double costDelivery = 0;
  public override void transactionCost(double transactionAmount)
  {
   if (freeDeliveriesRemaining > 0)
   {
    costDelivery = 0;
   }
   else
   {
    costDelivery = transactionAmount * costPerTransactionAfterLimit / 100;
   }
   Console.WriteLine("\nCost of delivery per transaction:$" + costDelivery.ToString("F2") + "\n");

  

  }
 }
}
