using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep
{
 public abstract class Exam
 {
        public int ExamId { get; set; }
        public string ModuleCode { get; set; }
        public double BaseCost { get; set; }
        public  ExamStatus Status{ get; set; }
        public DateTime CreateDate { get; set; }

        public Exam(int examId,string moduleCode,double baseCost,  ExamStatus examStatus, DateTime createDate)
        {
   this.ExamId = examId;
   this.ModuleCode = moduleCode;
   this.BaseCost = baseCost;
   Status = examStatus;
        }

        public abstract double CalculateExamFee();
          public  virtual void Print()
         {
           Console.WriteLine($"{ExamId}");
           Console.WriteLine($"{ModuleCode}");
           Console.WriteLine($"{BaseCost}");
           Console.WriteLine($"{CreateDate}");
        }
    }
       public enum ExamStatus { 
           Archived, Current, Pending };
}
