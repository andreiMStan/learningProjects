using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep
{
 public class Proctored : Online
 {
  public Proctored(int examId, string moduleCode, double baseCost, ExamStatus examStatus, DateTime createDate, string softwareRequirements, string url,string provider) : base(examId, moduleCode, baseCost, examStatus, createDate, softwareRequirements, url)
  {
   this.Provider = provider;
  }

  public string Provider { get; set; }

  public override void Print()
  {
   base.Print();
   Console.WriteLine(Provider);
  }
  public override double CalculateExamFee()
  {
   double totalFee = BaseCost*3;
   return totalFee;
  }
 }
}
