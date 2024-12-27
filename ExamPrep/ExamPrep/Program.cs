
namespace ExamPrep {

 public class Program
 {
 static void Main(string[] args)
  {
  List<Proctored> pro = new List<Proctored>();
  List<OpenBook> openBook = new();
  List<Oral> oral = new();
  List<Written> written = new();
  String OptionString;
  
   do
   {
    Menu();
    Console.WriteLine("Choose option:");
    int option = Convert.ToInt32(Console.ReadLine());
    OptionString = option.ToString();
    switch (option)
    {
     case 1:
      SetUpExams(pro, openBook, oral, written);
      break;

     case 2:
      DisplayExams(pro, openBook, oral, written);
      break;

     case 3:
      CalculatePercentage(pro, openBook, oral, written);

      break;

     case 4:
      break;

     case 5:
      break;

     case 6:
      Console.WriteLine("Exited");
      break;

     default:
      break;
    }


   } while (OptionString != "6");

  }
  static void SetUpExams(List<Proctored> pro, List<OpenBook> opens, List<Oral> orals, List<Written> writtens)
  {
   Proctored procted = new Proctored(123, "100", 20.00, ExamStatus.Archived, new DateTime(12 / 12 / 2000), "good", "www.aaa.aaa", "Tus");
   OpenBook open = new OpenBook(123, "100", 20.00, ExamStatus.Archived, new DateTime(12 / 12 / 2000), "www.aaa.aaa", "Tus");
   Oral oral = new Oral(123, "100", 20.00, ExamStatus.Archived, new DateTime(12 / 12 / 2000), "John");
   Written written = new Written(123, "100", 20.00, ExamStatus.Archived, new DateTime(12 / 12 / 2000), "Alba");
   Proctored procted1 = new Proctored(123, "100", 20.00, ExamStatus.Archived, new DateTime(12 / 12 / 2000), "good", "www.aaa.aaa", "Tus");
   OpenBook open1 = new OpenBook(123, "100", 20.00, ExamStatus.Archived, new DateTime(12 / 12 / 2000), "www.aaa.aaa", "Tus");
   Oral oral1 = new Oral(123, "100", 20.00, ExamStatus.Archived, new DateTime(12 / 12 / 2000), "John");
   Written written1 = new Written(123, "100", 20.00, ExamStatus.Archived, new DateTime(12 / 12 / 2000), "Alba");
   pro.Add(procted);
   opens.Add(open);
   orals.Add(oral);
   writtens.Add(written); 
   pro.Add(procted1);
   opens.Add(open1);
   orals.Add(oral1);
   writtens.Add(written1);
   Console.WriteLine("Exams succesfully setted");
  }
  static void DisplayExams(List<Proctored> pro, List<OpenBook> opens, List<Oral> orals, List<Written> writtens)
  {
   Console.WriteLine("Proctored Exams");
   foreach (var item in pro)
   {
    item.Print();
    Console.WriteLine();
   }
   Console.WriteLine();

   Console.WriteLine("Open Book Exams");

   foreach (var item in opens)
   {
    item.Print();
    Console.WriteLine();
   }
   Console.WriteLine();

   Console.WriteLine("Oral Exams");

   foreach (var item in orals)
   {
    item.Print();
    Console.WriteLine();
   }
   Console.WriteLine();
   Console.WriteLine("Written Exams");

   foreach (var item in writtens)
   {
    item.Print();
    Console.WriteLine();
   }
  }

  static void CalculatePercentage(List<Proctored> pro, List<OpenBook> opens, List<Oral> orals, List<Written> writtens)
  {
   int countPro = 0;
   int countOra = 0;
   int countWri = 0;
   int countOpe = 0;
   int totalExams = 0;
   foreach (var item in pro)
   {
    countPro++;
   }
   foreach (var item in opens)
   {
    countOra++;
   }

   foreach (var item in orals)
   {
    countWri++;
   }

   foreach (var item in writtens)
   {
    countOpe++;
   }

   totalExams = countPro + countOpe + countWri + countOra;
   double percentage ;
   Console.WriteLine("Proctored "+((percentage= (countPro * 100/ totalExams)).ToString("F2")));
   percentage = 0;
   Console.WriteLine("Oral "+(percentage = (countOra * 100 / totalExams)).ToString("F2"));
   percentage = 0;
   Console.WriteLine("Written "+(percentage = (countWri * 100 / totalExams)).ToString("F2"));
   percentage = 0;
   Console.WriteLine("OpenBook "+(percentage = (countOpe * 100 / totalExams)).ToString("F2"));
  }
  static void Menu()
  {
   Console.WriteLine("1.Set Up Exams");
   Console.WriteLine("2.Display Exams Details");
   Console.WriteLine("3.Display Breakdown Exams");
   Console.WriteLine("4.Calculate Cost of an Exam");
   Console.WriteLine("5.Display Exam ID/Code");
   Console.WriteLine("6.Exit");
  }
 }

}