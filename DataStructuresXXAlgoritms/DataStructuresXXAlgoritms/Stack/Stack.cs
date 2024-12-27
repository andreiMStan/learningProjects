//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataStructuresXXAlgoritms.Stack
//{
// public class Stack
// {
//  //Array stacks you need a max size to initiiate array
//  public int MaxSize { get; set; }

//  //this holds our array
//  public string[] StackArray { get; set; }

//  //this keeps track of the top
//  public int Top { get; set; }

//  public Stack(int size)
//  {
//   //this hold constructor value
//   this.MaxSize = size;

//   //creates array with size
//   this.StackArray = new string[MaxSize];
  
//   //we gice the top -1 because array is zero index; If we don't it will skip first element
//   this.Top = -1;
//  }
//  public void Push(string item)
//  {
//   Top++;
//   StackArray[Top] = item;
//  }
//  public string Pop()
//  {
//   int old_top = Top;
//   //decrement for the new top
//   Top--;
//   return StackArray[old_top];
//  }

//  public string Peek()
//  {
//   return StackArray[Top];
//  }

//  public bool isEmpty()
//  {
//   return Top == 0;
//  }

//  public bool isFull()
//  {
//   return MaxSize - 1 == Top;
//  }
// }

//}


////stack


//using DataStructuresXXAlgoritms.Stack;

//Stack stack = new Stack(10);

//for (int i = 0; i < 3; i++)
//{
// stack.Push("Squirle");
// stack.Push("SquirlWasdase");
// stack.Push("Squirlasdsadsadsae");
//}

//stack.Pop();
//stack.Peek();

//while (!stack.isEmpty())
//{
// var value = stack.Pop();
// Console.WriteLine(value);
//}