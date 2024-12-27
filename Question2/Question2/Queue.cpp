// Implementation file for Queue ADT
// Class definition file Queue.h
// Class is templated
// Uses linked list of items with a pointer to the head and one to the tail.
using namespace std;
#include <iostream>
#include "Queue.h"

//template <class ItemType>
//////each node consists of it's data and a pointer to the next node
//struct NodeType {
//    ItemType info;
//    NodeType<ItemType>* next;
//};

template <class ItemType>
QueType<ItemType>::QueType() {
    // Class constructor.
    // Post:        qFront and qRear are set to NULL.
    qFront = NULL;
    qRear = NULL;


}
//template <class ItemType>
//QueType<ItemType>::QueType(const QueType<ItemType>& other) {
//    qFront = qRear = nullptr; // Initialize an empty queue
//
//    NodeType<ItemType>* tempPtr = other.qFront; // Start from the front of the other queue
//    while (tempPtr != nullptr) {
//        Enqueue(tempPtr->info);  // Enqueue each element from the other queue
//        tempPtr = tempPtr->next; // Move to the next node
//    }
//}
template <class ItemType>
QueType<ItemType>::~QueType() {
    // Class destructor.
    MakeEmpty();
}

template <class ItemType>
void QueType<ItemType>::PrintQueue() {
    // Function:	Print the contents of the queue.
    //				Prints from the front to the rear.
    NodeType<ItemType>* tempPtr;
    tempPtr = qFront;
    if (tempPtr == NULL)
        cout << "EMPTY QUEUE";
    else {
        while (tempPtr != NULL) {
            cout << tempPtr->info << " ";
            tempPtr = tempPtr->next;
        }
    }
    cout << endl;
}

template <class ItemType>
bool QueType<ItemType>::IsFull() const {
    // Function:    Determines if the queue is full
    //              Returns true if there is no room for another ItemType on the free store;
    //              false otherwise.
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
bool QueType<ItemType>::IsEmpty() const {
    // Function     Determines if the queue is empty
    //              Returns true if there are no elements on the queue; false otherwise.
    return (qFront == NULL);
}

template <class ItemType>
void QueType<ItemType>::MakeEmpty() {
    // Function: 	Initializes the queue to an empty state.
    // Post: 		Queue is empty. All elements have been deallocated
    NodeType<ItemType>* tempPtr;
    while (qFront != NULL) {
        tempPtr = qFront;
        qFront = qFront->next;
        delete tempPtr;
    }
    qRear = NULL;
}

template <class ItemType>
void QueType<ItemType>::Enqueue(ItemType newItem) {
    // Function: 	Adds newItem to the rear of the queue.
    // Pre:  		Queue has been initialized (has data) and is not full.
    // Post: 		newItem is at the rear of the queue.
    NodeType<ItemType>* newNode;
    newNode = new NodeType<ItemType>;
    newNode->info = newItem;
    newNode->next = NULL;
    if (qRear == NULL)
        qFront = newNode;
    else
        qRear->next = newNode;
    qRear = newNode;
}

template <class ItemType>
void QueType<ItemType>::Dequeue(ItemType& item) {
    // Function:	Removes front item from the queue and returns it in item.
    // Pre:  		Queue has been initialized (has data) and is not empty.
    // Post: 		Front element has been removed from queue.
    //       		item is a copy of removed element.
    NodeType<ItemType>* tempPtr;
    tempPtr = qFront;
    item = qFront->info;
    qFront = qFront->next;
    if (qFront == NULL)
        qRear = NULL;
    delete tempPtr;
}