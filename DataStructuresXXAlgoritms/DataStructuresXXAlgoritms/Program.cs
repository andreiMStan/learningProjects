

using DataStructuresXXAlgoritms.HashTables;

HashTables hashTable = new HashTables();
hashTable.Set("Andrei", "545-2323-232");
hashTable.Set("Andreiasd", "5345-2323-232");
hashTable.Set("zcxx", "5345-22323-232");
hashTable.Set("vcca", "5345-22323-232");
hashTable.Set("ASD", "53345-22323-232");
hashTable.Set("adssad", "53345-223233-232");

Console.WriteLine(hashTable.Get("Andrei"));
Console.WriteLine(hashTable.Get("Andreiasd"));
Console.WriteLine(hashTable.Get("zcxx"));
Console.WriteLine(hashTable.Get("vcca"));
Console.WriteLine(hashTable.Get("ASD"));
Console.WriteLine(hashTable.Get("adssad"));