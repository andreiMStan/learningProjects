

//int[] intArray = { -22, -15, 2, 7, 22, 33, 53 };

//Console.WriteLine(BinarySearch(intArray, 2));

//int BinarySearch(int[] intArray, int value)
//{
// int start = 0;
// int end = intArray.Length;

// //start end + while less than is going criss crossing
// while (start < end)
// {

//  int midpoint = (start + end) / 2;

//  //search middle of the array
//  if (intArray[midpoint] == value)
//  {
//   return midpoint;
//  }

//  else if (intArray[midpoint] < value)
//  {
//   start = midpoint + 1;
//  }
//  else
//  {
//   end = midpoint;
//  }
// }
// return -1;
//}