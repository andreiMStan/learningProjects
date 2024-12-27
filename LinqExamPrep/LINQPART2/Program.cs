using System;
using System.Linq;
using System.Runtime.Intrinsics.X86;

class Program
{
 // delegate bool IsTeenAger(Student stud);
 static void Main(string[] args)
 {
//  Use LINQ to filter the even numbers from the array.

    int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

  var evenNumbers = numbers.
   Where(even => even % 2 == 0);
  
   Console.WriteLine(evenNumbers);
  

 } 

}








  // Define an array of Student objects
  // Student[] studentArray = {
  //           new Student() { StudentID = 1, StudentName = "John", Age = 18 },
  //           new Student() { StudentID = 2, StudentName = "Steve", Age = 21 },
  //           new Student() { StudentID = 3, StudentName = "Bill", Age = 25 },
  //           new Student() { StudentID = 4, StudentName = "Ram", Age = 20 },
  //           new Student() { StudentID = 5, StudentName = "Ron", Age = 31 },
  //           new Student() { StudentID = 6, StudentName = "Chris", Age = 17 },
  //           new Student() { StudentID = 7, StudentName = "Rob", Age = 19 },
  //       };

// // Use LINQ to sort the students in alphabetical order by StudentName
// var studentsInOrder = studentArray.
//  OrderBy(s => s.StudentName);

// // Display the sorted students
// Console.WriteLine("Students in alphabetical order by name:");
// foreach (var student in studentsInOrder)
// {
//  Console.WriteLine($"ID: {student.StudentID}, Name: {student.StudentName}, Age: {student.Age}");
// }





// //IsTeenAger isTeenAger = delegate (Student s) { return s.Age > 12 && s.Age > 20; };
// stud = stud.Age > 12 && s.Age > 20; 

// Student stud = new Student() { Age = 25 };

// Console.WriteLine(isTeenAger(stud));


//}

//{
// Print print = delegate (int val)
// {
//  Console.WriteLine("Inside anonymous method . Value{0}", val);
// };
// print(100);

//}

//  // Define an array of Student objects


//  // Use LINQ to find teenager students
//  Student[] teenAgerStudents = studentArray
//      .Where(s => s.Age > 12 && s.Age < 20)
//      .ToArray();

//  Console.WriteLine("Teenager Students:");
//  foreach (var student in teenAgerStudents)
//  {
//   Console.WriteLine($"ID: {student.StudentID}, Name: {student.StudentName}, Age: {student.Age}");
//  }

//  // Use LINQ to find the first student whose name is Bill
//  Student bill = studentArray
//      .Where(s => s.StudentName == "Bill")
//      .FirstOrDefault();

//  if (bill != null)
//  {
//   Console.WriteLine("\nStudent whose name is Bill:");
//   Console.WriteLine($"ID: {bill.StudentID}, Name: {bill.StudentName}, Age: {bill.Age}");
//  }

//  // Use LINQ to find the student whose StudentID is 5
//  Student student5 = studentArray
//      .Where(s => s.StudentID == 5)
//      .FirstOrDefault();

//  if (student5 != null)
//  {
//   Console.WriteLine("\nStudent with ID 5:");
//   Console.WriteLine($"ID: {student5.StudentID}, Name: {student5.StudentName}, Age: {student5.Age}");
//  }
// }
//}

// Define the Student class
// class Student
// {
//  public int StudentID { get; set; }
//  public string StudentName { get; set; }
//  public int Age { get; set; }
// }
//}

