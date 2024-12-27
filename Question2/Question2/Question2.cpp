// StackProject.cpp : This file contains the 'main' function. Program execution begins and ends there.

using namespace std;

#include <iostream>
#include <fstream>
#include "Stack.h"
#include "Stack.cpp"
#include "Queue.h"
#include "Queue.cpp"
int choice;
QueType<string> Q1; //Create the queue
QueType<string> Q2; //Create the queue
QueType<string> Q3; //Create the queue

void Menu();
void InputStringFromKeyboard(QueType<string>& Q1);
void InputStringFromFile(QueType<string>& Q2);
void MergeQueues(QueType<string>& Q1, QueType<string>& Q2, QueType<string>& Q3);
void RemoveItem(QueType<string>& Q3);
void ReverseQueue(QueType<string>& Q3);
void SearchItem(QueType<string>& Q3, string input);
void ClearQueue(QueType<string>& Q1);
void PrintContents(QueType<string>& Q1, QueType<string>& Q2, QueType<string>& Q3);

int main() {

    string input;

    cout << ("Queue And Stacks") << endl;
    do
    {

        Menu();
        cin >> choice;
        cout << endl;
        switch (choice)
        {
        case 1:

            // Add items and prints items
            InputStringFromKeyboard(Q1);
            break;

        case 2:
            //Input string from a file
            InputStringFromFile(Q2);
            break;

        case 3:
            //Merge Q1 and Q2 into Q3
            MergeQueues(Q1, Q2, Q3);

            break;

        case 4:
            //Remove item From Q2
            RemoveItem(Q3);
            break;

        case 5:
            //Reverse Q2
            ReverseQueue(Q3);
            break;

        case 6:
            //Search item in Q3
            cout << "Enter string:";
            cin >> input;
            SearchItem(Q3, input);
            break;

        case 7:
            //Clear Q1
            ClearQueue(Q1);
            break;

        case 8:
            //Print Contents of Q1 Q2 Q3 
            PrintContents(Q1, Q2, Q3);
            break;

        case 9:
            cout << ("Exiting the system...");
            break;

        default:
            cout << ("Invalid choice. Please try again.");
            break;
        }
    } while (choice != 9);


    return 0;

}

// Menu system

static void Menu() {
    // Menu system
    cout << endl;
    cout << ("1.Input StringS to Q1 from KeyBoard") << endl;
    cout << ("2.Insert Strings from a File to Q2") << endl;
    cout << ("3.Merge Q1 and Q2 into Q3(No Duplicates)") << endl;
    cout << ("4.Remove and Print from Q3") << endl;
    cout << ("5.Reverse Q3 into stack S1") << endl;
    cout << ("6.Search String in Q3") << endl;
    cout << ("7.Clear Q1") << endl;
    cout << ("8.Print Q1,Q2,Q3") << endl;
    cout << ("9.Exit") << endl;
    cout << endl;
    cout << ("Enter your choice: ");

}
static void InputStringFromKeyboard(QueType<string>& Q1)
{
    // Add items
    string input = "";
    cout << "Input string or -1 to exit";
    cout << endl;
    cin >> input;
    while (input != "-1")
    {
        //inserts the content into Q1
        Q1.Enqueue(input);
        cin >> input;
    }
    // Print Contents
    cout << endl << "Q1 = ";    Q1.PrintQueue();
    cout << endl;
}
static void InputStringFromFile(QueType<string>& Q2)
{

    ifstream infile("myFile.txt");
    if (!infile.is_open())
        cout << "file could not be opened\n";
    else {
        string first;
        while (infile >> first)
        {
            Q2.Enqueue(first);
        }
        infile.close();
    }
    cout << "Q2 = ";
    Q2.PrintQueue();
}
static void MergeQueues(QueType<string>& Q1, QueType<string>& Q2, QueType<string>& Q3)
{
    //This is my workaround to no implement another function with pointers 
    QueType<string> q1;
    QueType<string> q2;
    const int MAX_SIZE = 100;
    string elements[MAX_SIZE];
    int count = 0;
    string item;

    while (!Q1.IsEmpty())
    {
        Q1.Dequeue(item);
        bool isDuplicate = false;
        //in this iteration I check for the duplicates
        for (int i = 0; i < count; i++) {
            if (elements[i] == item) {
                isDuplicate = true;
                break;
            }
        }
        // Add the item to the array if it's not a duplicate
        if (!isDuplicate) {
            elements[count++] = item;
        }
        q1.Enqueue(item);
    }
    // Check if the item is already in the array
    while (!q1.IsEmpty())
    {
        q1.Dequeue(item);
        Q1.Enqueue(item);
    }
    // Extract all items from Q2
    while (!Q2.IsEmpty())
    {
        Q2.Dequeue(item);
        // elements[count++] = item;  // Store item in the array
        bool isDuplicate = false;
        for (int i = 0; i < count; i++) {
            if (elements[i] == item) {
                isDuplicate = true;
                break;
            }
        }
        // Add the item to the array if it's not a duplicate
        if (!isDuplicate) {
            elements[count++] = item;
        }
        q2.Enqueue(item);
    }
    //Enqueue back in Q2
    while (!q2.IsEmpty())
    {
        q2.Dequeue(item);
        Q2.Enqueue(item);
    }

    // this is a bubble sort to to sort elements alphabetically

    for (int i = 0; i < count; i++)
    {
        for (int j = 0; j < count - i - 1; j++)
        {
            if (elements[j] > elements[j + 1])  // Swap if out of order
            {
                string temp = elements[j];
                elements[j] = elements[j + 1];
                elements[j + 1] = temp;
            }
        }
    }
    //Ensure the Q3 is empty
    Q3.MakeEmpty();
    // Enqueue the sorted elements into Q3
    for (int i = 0; i < count; i++)
    {
        Q3.Enqueue(elements[i]);
    }
    cout << endl << "Q3:"; Q3.PrintQueue();
    cout << endl;
}
static void RemoveItem(QueType<string>& Q3) {
    string item;
    Q3.Dequeue(item);//dequeue item in from the queue
    cout << "Item removed: " + item;
    cout << endl;
}
static void ReverseQueue(QueType<string>& Q3)
{
    //new stack to enqueue the items from Q3

    StackType<string> S1;
    string item;
    while (!Q3.IsEmpty())//loop until Queue empty
    {
        Q3.Dequeue(item);//deque the items 
        S1.Push(item);// push the items into stack
    }
    string item1;
    //push back the items into the Q3 after poping out from the stack
    while (!S1.IsEmpty())
    {
        S1.Pop(item1);
        Q3.Enqueue(item1);
    }
    cout << "Reversed Q3 : "; Q3.PrintQueue();
}
static void SearchItem(QueType<string>& Q3, string input)
{
    //this is my workaround to not set up another function with pointers , as pe requirements i have used only the function provided from class

    //below i am setting up a new queue q3
    string item;
    bool found = false;
    QueType<string> q3;

    //Deque Q3 (while dequeue if item found make bool variable to true  and enqueue back into Q3 
    while (!Q3.IsEmpty())
    {
        Q3.Dequeue(item);
        if (input == item)
        {
            found = true;
        }
        q3.Enqueue(item);
    }
    //enqueue back into Q3 from q3
    while (!q3.IsEmpty())
    {
        q3.Dequeue(item);
        Q3.Enqueue(item);
    }
    if (found)
    {
        cout << endl << "'" + input + "' " + "has been found in Q3" << endl;
    }
    else
    {
        cout << endl << "'" + input + "' " + "has not been found in Q3" << endl;
    }
}

static void ClearQueue(QueType<string>& Q1) {
    string item;
    while (!Q1.IsEmpty())
    {
        //dequeue all items until Q1 is empty
        Q1.Dequeue(item);
    }
    if (Q1.IsEmpty())
    {
        cout << "Q1 is empty" << endl;
    }
}
static void PrintContents(QueType<string>& Q1, QueType<string>& Q2, QueType<string>& Q3)
{
    //print the contents of the list
    cout << endl << "Contents of the list Q1:";
    Q1.PrintQueue();
    cout << "Contents of the list Q2:";
    Q2.PrintQueue();
    cout << "Contents of the list Q3:";
    Q3.PrintQueue();


}
