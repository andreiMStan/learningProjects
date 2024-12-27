#pragma once

// Class is templated.
template <class ItemType>
struct NodeType;

template<class ItemType>
class StackType {
public:
    StackType();     // Class constructor.
    ~StackType();    // Class destructor.

    void PrintStack();
    // Function:	Print the contents of the stack.
    //				Prints from the top down.

    bool IsFull() const;
    // Function:    Determines whether the stack is full.
    // Pre:         Stack has been initialized.
    // Post:        Function value = (stack is full)

    bool IsEmpty() const;
    // Function:    Determines whether the stack is empty.
    // Pre:         Stack has been initialized.
    // Post:        Function value = (stack is empty)

    void MakeEmpty();
    // Function:    Sets stack to an empty state.
    // Post:        Stack is empty.

    void Pop(ItemType& item);
    // Function:    Removes top item from the stack and returns it in item.
    // Pre:         Stack has been initialized and is not empty.
    // Post:        Top element has been removed from stack. 
    //              item is a copy of the removed item.

    void Push(ItemType item);
    // Function:    Adds newItem to the top of the stack.
    // Pre:         Stack has been initialized and is not full.
    // Post:        newItem is at the top of the stack.

private:
    NodeType<ItemType>* topPtr;
};
