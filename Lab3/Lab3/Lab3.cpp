#include "UnsortedType.h"
#include "UnsortedType.cpp"

    int main() {
    // Create a string USL
    UnsortedType<string> ust;
    //Add items to the list
    ust.InsertItem("Hello"); ust.InsertItem("Today"); ust.InsertItem("Is");
    ust.InsertItem("Tuesday");
    //Delete
    ust.DeleteItem("Hello");
    // Print List
    cout << "List = "; ust.PrintList();
    //get length of List
    cout << "Length of List is " << ust.LengthIs() << endl << endl;
    //check if List is full
    if (ust.IsFull())
        cout << "List is full" << endl << endl;
    else
        cout << "List is not full" << endl << endl;
    //check for particular items
    bool found;
    string val1 = "Tuesday";
    string val2 = "Wednesday";
    ust.RetrieveItem(val1, found);
    if (found == 1)
        cout << val1 << " was found in List " << endl;
    else
        cout << val1 << " was not found in List " << endl;
    ust.RetrieveItem(val2, found);
    if (found == 1)
        cout << val2 << " was found in List " << endl;
    else
        cout << val2 << " was not found in List " << endl << endl;
    //make List empty
    ust.MakeEmpty();
    cout << "List after emptied = ";
    ust.PrintList();
    return 0;
}
