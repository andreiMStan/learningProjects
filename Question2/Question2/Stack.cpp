// Implementation file for Stack ADT.
// Class definition is in "Stack.h".
// Class is templated
// Uses linked list of items with a pointer to the top
using namespace std;
#include <iostream>
#include "Stack.h"

template <class ItemType>
//each node consists of it's data and a pointer to the next node
struct NodeType {
				ItemType info;
				NodeType<ItemType>* next;
};

template<class ItemType>
StackType<ItemType>::StackType() {
				//class constructor
				topPtr = NULL;
}

template <class ItemType>
StackType<ItemType>::~StackType() {
				// Function:    Class destructor
				// Post:        Stack is empty; all items have been deallocated.
				NodeType<ItemType>* tempPtr;
				while (topPtr != NULL) {
								tempPtr = topPtr;
								topPtr = topPtr->next;
								delete tempPtr;
				}
}

template <class ItemType>
void StackType<ItemType>::PrintStack() {
				// Function:	Print the contents of the stack.
				//				Prints from the top down.
				NodeType<ItemType>* tempPtr;
				tempPtr = topPtr;
				if (tempPtr == NULL)
								cout << "EMPTY STACK" << endl;
				else {
								while (tempPtr != NULL) {
												cout << tempPtr->info << " ";
												tempPtr = tempPtr->next;
								}
				}
				cout << endl;
}

template<class ItemType>
bool StackType<ItemType>::IsFull() const {
				// Function:    Determines whether stack is full.
				//			    Returns true if there is no room for another ItemType on the top
				//              false otherwise
				NodeType<ItemType>* tempPtr;
				tempPtr = new NodeType<ItemType>;
				if (tempPtr == NULL)
								return true;
				else {
								delete tempPtr;
								return false;
				}
}

template <class ItemType>
bool StackType<ItemType>::IsEmpty() const {
				// Function:    Determines whether the stack is empty
				//				by checking if the pointer to the top is null
				return (topPtr == NULL);
}

template <class ItemType>
void StackType<ItemType>::MakeEmpty() {
				// Function:    Initializes stack to empty state
				// Post:        All items have been deallocated
				NodeType<ItemType>* tempPtr;
				while (topPtr != NULL) {
								tempPtr = topPtr;
								topPtr = topPtr->next;
								delete tempPtr;
				}
}

template<class ItemType>
void StackType<ItemType>::Pop(ItemType& item) {
				// Function:    Removes top item from the stack and returns it in item.
				NodeType<ItemType>* tempPtr;
				item = topPtr->info;
				tempPtr = topPtr;
				topPtr = topPtr->next;
				delete tempPtr;
}

template <class ItemType>
void StackType<ItemType>::Push(ItemType newItem) {
				// Function:    Adds newItem to the top of the stack.
				NodeType<ItemType>* location;
				location = new NodeType<ItemType>;
				location->info = newItem;
				location->next = topPtr;
				topPtr = location;
}