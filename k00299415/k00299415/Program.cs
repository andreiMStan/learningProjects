
using System;
using System.Collections;
using System.Globalization;
using System.Numerics;

public class Program
{
 static void Main(string[] args)
 {
  Console.WriteLine($"** Welcome to MathsApp **            ");

  int option = 0;
  do
  {
   displayMenu();

   option = Convert.ToInt32(Console.ReadLine());
   Console.WriteLine(option);
   Console.WriteLine();

   string answer = "y";
   switch (option)
   {
    case 1:
     PrimeFactors();
     break;

    case 2:

     while (answer.ToUpper() == "Y")
     {
      DivAlg();
      Console.WriteLine("Do you wish to continue with Program 2?  'Y' or 'N' ");
      answer = Console.ReadLine();
     }
     break;

    case 3:
     while (answer.ToUpper() == "Y")
     {

      ExtEucAlg();
      Console.WriteLine("Do you wish to continue with Program 3?  'Y' or 'N' ");
      answer = Console.ReadLine();
     }
     break;


    case 4:
     MatrixInversion3x3();
     break;

    case 5:
     Console.WriteLine("Thank you for using our application");
     break;

    default:
     {
      Console.WriteLine("option not implemented");
      break;
     }
   }
   if (option != 5)
   {

    string answer1;
    Console.WriteLine("\nDo you wish to continue using the Maths App 'Y' or 'N'?");
    answer1 = Console.ReadLine();
    if (answer1.ToUpper() == "N")
    {
     option = 5;
    }
   }



  } while (option != 5);


  void displayMenu()
  {
   Console.WriteLine($"\n______________________________________________________________________");
   Console.WriteLine($"|                                                                    |");
   Console.WriteLine($"| Program 1: Program for the prime factorization of a natural number |");
   Console.WriteLine($"| Program 2: Program for the Division algorithm.                     |");
   Console.WriteLine($"| Program 3: Program for the extended Euclidean algorithm.           |");
   Console.WriteLine($"| Program 4: Program for inverting a 3x3 matrix.                     |");
   Console.WriteLine($"| 5.Exit                                                             |");
   Console.WriteLine($"|____________________________________________________________________|\n");

  }
  void PrimeFactors()
  {
   long input;
   Console.WriteLine("Input natural number: ");
   input = Convert.ToInt64(Console.ReadLine());

   while (input <= 1)
   {
    Console.WriteLine("Input must be greater than 1");
    Console.WriteLine("Input another number: ");
    input = Convert.ToInt64(Console.ReadLine());
   }
   int k = 2;
   Console.WriteLine();
   Console.WriteLine("Prime factors: ");

   while (input % k == 0)
   {
    Console.Write(k + " ");
    input /= k;
   }


   for (int i = 3; i <= Math.Sqrt(input); i += 2)
   {
    while (input % i == 0)
    {
     Console.Write(i + " ");
     input /= i;
    }
   }

   if (input > 2)
   {
    Console.Write(input);
   }
   Console.WriteLine();

   string answer;
   Console.WriteLine("\nDo you wish to continue using the prime factorisation program  'Y' or 'N'?");
   answer = Console.ReadLine();
   if (answer.ToUpper() == "Y")
   {
    PrimeFactors();
   }
  }
  void DivAlg()
  {
   //the dividend
   double a;
   double b;
   double q = 0;
   double r = 0;
   Console.WriteLine("Input Dividend:");
   a = Convert.ToInt32(Console.ReadLine());
   //the divisor
   Console.WriteLine("Input Divisor:");
   b = Convert.ToInt32(Console.ReadLine());
   if (b == 0)
   {
    Console.WriteLine("Divisor can not be ZERO,please input other value");
    b = Convert.ToInt32(Console.ReadLine());
   }
   if (b > 0)
   {
    q = Math.Floor(a / b);
   }
   else //if (b < 0 && a >= 0)
   {
    q = Math.Ceiling(a / b);
   }
   r = a - b * q;
   a = b * q + r;
   Console.WriteLine($"\nQuatient={q}" +
    $"\nRemeinder={r}" +
    $"\nCondition 'a=bq+r':{a}\n");
  }
  void ExtEucAlg()
  {
   BigInteger a, b;
   BigInteger d;
   Console.WriteLine("\nInput first positive integer:");
   a = BigInteger.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
   Console.WriteLine("Input secound positive integer:");
   b = BigInteger.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
   if (a < b)
   {
    BigInteger temp;
    temp = a;
    a = b;
    b = temp;

    //   Console.WriteLine("\nFirst integer "+a+" Must be greater than second integer"+b);
    // return;
   }
   BigInteger[] u = { a, 1, 0 };
   BigInteger[] v = { b, 0, 1 };
   BigInteger[] w = { 0, 0, 0 };

   while (v[0] > 0)
   {
    BigInteger q = (u[0] / v[0]);
    //q = Math.Floor(q);
    for (int i = 0; i < 3; i++)
    {
     w[i] = u[i] - (int)q * v[i];

    }
    for (int i = 0; i < 3; i++)
    {
     u[i] = v[i];
     v[i] = w[i];
    }
   }
   Console.WriteLine($"\nd={u[0]}" +
    $"\nx={u[1]}\ny={u[2]}\n");

   Console.WriteLine();
   //verifying condition
   d = a * u[1] + b * u[2];
   //Console.WriteLine("Do you wish to find the decryption key Y/N");
   //string answer = Console.ReadLine();
   //if (answer.ToUpper()=="Y")
   //{
   // Console.WriteLine("Input p:");
   // BigInteger pp = Convert.ToInt64(Console.ReadLine());
   // Console.WriteLine("Input q:");
   // BigInteger qq = Convert.ToInt64(Console.ReadLine());
   // Console.WriteLine("Input e:");
   // BigInteger ee = Convert.ToInt64(Console.ReadLine());
   // BigInteger nn = pp * qq;
   // //ExtEucAlg(nn, pp);
   // BigInteger gcd = u[1];
   // BigInteger phi = (pp - 1) * (qq - 1);

   // if (u[1] == 1)
   // {
   //  BigInteger decryptionD;
   //  decryptionD = (u[1] % phi + phi) % phi;
   //  Console.WriteLine("Smallest decryption key is "+decryptionD);
   // }
   // else
   // {
   //  Console.WriteLine("No valid decryption key as gcd is not 1");
   // }
  }

  void MatrixInversion3x3()
  {
   double[,] inverseA = new double[3, 3];
   double[,] coafactor = new double[3, 3];
   //double[,] a = new double[3, 3];
   //double[,] a = new double[3,3]
   //{
   // {7.5,-1.5,-4.75},
   // {-4,1, 2.5 },
   // {-2.5,0.5,1.75}
   //};  
   double[,] a = new double[3, 3]
   {
    {2,4,6},
    {7,1, 3 },
    {2,0,9}
   };
   //Console.WriteLine("Input matrix numbers by pressing enter after each number ");

   //for (int i = 0; i < 3; i++)
   //{
   // for (int j = 0; j < 3; j++)
   // {
   // double num=Convert.ToDouble(Console.ReadLine());
   // a[i, j]=num;
   // }

   // }


   double detA =
    a[0, 0] * a[1, 1] * a[2, 2] +
    a[0, 1] * a[1, 2] * a[2, 0] +
    a[0, 2] * a[1, 0] * a[2, 1] -
    a[0, 2] * a[1, 1] * a[2, 0] -
    a[0, 0] * a[1, 2] * a[2, 1] -
    a[0, 1] * a[1, 0] * a[2, 2]
    ;
   // Console.WriteLine(detA);
   if (detA == 0)
   {
    Console.WriteLine("ERROR: the matrix is not invertible.");
   }
   else
   {
    Console.WriteLine("Matrix a");
    Console.WriteLine("--------");
    for (int i = 0; i < 3; i++)
    {
     for (int j = 0; j < 3; j++)
     {
      Console.Write((a[i, j]).ToString("F2") + " ");
     }
     Console.WriteLine();
    }

    coafactor[0, 0] = (a[1, 1] * a[2, 2]) - a[2, 1] * a[1, 2];
    coafactor[0, 1] = (a[0, 2] * a[2, 1]) - a[2, 2] * a[0, 1];
    coafactor[0, 2] = (a[0, 1] * a[1, 2]) - a[1, 1] * a[0, 2];

    coafactor[1, 0] = (a[1, 2] * a[2, 0]) - a[2, 2] * a[1, 0];
    coafactor[1, 1] = (a[0, 0] * a[2, 2]) - a[2, 0] * a[0, 2];
    coafactor[1, 2] = (a[0, 2] * a[1, 0]) - a[1, 2] * a[0, 0];

    coafactor[2, 0] = (a[1, 0] * a[2, 1]) - a[2, 0] * a[1, 1];
    coafactor[2, 1] = (a[0, 1] * a[2, 0]) - a[2, 1] * a[0, 0];
    coafactor[2, 2] = (a[0, 0] * a[1, 1]) - a[1, 0] * a[0, 1];

    Console.WriteLine("\nCoafactor a");
    Console.WriteLine("--------");
    for (int i = 0; i < 3; i++)
    {
     for (int j = 0; j < 3; j++)
     {
      Console.Write((coafactor[i, j]).ToString("F2") + " ");
     }
     Console.WriteLine();
    }

    Console.WriteLine("\nDeterminant of matrix a:" + detA);


    Console.WriteLine("\nInvers of matrix a");
    Console.WriteLine("------------------");
    for (int i = 0; i < 3; i++)
    {
     for (int j = 0; j < 3; j++)
     {
      inverseA[i, j] = coafactor[i, j] * 1 / detA;
      Console.Write((inverseA[i, j]).ToString("F3") + " ");
     }
     Console.WriteLine();
    }


   }
  }
 }
}

 