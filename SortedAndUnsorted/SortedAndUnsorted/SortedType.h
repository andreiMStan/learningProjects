#pragma once

// Class is templated.
template <class ItemType>
struct NodeType;

template <class ItemType>
class SortedType {
public:
    SortedType();	    // Class constructor
    ~SortedType();   	// Class destructor

    void MakeEmpty();
    // Function:    Initializes list to empty state.
    // Post:        List is empty.

    bool IsFull() const;
    // Function:    Determines whether list is full.
    // Post:        Function value = (list is full)

    int  LengthIs() const;
    // Function:    Determines the number of elements in list.
    // Post:        Function value = number of elements in list.

    void ResetList();
    // Function:    Initializes current position for an iteration through the list.
    // Post:        Current position is prior to the first element on the list.

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
    // Function:    Adds item to the correct position in the sorted list
    // Pre:         List is not full. Item is not in list.
    // Post:        Item is in list.

    void DeleteItem(ItemType item);
    // Function:    Deletes the element whose key matches item's key.
    // Pre:         Key member of item is initialized.
    //              One and only one element in list has a key matching item's key.
    // Post:        No element in list has a key matching item's key.    

    void InsertItemUnorderd(ItemType item);

    void RetrieveItem(ItemType& item, bool& found);
    // Function:    Retrieves list element whose key matches item's key (if present).
    // Pre:         Key member of item is initialized.
    // Post:        If there is an element someItem whose key matches item's key,
    //              then found = true and item is a copy of someItem; 
    //              otherwise found = false and item is unchanged.
    //              List is unchanged.
    void ReverseList();
    void FindItem(NodeType <ItemType>* listData, //pointer to list start
        ItemType item, //item to find
        NodeType <ItemType>*& location,//pointer to location
        NodeType <ItemType>*& predLoc, //pointer to pred loc
        bool& found);
    // void MergeContents(UnsortedType<ItemType>& UL1, SortedType<ItemType>& OL1, SortedType<ItemType>& OL2);
private:
    NodeType<ItemType>* listData;
    int length;
    NodeType<ItemType>* currentPos;
};