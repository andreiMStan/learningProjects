
internal class Program
{
 private static void DisplayMenu()
 {
  Console.WriteLine("1: Start New Game(Reset)");
  Console.WriteLine("2: Computer go");
  Console.WriteLine("3: Users go");
  Console.WriteLine("4: Display winner:");
  Console.WriteLine("5: Display scores");
  Console.WriteLine("6: Exit");
  //}
 }
 //int userchoice = Int32.Parse(Console.ReadLine());
 //                for (int i = 0; i< 5; i++)
 //                {
 //                    if (userchoice == state[i]))
 //                    {
 //                        usersState = state[i];
 //                    }

 //                }

 string computersState = "";

 string usersState = "";
 static void Main(string[] args)
 {
  Console.WriteLine("Welcome to Rock,Paper,Scissors,Lizard,Spock game");
  Random random = new Random();


  string computersState = "";
  string usersState = "";

  int userWins = 0;
  int computerWins = 0;
  int enterOption;
  int computersGuess;


  string[] state = {
        "Rock",
        "Paper",
        "Scissors",
        "Lizard",
        "Spoke"
    };

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
     Console.WriteLine("Game has started:");
     userWins = 0;
     computerWins = 0;
     break;
    case 2:

     computersGuess = random.Next(0, 5);
     computersState = state[computersGuess];
     Console.WriteLine("The computer has selected a state");
     Console.WriteLine();
     break;
    case 3:
     Console.WriteLine("Select a state Rock, Paper, Scissors, Lizard, Spoke");
     usersState = Console.ReadLine();
     for (int i = 0; i < 5; i++)
     {
      if (usersState == state[i])
      {
       usersState = state[i];
      }

     }

     Console.WriteLine();
     break;
    case 4:
     Console.WriteLine($"User Selection:{usersState} " +
         $"\nComputer state: {computersState}");

     bool? winner;
     winner = DidTheComputerWin(computersState, usersState);
     if (winner == false)
     {
      userWins++;
     }
     else
     {
      computerWins++;
     }

     if (winner == false)
     {
      Console.WriteLine("You have won this game");
      Console.WriteLine();

     }
     else
     {
      Console.WriteLine("Computer has won this game");
      Console.WriteLine();
     }
     break;
    case 5:

     Console.WriteLine($"Your score:  {userWins} \n" +
         $"Computer Score {computerWins}  ");
     if (userWins > computerWins)
     {
      Console.WriteLine("You have won");
      Console.WriteLine();
     }
     else
     {
      Console.WriteLine("Computer has won");
      Console.WriteLine();

     }
     break;

    case 6:
     Console.WriteLine("Exit ...");

     break;
    default:
     { Console.WriteLine("invalid selection"); }
     break;
   }
  } while (enterOption != 6);


 }


 private static Boolean? DidTheComputerWin(string computersState, string usersState)
 {
  Boolean? ComputerWin = false;
  //
  if (computersState.Equals(usersState)) { ComputerWin = null; }
  else
  {
   switch (computersState)
   {
    case "Rock":
     if (usersState.Equals("Lizard") || usersState.Equals("Scissors")) ComputerWin = true;
     break;
    case "Paper":
     if (usersState.Equals("Rock") || usersState.Equals("Spock")) ComputerWin = true;
     break;
    case "Scissors":
     if (usersState.Equals("Paper") || usersState.Equals("Lizard")) ComputerWin = true;
     break;
    case "Lizard":
     if (usersState.Equals("Paper") || usersState.Equals("Spock")) ComputerWin = true;
     break;
    case "Spock":
     if (usersState.Equals("Rock") || usersState.Equals("Scissors")) ComputerWin = true;
     break;
   }
  }

  return ComputerWin;

 }


}
