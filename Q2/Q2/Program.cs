using System.Diagnostics.Tracing;
using System.Text;

internal class Program
{

 public static string ChangePosition(char[] endkey)
 {
  char[] lastCharArray = new char[endkey.Length];
  lastCharArray[0] = endkey[3];
  lastCharArray[1] = endkey[4];

  for (int i = 0, k = 2; i < endkey.Length; i++)
  {
   if (i == 3 || i == 4)
    continue;
   lastCharArray[k++] = endkey[i];
  }
  string last = new string(lastCharArray);
  string endkeyToghether2 = last;

  //Console.WriteLine("Modified string: " + endkeyToghether2);
  return endkeyToghether2;
 }


 public static string ReverseMessage(string message)
 {

  char separator = ' ';
  string[] words = message.Split(separator);


  string wordReversed = "";
  foreach (string word in words)
  {
   char[] charArray = word.ToCharArray();

   for (int i = charArray.Length - 1; i > -1; i--)
   {

    wordReversed += charArray[i];
   }
   }
  return wordReversed;
   }

 public static string Reverse(string endKeys)
 {
  char[] charArray = endKeys.ToCharArray();
  string keyReversed = "";

  for (int i = charArray.Length - 1; i > -1; i--)
  {

   keyReversed += charArray[i];

  }
  return keyReversed;
 }




 static string FrequencyOfLetter(string message)
 {
  int[] charArray = new int[150];
  string endKey = "";
  foreach (char character in message)
  {
   charArray[(int)character]++;
  }
  int highestFreq = 0;
  for (int i = 0; i < charArray.Length - 1; i++)
  {
   if (charArray[i] > 0 && char.IsLetterOrDigit((char)i))
   {
    //  Console.WriteLine("Letter: {0}  Frequency: {1}", (char)i, charArray[i]);
    if (highestFreq < charArray[i])
    {
     highestFreq = charArray[i];
    }
   }
   endKey = highestFreq.ToString();

  }
  return endKey;
 }



 static string LenghtOfWord(string message)
 {
  int highestFreg = Convert.ToInt32(FrequencyOfLetter(message));
  string endCount = "";
  int highestFreqvency = 0;
  char separator = ' ';
  string[] words = message.Split(separator);

  foreach (string word in words)
  {
   string wordCount = word.Count().ToString();
   endCount += Convert.ToString((Convert.ToInt32(wordCount) + highestFreg)) + ":";
   highestFreqvency++;
  }
  return endCount;
 }


 static int AsciiCode()
 {
  Random rdn = new();
  char[] symbols = { '!', '*', '@', '?', '^', ';' };
  int next = rdn.Next(symbols.Length);
  char[] symbol = { symbols[next] };
  int aschiiCode = Encoding.ASCII.GetBytes(symbol)[0];
  return aschiiCode;
 }

 static int NumberOfWords(string message)
 {

  int numberOfWords = 0;
  char separator = ' ';
  string[] words = message.Split(separator); // returned array
  int wordCount = 0;
  foreach (string word in words)
  {
   wordCount += word.Count();
   numberOfWords++;
  }
  return numberOfWords;
 }

 private static void DisplayMenu()
 {
  Console.WriteLine("1: Enter message to encode");
  Console.WriteLine("2: Display encoded message and key");
  Console.WriteLine("3: Exit");
 }
 static void Main(string[] args)
 {
  string message = "";
  char[] messageToEncode = null;
  int enterOption;
  do
  {
   DisplayMenu();
   Console.WriteLine("Enter Option:");
   String optionString = Console.ReadLine();
   enterOption = Int32.Parse(optionString);
   Console.WriteLine();

   switch (enterOption)
   {
    case 1:
     Console.WriteLine("Enter message to encode");
     message = Console.ReadLine();
     messageToEncode = message.ToCharArray();
     for (int i = 0; i < messageToEncode.Length; i++)
     {
      // Console.Write(messageToEncode[i]);
     }
     string firstPart = NumberOfWords(message).ToString() + "-";
     string secondPart = AsciiCode().ToString() + "/";
     string thirdPart = LenghtOfWord(message);
     //string thirdPart2 = FrequencyOfLetter(message);
     string endkeyToghether = firstPart + secondPart + thirdPart;


     char[] endKeya = endkeyToghether.ToCharArray();


     string endkey = ChangePosition(endKeya);
     Console.WriteLine(Reverse(endkey));
     // Console.WriteLine(FrequencyOfLetter(message));

     Console.WriteLine(ReverseMessage(message));
     Console.WriteLine();
     Console.WriteLine("Do you want to encode another message Y/N?");
     string answer = Console.ReadLine();
     Console.WriteLine();
     messageToEncode = null;



     break;

    case 2:
     Console.WriteLine();
     if (messageToEncode == null)
     {
      Console.WriteLine("Option 1 needs to be completed before progressing to option 2 ");
      Console.WriteLine();
     }
     break;

   }

  } while (enterOption != 3);

 }

}


