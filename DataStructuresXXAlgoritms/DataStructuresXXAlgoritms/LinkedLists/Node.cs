using DataStructuresXXAlgoritms.LinkedLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructuresXXAlgoritms.LinkedLists
{
 public class Node

 {

  public int Data { get; set; }

  public Node? Next { get; set; }

  public void DisplayNode()
  {
   Console.WriteLine(Data);
  }
 }
}

public class LinkedList

{
 public Node First { get; set; }
 public void InsertFirst(int data)
 {
  //Create the node
  Node newNode = new Node();
  //Put the data in the node
  newNode.Data = data;
  //put the old node in the next
  newNode.Next = First;

  //make the first the new node
  First = newNode;
 }

 public Node DeleteFirst()
 {
  //Asign the temporary variable
  Node temp = First;
  //assign the new head
  First = First.Next;
  return temp;
 }

 public void DisplayList()
 {
  Console.WriteLine("Iteration through list...");
  Node current = First;
  while (current != null)
  {
   current.DisplayNode();
   current = current.Next;

  }
 }
 public void InsertLast(int data)

 {
  Node current = First;
  while (current.Next != null)
  {
   current = current.Next;
  }
  Node newNode = new Node();
  newNode.Data = data;
  current.Next = newNode;
 }




}







//insert anywhere
//dynamic




//Node nodeA = new Node();
//nodeA.Data = 323;
//Node nodeB=new Node();
//nodeA.Data = 41;
//Node nodeC =new Node();
//nodeA.Data = 36;
//Node nodeD =new Node();
//nodeA.Data = 3;

//nodeA.Next = nodeB;
//nodeB.Next = nodeC;
//nodeC.Next = nodeD;


//LinkedList linkedList = new LinkedList();
//linkedList.InsertFirst(1);
//linkedList.InsertFirst(2);
//linkedList.InsertFirst(3);
//linkedList.InsertFirst(4);
//linkedList.DeleteFirst();
//linkedList.DeleteFirst();
//linkedList.InsertLast(123);
//linkedList.InsertLast(123213);
//linkedList.DisplayList();


