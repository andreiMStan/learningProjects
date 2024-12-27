

namespace DataStructuresXXAlgoritms.HashTables
{
 public class HashTables
 {
  public string[] _hashTable { get; set; }
  public HashTables()
  {
   _hashTable = new string[10];
  }
  //this is a very week hashing algorithm
  private int _hash(string key)
  {
   return key.Length % _hashTable.Length;
  }
  public string Get(string key)
  {
   int hashedKey = _hash(key);
   return _hashTable[hashedKey];
  }

 public void Set(string key, string value)
 {
   int hashedKey = _hash(key);
   if (_hashTable[hashedKey]!=null)
   {
    Console.WriteLine("Sorry, hash colilision has occured");
   }
   else
   {
    _hashTable[hashedKey] = value;
   }

  }
 }
 }


 

