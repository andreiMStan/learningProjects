using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep
{
 public class OpenBook : Online, IAutomated
 {
  public OpenBook(int examId, string moduleCode, double baseCost, ExamStatus examStatus, DateTime createDate, string softwareRequirements, string url) : base(examId, moduleCode, baseCost, examStatus, createDate, softwareRequirements, url)
  {
  }

  public override void Print()
  {
   base.Print();
  }
  public override double CalculateExamFee()
  {
   double totalFee = BaseCost+BaseCost*0.5;
   return totalFee;
  }

  public string autoInfo()
  {
   string concatStr = ExamId.ToString() + "/" + ModuleCode;
  return concatStr;

  }
 }
}
