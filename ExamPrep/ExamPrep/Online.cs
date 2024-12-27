using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep
{
 public abstract class Online:Exam
 {
  protected Online(int examId, string moduleCode, double baseCost, ExamStatus examStatus, DateTime createDate,string softwareRequirements,string url) : base(examId, moduleCode, baseCost, examStatus, createDate)
  {
   this.SoftwareRequirements = softwareRequirements;
   this.URL = url;
  }


  public string SoftwareRequirements { get; set; }
   public string URL { get; set; }
    }
}
