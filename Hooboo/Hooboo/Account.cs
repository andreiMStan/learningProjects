using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HooBooApp
{
 public abstract class Account
 {
  public string profileId { get; set; }
  public string customerName { get; set; }

  public int freeDeliveriesRemaining { get; set; }
  public double transactionAmountToDate { get; set; }

  public Account(string profileId, string customerName, int freeDeliveriesRemaining, double transactionAmountToDate)
  {
   this.profileId = profileId;
   this.customerName = customerName;
   this.freeDeliveriesRemaining = freeDeliveriesRemaining;
   this.transactionAmountToDate = transactionAmountToDate;
  }

  public virtual void printAccount()
  {
   Console.WriteLine("Profile Id:" + profileId 
       + "\nCustomer Name:" + customerName +
       "\nFree Deliveries:" + freeDeliveriesRemaining +
       "\nTransaction Amount To Date:$" + transactionAmountToDate.ToString("F2")
       );
  }

  public abstract void processTransaction(double transactionAmount);
  public abstract void transactionCost(double transactionAmount);
 }
}
