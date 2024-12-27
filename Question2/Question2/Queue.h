#pragma once
#pragma once

//class is templated
template <class ItemType>
struct NodeType;

template <class ItemType>
class QueType {
public:
    QueType();		// Class constructor.
    ~QueType();		// Class destructor.    

    void PrintQueue();
    // Function: 	Prints the contents of the queue from the front to the rear
    //              Queue is unchanged

    bool IsFull() const;
    // Function: 	Determines whether the queue is full.
    // Post: 		Function value = (queue is full)

    bool IsEmpty() const;
    // Function: 	Determines whether the queue is empty.
    // Post: 		Function value = (queue is empty)

    void MakeEmpty();
    // Function: 	Initializes the queue to an empty state.
    // Post: 		Queue is empty. All elements have been deallocated

    void Enqueue(ItemType newItem);
    // Function: 	Adds newItem to the rear of the queue.
    // Pre:  		Queue is not full.
    // Post: 		newItem is at the rear of the queue.

    void Dequeue(ItemType& item);
    // Function: 	Removes front item from the queue and returns it in item.
    // Pre:  		Queue is not empty.
    // Post: 		Front element has been removed from the queue.
    // 				item is a copy of the removed element.
   // QueType(const QueType<ItemType>& other);
private:
    NodeType<ItemType>* qFront;
    NodeType<ItemType>* qRear;
};