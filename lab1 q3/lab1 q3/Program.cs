

using System.Diagnostics.Tracing;
using System.Globalization;
using System.Reflection.Metadata;
using System.Text;

internal class Program
{

 public static string Decoding(string keyToDecode, string message)
 {
  StringBuilder stringBuilder = new StringBuilder();

  string[] wordsOfInput = message.Split(' ');
  char[] keyToChar = keyToDecode.ToCharArray();
  //part1
  Array.Reverse(keyToChar);
  stringBuilder.Append(keyToChar);
  string reveresedKey = stringBuilder.ToString();

  //part2
  string subStr = reveresedKey.Substring(0, 2);
  string reversedKey2 = reveresedKey.Remove(0, 2);
  string endKey = reversedKey2.Insert(3, subStr);
  char[] endKeyChar = endKey.ToCharArray();
  //part3 Yrevdetseretninunitahtnoinipo
  int freg = Convert.ToInt32(FrequencyOfLetter(message));
  int indexOf = endKey.IndexOf('/') + 1;
  string str2 = endKey.Substring(indexOf, (endKeyChar.Length - indexOf));
  string str1 = endKey.Substring(0, indexOf);
  string[] arrayInt = str2.Split(':');
  int keyLenght = 0;
  string lastEnd = str1;

  string decodedMessage = "";
  int lenght = 0;
  foreach (string num in arrayInt)
  {
   if (num != "")
   {
    keyLenght = Convert.ToInt32(num) - freg;
    string str3 = message.Substring(lenght, keyLenght);
    lenght += keyLenght;
    lastEnd += keyLenght.ToString() + ":";
    decodedMessage += new string(str3.Reverse().ToArray()).ToLower() + " ";

    continue;
   }
  }
  string finalDecoding = "Decoded Key: " + lastEnd + "\n" + "Decoded Message:" + decodedMessage;

  return finalDecoding;
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

 private static void DisplayMenu()
 {
  Console.WriteLine("1: Enter message to decode:");
  Console.WriteLine("2: Display encoded message and key");
  Console.WriteLine("3: Exit");
 }
 static void Main(string[] args)
 {
  string message = "";
  string keyToDecode = "";
  char[] messageToDecode = null;
  char[] keyToDecodeChar = null;
  StringBuilder sb = new StringBuilder();
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
     Console.WriteLine("Enter key to decode:");
     keyToDecode = Console.ReadLine();
     keyToDecodeChar = keyToDecode.ToCharArray();

     Console.WriteLine("Enter message to decode:");
     message = Console.ReadLine();
     Console.WriteLine();
     messageToDecode = message.ToCharArray();
     Console.WriteLine(Decoding(keyToDecode, message));

     Console.WriteLine();
     Console.WriteLine("Do you want to decode another message Y/N?");
     string answer = Console.ReadLine();
     Console.WriteLine();
     messageToDecode = null;
     if (answer.ToLower() == "y")
     {
      enterOption = 1;
     }
     else
     {
      enterOption = 3;
     }
     break;

    case 2:
     Console.WriteLine();
     if (messageToDecode == null)
     {
      Console.WriteLine("Option 1 needs to be completed before progressing to option 2");
      Console.WriteLine();
      break;
     }
     break;

   }

  } while (enterOption != 3);

 }

}
