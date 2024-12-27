using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep
{
 public class Written : Exam
 {
  public Written(int examId, string moduleCode, double baseCost, ExamStatus examStatus, DateTime createDate,string location) : base(examId, moduleCode, baseCost, examStatus, createDate)
  {
   this.Location = location;
  }

  public string Location { get; set; }
  public override void Print()
  {
   base.Print();
            Console.WriteLine(Location);
        }
  public override double CalculateExamFee()
  {
   double totalFee = BaseCost;
   return totalFee;
  }
 }
}
