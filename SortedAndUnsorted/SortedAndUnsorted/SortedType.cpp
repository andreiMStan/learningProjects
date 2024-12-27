// Implementation file for Sorted List ADT.
// Class specification in file Sorted.h
// Class is templated.
using namespace std;
#include <iostream>
#include "SortedType.h"


//template<class ItemType>
////each node consists of it's data and a pointer to the next node
////struct NodeType {
////    ItemType info;
////    NodeType<ItemType>* next;
////};

template <class ItemType>
SortedType<ItemType>::SortedType() {
    // Class constructor
    length = 0;
    listData = NULL;
}

template <class ItemType>
SortedType<ItemType>::~SortedType() {
    // Function:    Class destructor
    // Post:        List is empty; all items have been deallocated.
    NodeType<ItemType>* tempPtr;
    while (listData != NULL) {
        tempPtr = listData;
        listData = listData->next;
        delete tempPtr;
    }
    length = 0;
}

template <class ItemType>
void SortedType<ItemType>::MakeEmpty() {
    // Function:    Initializes list to empty state
    // Post:        All items have been deallocated, length is 0
    NodeType<ItemType>* tempPtr;
    while (listData != NULL) {
        tempPtr = listData;
        listData = listData->next;
        delete tempPtr;
    }
    length = 0;
}


template <class ItemType>
bool SortedType<ItemType>::IsFull() const {
    // Function:    Returns true if there is no room for another ItemType
    //              on the free store; false otherwise
    NodeType<ItemType>* ptr;
    ptr = new NodeType<ItemType>;
    if (ptr == NULL)
        return true;
    else {
        delete ptr;
        return false;
    }
}

template <class ItemType>
int SortedType<ItemType>::LengthIs() const {
    // Function:    Determines the number of elements in list.
    // Post:        Number of items in the list is returned.
    return length;
}

template <class ItemType>
void SortedType<ItemType>::ResetList() {
    // Post: Current position has been initialized.
    currentPos = NULL;
}

template <class ItemType>
void SortedType<ItemType>::GetNextItem(ItemType& item) {
    // Post:  Current position has been updated; item is current item.
    if (currentPos == NULL)
        currentPos = listData;
    else
        currentPos = currentPos->next;
    item = currentPos->info;
}

template <class ItemType>
void SortedType<ItemType>::PrintList() {
    NodeType<ItemType>* tempPtr;
    tempPtr = listData;
    if (tempPtr == NULL)
        cout << "EMPTY LIST" << endl;
    else {
        while (tempPtr != NULL) {
            cout << tempPtr->info << " ";
            tempPtr = tempPtr->next;
        }
        cout << endl;
    }
    cout << endl;
}


template <class ItemType>
NodeType<ItemType>* SortedType<ItemType>::GetCurrentPos() {
    return currentPos;
}

template <class ItemType>
void SortedType<ItemType>::SetCurrentPos() {
    currentPos = listData;
}

template <class ItemType>
void SortedType<ItemType>::ReverseList() {
    NodeType<ItemType>* previous = nullptr;
    NodeType<ItemType>* current = listData;
    NodeType<ItemType>* next = nullptr;

    // Traverse the list and reverse the direction of the links
    while (current != nullptr) {
        next = current->next;   // Save next node
        current->next = previous;  // Reverse the current node's link
        previous = current;  // Move previous to this node
        current = next;  // Move to next node
    }

    // Update head to point to the new front of the list
    listData = previous;
}

template <class ItemType>
void SortedType<ItemType>::FindItem(NodeType <ItemType>* listData, //pointer to list start
    ItemType item, //item to find
    NodeType <ItemType>*& location,//pointer to location
    NodeType <ItemType>*& predLoc, //pointer to pred loc
    bool& found) { //found flag
    bool moreToSearch = true; //used to loop through list
    predLoc = listData; //list start
    location = listData->next, //next item after list start
        found = false;

    while (moreToSearch && !found) { //while more list to search

        if (item < location->info) //if list item > my item
            moreToSearch = false; //search over item !found
        else if (item == location->info)
            found = true;

        else
        {
            predLoc = location;
            location = location->next;
            moreToSearch = (location != listData->next);
            //nudge everything on – location & predecessor
            //location and reset moreToSearch
        }
    }
}


template <class ItemType>
void SortedType<ItemType>::MoveToNextItem() {
    if (currentPos != NULL)
        currentPos = currentPos->next;
}
template <class ItemType>
void SortedType<ItemType>::InsertItemUnorderd(ItemType item) {
    // Function:Adds item to the list (start of unordered list)
    // Post:    item is in the list; length has been incremented.
    NodeType<ItemType>* location;
    location = new NodeType<ItemType>;
    location->info = item;
    location->next = listData;
    listData = location;
    length++;
}
template <class ItemType>
void SortedType<ItemType>::InsertItem(ItemType item) {
    // Function:Adds item to the correct position in the sorted list
    // Post:    item is in the list; length has been incremented.
    NodeType<ItemType>* newNode;
    // pointer to node being inserted
    NodeType<ItemType>* predLoc;
    // trailing pointer
    NodeType<ItemType>* location;
    // traveling pointer
    bool moreToSearch;
    location = listData;
    predLoc = NULL;
    moreToSearch = (location != NULL);
    // Find insertion point.
    while (moreToSearch) {
        if (location->info < item) {
            predLoc = location;
            location = location->next;
            moreToSearch = (location != NULL);
        }
        else
            moreToSearch = false;
    }
    // Prepare node for insertion
    newNode = new NodeType<ItemType>;
    newNode->info = item;
    // Insert node into list.
    if (predLoc == NULL) {
        // Insert as first
        newNode->next = listData;
        listData = newNode;
    }
    else {
        newNode->next = location;
        predLoc->next = newNode;
    }
    length++;
}

template <class ItemType>
void SortedType<ItemType>::RetrieveItem(ItemType& item, bool& found) {
    // Pre:  Key member of item is initialized.
    // Post: If found, item's key matches an  element's key in the list and 
    //       a copy of that element has been stored in item; 
    //       otherwise, item is unchanged. 
    bool moreToSearch;
    NodeType<ItemType>* location;
    location = listData;
    found = false;
    moreToSearch = (location != NULL);
    while (moreToSearch && !found) {
        if (location->info < item) {
            location = location->next;
            moreToSearch = (location != NULL);
        }
        else if (item == location->info) {
            found = true;
            item = location->info;
        }
        else
            moreToSearch = false;
    }
}

template <class ItemType>
void SortedType<ItemType>::DeleteItem(ItemType item) {
    // Pre:     item's key has been initialized.
    //          An element in the list has a key that matches item's.
    // Post:    No element in the list has a key that matches item's.
    NodeType<ItemType>* location = listData;
    NodeType<ItemType>* tempLocation;
    // Locate node to be deleted.
    if (item == listData->info) {
        tempLocation = location;
        listData = listData->next;
        // Delete first node.
    }
    else {
        while (!(item == (location->next)->info))
            location = location->next;
        // Delete node at location->next
        tempLocation = location->next;
        location->next = (location->next)->next;
    }
    delete tempLocation;
    length--;
}