
//int[] colours = { 1, 2, 2, 1, 0, 2, 1, 2, 2, 1, 0, 2 };

//for (int i = 0; i < colours.Length; i++)
//{
// for (int j = 0; j < colours.Length; j++)
// {
//  sortColors(colours);
// }
//}
//printColours(colours);

//void printColours(int[] nums)
//{
// for (int i = 0; i < nums.Length; i++)
// {
//  Console.WriteLine(nums[i]);
// }
//}

//void sortColors(int[] nums)
//{
// int low = 0;
// int mid = 0;
// int high = nums.Length - 1;
// while (mid <= high)
// {
//  if (nums[mid] == 0)
//  {
//   Swap(nums, low, mid);
//   low++;
//   mid++;
//  }
//  else if (nums[mid] == 1)
//  {
//   mid++;
//  }
//  else
//  {
//   Swap(nums, mid, high);
//   high--;
//  }
// }
//}

//void Swap(int[] arr, int i, int j)
//{
// int temp = arr[i];
// arr[i] = arr[j];
// arr[j] = temp;
//}