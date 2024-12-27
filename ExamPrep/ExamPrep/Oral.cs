using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep
{
 public class Oral : Exam
 {
  public Oral(int examId, string moduleCode, double baseCost, ExamStatus examStatus, DateTime createDate,string examiner) : base(examId, moduleCode, baseCost, examStatus, createDate)
  {
   this.Examiner = examiner;
  }

  public string Examiner { get; set; }
  public override void Print()
  {
   base.Print();
            Console.WriteLine(Examiner);
        }
  public override double CalculateExamFee()
  {
   double totalFee = BaseCost*5;
   return totalFee;
  }
 }
}
