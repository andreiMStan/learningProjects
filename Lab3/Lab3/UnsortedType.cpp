// Implementation file for Unsorted List ADT.
// Class specification in file Unsorted.h
// Class is templated.
using namespace std;
#include <iostream>
#include "UnsortedType.h"

template<class ItemType>
//each node consists of it's data and a pointer to the next node
struct NodeType {
    ItemType info;
    NodeType<ItemType>* next;
};

template <class ItemType>
UnsortedType<ItemType>::UnsortedType() {
    // Class constructor
    length = 0;
    listData = NULL;
}

template <class ItemType>
UnsortedType<ItemType>::~UnsortedType() {
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
void UnsortedType<ItemType>::MakeEmpty() {
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
bool UnsortedType<ItemType>::IsFull() const {
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
int UnsortedType<ItemType>::LengthIs() const {
    // Function:    Determines the number of elements in list.
    // Post:        Number of items in the list is returned.
    return length;
}

template <class ItemType>
void UnsortedType<ItemType>::ResetList() {
    // Post: Current position has been initialized.
    currentPos = NULL;
}

template <class ItemType>
void UnsortedType<ItemType>::GetNextItem(ItemType& item) {
    // Post:  Current position has been updated; item is current item.
    if (currentPos == NULL)
        currentPos = listData;
    else
        currentPos = currentPos->next;
    item = currentPos->info;
}

template <class ItemType>
void UnsortedType<ItemType>::PrintList() {
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
NodeType<ItemType>* UnsortedType<ItemType>::GetCurrentPos() {
    return currentPos;
}

template <class ItemType>
void UnsortedType<ItemType>::SetCurrentPos() {
    currentPos = listData;
}

template <class ItemType>
void UnsortedType<ItemType>::MoveToNextItem() {
    if (currentPos != NULL)
        currentPos = currentPos->next;
}

template <class ItemType>
void UnsortedType<ItemType>::InsertItem(ItemType item) {
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
void UnsortedType<ItemType>::RetrieveItem(ItemType& item, bool& found) {
    // Pre:  Key member of item is initialized.
    // Post: If found, item's key matches an element's key in the list and 
    //       a copy of that element has been stored in item; 
    //       otherwise, item is unchanged. 
    bool moreToSearch;
    NodeType<ItemType>* location;
    location = listData;
    found = false;
    moreToSearch = (location != NULL);
    while (moreToSearch && !found) {
        if (item == location->info) {
            found = true;
            item = location->info;
        }
        else {
            location = location->next;
            moreToSearch = (location != NULL);
        }
    }
}

template <class ItemType>
void UnsortedType<ItemType>::DeleteItem(ItemType item) {
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

template <class ItemType>
void UnsortedType<ItemType>::FindItem(NodeType<ItemType>* listData, ItemType item,
    NodeType<ItemType>*& location, NodeType<ItemType>*& predLoc, bool& found) {
    bool moreToSearch = true;
    predLoc = nullptr;                // Initialize predecessor as nullptr
    location = listData;              // Start from the first node
    found = false;

    // Loop until item is found or end of list is reached
    while (moreToSearch && !found && location != nullptr) {
        if (location->info == item) {
            found = true;             // Item found
        }
        else {
            predLoc = location;       // Move predecessor up
            location = location->next; // Move to the next node
            moreToSearch = (location != nullptr);
        }
    }
}

// Function to insert a new item after a specified existing item
template <class ItemType>
void UnsortedType<ItemType>::InsertAfterItem(const ItemType& existingItem, const ItemType& newItem) {
    NodeType<ItemType>* location;
    NodeType<ItemType>* predLoc;
    bool found;

    // Use FindItem to locate the existingItem
    FindItem(listData, existingItem, location, predLoc, found);

    // Create new node for newItem
    NodeType<ItemType>* newNode = new NodeType<ItemType>;
    newNode->info = newItem;

    if (found) {
        // Insert newNode after the found item
        newNode->next = location->next;
        location->next = newNode;
    }
    else {
        // If existingItem was not found, insert at the end
        if (listData == nullptr) { // List is empty
            listData = newNode;
        }
        else { // Insert at end
            NodeType<ItemType>* temp = listData;
            while (temp->next != nullptr) {
                temp = temp->next;
            }
            temp->next = newNode;
        }
        newNode->next = nullptr;
    }
    length++;
}