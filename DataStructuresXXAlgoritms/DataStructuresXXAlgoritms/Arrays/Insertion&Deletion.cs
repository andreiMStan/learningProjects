

////Arrays 
////Array Insertion & Deletion

////Insert at the end of an array 

//int[] intArray = new int[6];

////Make a variable to keep the length because .Length is based off capacity and dose not track the actual index
//int length = 0;

//// this adds data for us
//for (int i = 0; i < 3; i++)
//{

// intArray[length] = i + 1;
// length++;
//}

////intArray[length] = 8;
////length++;

////Insert at the start of an array 

//for (int i = 3; i >= 0; i--)
//{
// //this is moving over all the values;
// intArray[i + 1] = intArray[i];
//}
//intArray[0] = 20;

//int value = 0;




// int[] intArray = new int[10];

//int length = 0;

//for (int i = 0; i < 8; i++)
//{

// intArray[length] = i + 1;
// length++;
//}

// for (int i = 4; i >= 8; i--)
//{
// //shifting each element one position to the right
// intArray[i + 1] = intArray[i];
//}

//intArray[2] = 8;

//int value = 0;



//deletion array end


//int[] intArray = new int[10];

//int length = 0;

//for (int i = 0; i < 8; i++)
//{

// intArray[length] = i + 1;
// length++;
//}
////decresing lenght of array so won't print the last
//length--;

// for (int i = 0; i < length; i++)
//{
//    Console.WriteLine(i);
//}



//Deletion from everywhere





//int[] intArray = new int[9];

//int length = 0;

//for (int i = 0; i < 6; i++)
//{
// //add +1  at i  for deletion at the end
// intArray[length] = i;
// length++;
//}
////deletion heere will delete position 1 
//for (int i = 2; i < length; i++)
//{
// intArray[i - 1] = intArray[i];
//}
//length--;

//for (int i = 0; i < length; i++)
//{
// Console.WriteLine(intArray[i]);
//}

//decresing lenght of array so won't print the last
//length--;

//deletion from beginning array
//for (int i = 1; i < length; i++)
//{
// intArray[i - 1] = intArray[i];
//}
//length--;

