using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresXXAlgoritms.BinaryTree
{
 public class TreeNode
 {
  public int Key { get; set; }
  public string Value { get; set; }
  public TreeNode LeftChild { get; set; }
  public TreeNode RightChild { get; set; }

  public TreeNode(int key, string value)
  {
   this.Key = key;
   this.Value = value;

  }
 }

 public class BinarySearchTree
 {
  public TreeNode Root { get; set; }
  public void Insert(int key, string value)
  {
   Root = InsertItem(Root, key, value);
  }

  public void PrintInOrderTraversal()
  {
   InOrderTraversal(Root);
  }
  private void InOrderTraversal(TreeNode node)
  {
   if (node != null)
   {
    InOrderTraversal(node.LeftChild);
    Console.WriteLine(node.Key + " " + node.Value);
    InOrderTraversal(node.RightChild);
   }
  }
   public void PrintPreOrderTraversal()
  {
   PreOrderTraversal(Root);
  }
  private void PreOrderTraversal(TreeNode node)
  {
   if(node != null)
   {
    Console.WriteLine(node.Key + " " + node.Value);
    PreOrderTraversal(node.LeftChild);
    PreOrderTraversal(node.RightChild);
   }
  }  
  public void PrintPostOrderTraversal()
  {
   PostOrderTraversal(Root);
  }
  private void PostOrderTraversal(TreeNode node)
  {
   if(node != null)
   {
    PostOrderTraversal(node.LeftChild);
    PostOrderTraversal(node.RightChild);
    Console.WriteLine(node.Key + " " + node.Value);
   }
  }



  public TreeNode InsertItem(TreeNode node, int key, string value)
  {
   TreeNode newNode = new TreeNode(key, value);
   //if this is the first time you insert ,create the root
   if (node == null)
   {

    node = newNode;
    return node;
   }
   //if this isn't the first insert
   //Traverse,find null , insert
   else if (key < node.Key)
   {
    node.LeftChild = InsertItem(node.LeftChild, key, value);

   }
   else
   {
    node.RightChild = InsertItem(node.RightChild, key, value);
   }
   return node;
  }


  public string Find(int key)
  {
   TreeNode node = Find(Root, key);
   return node == null ? null : node.Value;
  }
  private TreeNode? Find(TreeNode node, int key)
  {
   if (node == null || node.Key == key)
   {
    return node;
   }
   else if (key < node.Key)
   {
    return Find(node.LeftChild, key);
   }
   else if (key > node.Key)
   {
    return Find(node.RightChild, key);
   }
   else
   {
    return null;
   }
  }

 }
}




//using DataStructuresXXAlgoritms.BinaryTree;

//BinarySearchTree bst = new BinarySearchTree();
//bst.Insert(7,"a");
//bst.Insert(23,"b");
//bst.Insert(232,"c");
//bst.Insert(4,"d");
//bst.Insert(1,"e");

//Console.WriteLine(bst.Find(232));

////int value = 0;