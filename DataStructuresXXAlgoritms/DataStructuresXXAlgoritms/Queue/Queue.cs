using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresXXAlgoritms.Queue
{
 public class Queue
 {
  public int MaxSize { get; set; }
  //Actual array we will store elements in
  public int[] QueueArray { get; set; }

  // index to keep track of front
  public int Front { get; set; }

  // index to keep track of adds
  public int Rear { get; set; }

  // this will keep track of length
  public int NItems { get; set; }

  public Queue(int size)
  {
   this.MaxSize = size;
   this.QueueArray = new int[size];
   Front = 0;
   Rear = -1;
  }

  public void Enqueue(int item)

  {
   //increment our pointer
   Rear++;
   //insert into where the rear was incremented.
   QueueArray[Rear] = item;
   //Increment 
   NItems++;
  }

  public int DeQueue()
  {
   int temp = QueueArray[Front];
   Front++;
   if (Front == MaxSize)
   {
    Front = 0;
   }
   NItems--;
   return temp;

  }
  public int Peek()
  {
   return QueueArray[Front];
  }

 }
}

//using DataStructuresXXAlgoritms.Queue;

//Queue queue = new Queue(10);
//queue.Enqueue(1);
//queue.Enqueue(2);
//queue.Enqueue(3);
//queue.Enqueue(4);
//queue.Enqueue(5);

//queue.DeQueue();
//queue.DeQueue();
//queue.Peek();

