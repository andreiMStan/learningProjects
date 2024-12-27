
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
void ReverseList(SortedType<string>& OL2);
void DeleteItemFromOL2(SortedType<string>& OL2, string aaa);
void  PrintContents(UnsortedType<string>& UL1, SortedType<string>& OL1, SortedType<string>& OL2);
int main()
{
    string input;
    cout << ("Sorted/Ordered & Unsorted/Unordered Linked Lists") << endl;
    do
    {

        Menu();
        cin >> choice;
        cout << endl;
        switch (choice)
        {
        case 1:

            // Inserts items from a file and prints them to the screen
            UL1StringsfromFile(UL1);
            break;

        case 2:
            //Inserts items form keyboard and print to screen
            OL1StringsFromKeyBoard(OL1);
            break;

        case 3:
            //Inserts after given string 
            UL1StringAfterExisting(UL1);

            break;

        case 4:
            //Merge contents of UL1 and OL1
            MergeContents(UL1, OL1, OL2);
            break;

        case 5:
            //Reverse OL2 list
            ReverseList(OL2);
            break;

        case 6:
            //Deletes string from OL2
            cout << endl;
            cout << "Enter string:";
            cin >> input;
            DeleteItemFromOL2(OL2, input);
            break;

        case 7:
            //Prints the contents of UL1,OL1,OL2
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
    cout << ("1.Insert Strings from File to UL1") << endl;
    cout << ("2.Input String to OL1 from KeyBoard") << endl;
    cout << ("3.Insert String after Specific String in UL1 ") << endl;
    cout << ("4.Merge UL1 and OL1 into Ordered OL2(No Duplicates)") << endl;
    cout << ("5.Reverse Contents of OL2") << endl;
    cout << ("6.Delete String from OL2") << endl;
    cout << ("7.Display All Lists(UL1,OL1,OL2)") << endl;
    cout << ("8.Exit") << endl;
    cout << endl;
    cout << ("Enter your choice: ");

}
static void UL1StringsfromFile(UnsortedType<string>& UL1) {

    //reads in from a file
    ifstream infile("myFile.txt");
    if (!infile.is_open())
        cout << "file could not be opened\n";
    else {
        string first;
        while (!infile.eof()) 
        {
            infile >> first;
            UL1.InsertItem(first);
        };
        infile.close();
    }
    // Print Contents
    cout << "UL1 : ";   UL1.PrintList();
}
static void OL1StringsFromKeyBoard(SortedType<string>& OL1) {

    // Add items
    string input = "";
    cout << "Input string or -1 to exit";
    cout << endl;
    cin >> input;
    while (input != "-1")
    {
        //inserts the content into OL1
        OL1.InsertItem(input);
        cin >> input;
    }
    // Print Contents
    cout << endl;
    cout << "OL1 : ";    OL1.PrintList();
}
static void UL1StringAfterExisting(UnsortedType<string>& UL1)
{

    //The code below is my own workaround to avoid to avoid using the function "InsertAfterItem" from SortedType.cpp. Function that I got it from internet. 

    //this is a function to retrieve the item directly , i have explained the function inside SortedType.cpp file
   // If my work around not alright please uncomment the below function call and comment the other code 
    //***UL1.InsertAfterItem(existingItem, itemToAdd)****;

    //comment from here 
    UnsortedType<string> ul1;
    string item;
    string itemToAdd = "";
    string existingItem = "";

    cout << "Input String to add to the list: ";
    cin >> itemToAdd;
    cout << "Input existing String: ";
    cin >> existingItem;
    int count = 0;
    bool found = false;
    //this loops until it finds the specified item 
    //if not found it inserts all the items from UL1 to ul1
    ul1.SetCurrentPos(); 
    for (int i = 0; i < UL1.LengthIs(); i++) {

        UL1.GetNextItem(item); // Get the current item in the list
        count++;
   
        ul1.InsertItem(item);
        if (item == existingItem) {
            ul1.InsertItem(itemToAdd);
            found = true;
            break; // Stop iterating  when searched is found
        }
    }
    //starts at from where it has stopped in the function above 
    //and inserts the remaining items in the ul1
    for (int i = count; i < UL1.LengthIs(); i++)
    {
        UL1.GetNextItem(item);
        if (i == count)
        {
            count++;
            ul1.InsertItem(item);
        }
    }
    UL1.MakeEmpty();
    //if item has not been found
    if (found == false)
    {
        //inserts the item at the end of the list
        ul1.InsertItem(itemToAdd);
    }
    for (int i = 0; i < ul1.LengthIs(); i++)
    {
        // retrieves the items from the ul1 and inserts it in the UL1
        ul1.GetNextItem(item);
        UL1.InsertItem(item);

    }
    //Resets the position at the begining of the list
    UL1.ResetList();

    //comment until here

    cout << endl;
    cout << "UL1 : ";    UL1.PrintList(); //prints list


}
static void MergeContents(UnsortedType<string>& UL1, SortedType<string>& OL1, SortedType<string>& OL2) {
    string currentItem;
    bool found;

    UL1.ResetList();  //Resets the  current position
    for (int i = 0; i < UL1.LengthIs(); i++)
    {
        UL1.GetNextItem(currentItem);  //returns the item in currentItem
        if (currentItem == "")
        {
            break; //loops out when item= null
        }

        //returns the item in currentItem if it finds it
        OL2.RetrieveItem(currentItem, found);
        if (!found)
        {
            OL2.InsertItem(currentItem);  //add to the list in order
        }
    }

    OL1.ResetList();
    for (int i = 0; i < OL1.LengthIs(); i++)
    {
        OL1.GetNextItem(currentItem); // returns the item in currentItem
        if (currentItem == "")
        {
            break;
        }
        OL2.RetrieveItem(currentItem, found);  //returns the item in currentItem if it finds it (found= true)
        if (!found)
        {
            OL2.InsertItem(currentItem);   // inserts the item in OL2
        }
    }
    cout << endl << "OL2: ";
    OL2.PrintList();
}
static void PrintContents(UnsortedType<string>& UL1, SortedType<string>& OL1, SortedType<string>& OL2)
{
    cout << endl;
    if (UL1.LengthIs() == 0)// if the list is empty prints message
    {
        cout << "UL1. List is empty ";
    }
    else
    {
        cout << "UL1:"; UL1.PrintList(); //prints the list 

    }
    if (OL1.LengthIs() == 0)  // if the list is empty prints message
    {
        cout << "OL1 List is empty " << endl;;
    }
    else
    {
        cout << "OL1:"; OL1.PrintList();

    }
    if (OL2.LengthIs() == 0)
    {
        cout << "OL2 List is empty " << endl;
    }
    else
    {
        cout << "OL2:";  OL2.PrintList();

    }

}
static void DeleteItemFromOL2(SortedType<string>& OL2, string input) {
    
    bool found = false;
    for (int i = 0; i < OL2.LengthIs(); i++)
    {
        string item;
        OL2.GetNextItem(item); //returns the next item in the list
        if (item == input) //check if item equal to the input value
        {
            OL2.DeleteItem(item);  //delete the item
            found = true;
            break;
        }
    }
    if (found=true)
    {
        cout << endl << "'" + input + "'" + " has not been found : ";
    }
    cout << endl << "OL2 : "; OL2.PrintList();
}


static void ReverseList(SortedType<string>& OL2) {

    OL2.ReverseList(); //reverse the list 
    cout << "Reversed OL2:";
    OL2.PrintList(); // prints the list 

}