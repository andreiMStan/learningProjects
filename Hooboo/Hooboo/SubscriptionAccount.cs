using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HooBooApp
{
 public abstract class SubscriptionAccount : Account
 {
  public double annualFee { get; set; }
  public int freeDeliveriesLimit { get; set; }
  public SubscriptionAccount(string profileId, string customerName, int freeDeliveriesRemaining,
      double transactionAmountToDate, double annualFee, int freeDeliveriesLimit) : base(profileId, customerName, freeDeliveriesRemaining, transactionAmountToDate)
  {
   this.annualFee = annualFee;
   this.profileId = profileId;
  }

 }
}
