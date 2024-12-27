// LinkedList.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include "UnsortedType.h"
#include "UnsortedType.cpp"
#include "SortedType.h"
#include "SortedType.cpp"
#include  "fstream"
using namespace std;
void Menu();
void UL1StringsfromFile(UnsortedType<string>& UL1);
void OL1StringsFromKeyBoard(SortedType<string>& OL1);
void UL1StringAfterExisting(UnsortedType<string>& UL1);
void MergeContents(UnsortedType<string>& UL1, SortedType<string>& OL1, SortedType<string>& OL2);
int choice;
    UnsortedType<string> UL1;
    SortedType<string> OL1;
    SortedType<string>OL2;
    void ReverseList(SortedType<string>& OL1);
    void DeleteItemFromOL1(SortedType<string>& OL1,string aaa);
    void  PrintContents(UnsortedType<string>& UL1, SortedType<string>& OL1, SortedType<string>& OL2);
int main()
{
    // Create unsorted linked list
    // Create OL1 sorted linked list
 

    string aa;
  
    cout << ("Sorted/Ordered & Unsorted/Unordered Linked Lists") << endl;
    do
    {
        
        Menu();
        cin >> choice;
        switch (choice)
        {
        case 1:
          
            // Add items and prints items
            UL1StringsfromFile(UL1);
            break;

        case 2:
            //
            OL1StringsFromKeyBoard(OL1);
            break;

        case 3:
            //
            UL1StringAfterExisting(UL1);

            break;

        case 4:
            //
           MergeContents(UL1, OL1, OL2);
            break;

        case 5:
            //
            ReverseList(OL1);
            break;

        case 6:
            //
           
            cout << "Enter string:";
            cin >> aa;
            DeleteItemFromOL1(OL1, aa );
            break;

        case 7:
            //
            PrintContents(UL1, OL1, OL2);
            break;

        case 8:
            cout << ("Exiting the system...");
            break;

        default:
            cout << ("Invalid choice. Please try again.");
            break;
        }
    } while (choice != 8);


    return 0;

}
// Menu system

static void Menu() {
    // Menu system
      cout << endl;
      cout<<("1.Insert Strings from File to UL1")<<endl;
      cout<<("2.Input String to OL1 from KeyBoard") << endl;
      cout<<("3.Insert String after Specific String in UL1 ") << endl;
      cout<<("4.Merge UL1 and OL1 into Ordered OL2(No Duplicates)") << endl;
      cout<<("5.Reverse Contents of OL2") << endl;
      cout<<("6.Delete String from OL2") << endl;
      cout<<("7.Display All Lists(UL1,OL1,OL2)") << endl;
      cout<<("8.Exit") << endl;
      
        cout<<("Enter your choice: ");
   
}
static void UL1StringsfromFile(UnsortedType<string>& UL1) {
   
    ifstream infile("myFile.txt");
    if (!infile.is_open())
        cout << "file could not be opened\n";
    else {
        string first;
        while (infile >> first) 
        {
            UL1.InsertItem(first);
        }
        infile.close();
    }
    // Print Contents
    cout << "List UL1 = ";
    UL1.PrintList();
}
static void OL1StringsFromKeyBoard(SortedType<string>& OL1) {

    // Add items
    string input="";
    cout << "Input string or -1 to exit";
    cout << endl;
    cin >> input;
    while (input != "-1")
    {
        //inserts the content 
        OL1.InsertItem(input);
        cin >> input;
    }
    // Print Contents
    cout << "List OL1 = ";    OL1.PrintList();
}
static void UL1StringAfterExisting(UnsortedType<string>& UL1)
{
    
    string input1 = "";
    string input2 = "";
   
    cout << "Input string to add to the list: ";
    cin >> input2;
    cout << "Input existing string: ";
    cin >> input1;
    UL1.InsertAfterItem(input1, input2);
    cout << "List UL1 after insertion = ";    UL1.PrintList();
}
static void MergeContents(UnsortedType<string>& UL1, SortedType<string>& OL1, SortedType<string>& OL2) {
    string currentItem;
    bool found;

    UL1.ResetList();  
    for (int i = 0; i < UL1.LengthIs(); i++) 
    {
        UL1.GetNextItem(currentItem);  
        if (currentItem.empty()) 
        {
            break;
        }
        OL2.RetrieveItem(currentItem, found); 
        if (!found) 
        {
            OL2.InsertItem(currentItem); 
        }
    } 

    OL1.ResetList();  
    for (int i = 0; i < OL1.LengthIs(); i++) 
    {
        OL1.GetNextItem(currentItem); 
        if (currentItem.empty())
        {
            break;
        }
        OL2.RetrieveItem(currentItem, found); 
        if (!found) 
        { 
            OL2.InsertItem(currentItem);  
        }
    }

    OL2.PrintList();
}
static void PrintContents(UnsortedType<string>& UL1, SortedType<string>& OL1, SortedType<string>& OL2)
{
    cout << endl;
    if (UL1.LengthIs() == 0)
    {
        cout << "UL1. List is empty ";
    }
    else
    {
    cout << "UL1:"; UL1.PrintList();

    }
    if (UL1.LengthIs() == 0)
    {
        cout << "OL1 List is empty ";
    }
    else
    {
        cout << "OL1:"; OL1.PrintList();

    }


    if (UL1.LengthIs() == 0)
    {
        cout << "OL2 List is empty ";
    }
    else
    {
    cout << "OL2:";  OL2.PrintList();

    }
}
static void DeleteItemFromOL1(SortedType<string>& OL1,string aa) {
    OL1.DeleteItemAt(aa);
    OL1.PrintList();
}


static void ReverseList(SortedType<string>& OL1) {
 
    OL1.ReverseList();
    OL1.PrintList();

    }
