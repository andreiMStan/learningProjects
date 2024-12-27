#pragma once

// Class is templated.
template <class ItemType>
struct NodeType;

template <class ItemType>
class UnsortedType {
public:
    UnsortedType();	    // Class constructor
    ~UnsortedType();   	// Class destructor

    void MakeEmpty();
    // Function:    Initializes list to empty state.
    // Pre:         None
    // Post:        List is empty.

    bool IsFull() const;
    // Function:    Determines whether list is full.
    // Pre:         List has been initialized (filled)
    // Post:        Function value = (list is full)

    int  LengthIs() const;
    // Function:    Determines the number of elements in list.
    // Pre:         List has been initialized (filled)
    // Post:        Function value = number of elements in list.

    void ResetList();
    // Function:    Initializes current position for an iteration through the list.
    // Post:        Current position is prior to the first element of the list.

    void GetNextItem(ItemType&);
    // Function:    Gets the next element in list.
    // Pre:         Current position is defined.
    //              Element at current position is not last in list.
    // Post:        Current position is updated to next position.
    //              Item is a copy of element at current position.

    void PrintList();
    // Function:    Print the contents of the list
    // Post:        List is unchanged

    NodeType<ItemType>* GetCurrentPos();
    // return type is pointer to current node
    // Function:    Get the current postion on a list
    // Post:        List is unchanged

    void SetCurrentPos();
    // Function:    Set the current postion on a list
    // Post:        List is unchanged

    void MoveToNextItem();
    // Function:    Move the position on to the next item on the list
    // Post:        List is unchanged

    void InsertItem(ItemType item);
    // Function:    Adds item to the list (Start of Unsorted List)
    // Pre:         List is not full. Item is not in list.
    // Post:        Item is in list.

    void DeleteItem(ItemType item);
    // Function:    Deletes the element whose key matches item's key.
    // Pre:         Key member of item is initialized.
    //              One and only one element in list has a key matching item's key.
    // Post:        No element in list has a key matching item's key.    

    void RetrieveItem(ItemType& item, bool& found);
    // Function:    Retrieves list element whose key matches item's key (if present).
    // Pre:         List and Key member of item is initialized.
    // Post:        If there is an element someItem whose key matches item's key,
    //              then found = true and item is a copy of someItem; 
    //              otherwise found = false and item is unchanged.
    //              List is unchanged.
    
    void InsertAfterItem(const ItemType& existingItem, const ItemType& newItem);
    void FindItem(NodeType<ItemType>* listData, ItemType item,
        NodeType<ItemType>*& location, NodeType<ItemType>*& predLoc, bool& found);
private:
    NodeType<ItemType>* listData;
    int length;
    NodeType<ItemType>* currentPos;
};