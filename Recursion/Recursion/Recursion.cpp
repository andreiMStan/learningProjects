

#include <iostream>
using namespace std;

#include<array>


int mystery(int a, int b) {
				if (0 == b)
								return 0;
				else
								return a + mystery(a, b - 1);
}
int f(int n) {
				int result = 0;
				if (n <= 4)
								result = 1;
				else
								result = f(n / 2) + f(n / 4);
				return result;
}
				int sum=0;
int AddDigits(int  num)
{
				if (num != 0)
				{
								//int first = num % 10; //3
								//int firstLast = num / 10;
								sum = (num %10)+AddDigits(num/10);
				}
				return sum;
}
void NumberTriangle(int num)
{
				if (num==0)
				{
								return ;
				}
				else
				{
								for (int i = 1; i <=num; i++)
								{
								cout << i;
								}
								cout << endl;
								NumberTriangle(num-1);
				}
}

void starTriangle(int num,int temp) {
				if (num==0) return;
				else
				{
								for (int i = num; i < temp; i++)
								{cout << "*";}
								cout << endl;
				}
				starTriangle(num - 1, temp);
}
void starTriangle2(int num, int temp) {
				if (num == 0) return;
				else
				{
								for (int i = num; i < temp+1; i++)
								{
												cout << "*";
								}
								cout << endl;
				}
				starTriangle2(num - 1, temp);
}
int main() {
				 
			//	cout << "The sum is :" << AddDigits(12345);		
				//NumberTriangle(6);
				starTriangle2(6, 6);
		//		cout << mystery(1, 7);
			//	cout << f(32);
}
//int	f(int x);
// 
// 
//
//const int MAX_ITEMS = 20;
//struct ListType {
//				int length;
//				int info[MAX_ITEMS];
//};
//bool ValueInList(ListType list, int value, int startIndex);
//int fib(int n);
//int fib1(int n);
//int trace5(int n);
//int power(int base, int exponent);


// Recursive function that returns true if palindrome, false if not
//bool palindrome(int arr[], int begin, int end) {
//				// base case
//				if (begin >= end) {
//								return true;
//				}
//				if (arr[begin] == arr[end]) {
//								return palindrome(arr, begin + 1, end - 1);
//				}
//				else {
//								return false;
//				}
//}
//void trace4(int i) {
//				if (i > 1) {
//								trace4(i / 2);
//								cout << "**" << endl;
//								cout << "**" << endl;
//
//								cout << endl;
//								trace4(i / 2);
//				}
//				cout << "**"<<endl;
//	
//}
//int main() {
//
//
//				trace4(4);


			/*	int a[] = { 3, 6, 0, 6, 3 };
				int n = 5;
				if (palindrome(a, 0, n - 1))
								cout << "Palindrome";
				else
								cout << "Not Palindrome";
				return 0;*/



//
//bool polindorm(int polindromArray[],int size);
//int main()
//{
//				int pol[5] = { 1,2,3,2,1 };
//				int sizeOfThePol = sizeof(pol) / sizeof(pol[0]); 
//
//		//		cout<<polindorm(pol,sizeOfThePol);
//				
//				cout << polindorm(pol, sizeOfThePol);
//				return 0;
//
//
//
//}
//
//
//bool polindorm(int polindromray[],int size)
//{
//				int start = 0;
//				
//				if (polindromray[start] == polindromray[size - 1])
//				{
//								polindorm(polindromray, size - 1);
//								start++;
//								return true;
//				}
//				else false;
//				
//			
//										
//				
//};

//bool polindorm(int arr[], int size)
//{
//				int start = 0, end = size - 1;
//				while (start < end)
//				{
//								if (arr[start] != arr[end]) return false;
//								start++; end--;
//				}
//				return true;
//}


		//	cout<<	power(3, 4);
			//int base, exp;
			//cout << "Enter the base: ";
			//cin >> base;
			//cout << "Enter the exponent: ";
			//cin >> exp;
			//int result = power(base, exp);
			//cout << base << " to the power of " << exp << " is " << result << endl;
			//return 0;

			//	cout<<trace5(5);

				//int value;
				//ListType list;
				//list = { 5,{2,3,4,2,5,0,6} };
			
		//cout<<	 fib(4);
//	cout << fib1(4);
				//// ValueInList(list, 2, 0);
				//	if (ValueInList(list, 12, 0))
				//					cout << value << " found" << endl;
				//	else
				//					cout << value << " NOT found" << endl;
				//	return 0;
				//


				/*int a;
				a = f(6);
				cout<<a;*/
//}
//int fib1(int n) {
//				if (n == 0)
//								return 0;
//				else if (n == 1)
//								return 1;
//				int last = 1, nextToLast = 1, answer = 1;
//				for (int i = 2; i < n; i++) {
//								answer = last + nextToLast;
//								nextToLast = last;
//								last = answer;
//				}
//				return answer;
//}
//int trace5(int n)
//{
//				if (n == 1)
//								return 1;
//				else
//								return n + trace5(n - 1);
//}
//int total = 0;
//int power(int base, int exponent)
//{
//				if (exponent==1)
//				{
//								return base;
//				}
//				else
//				{
//					return base*	power(base, exponent - 1);
//				}
//
//}

//int fib(int n) {
//				if (n == 0)
//								return 0;
//				else if (n == 1)
//								return 1;
//				else
//								return(fib(n - 1) + fib(n - 2));
//}
//bool ValueInList(ListType list, int value, int startIndex){
//				if (value == list.info[startIndex])
//								return true;
//
//				else if (startIndex == list.length - 1)
//								return false;
//
//				else
//								return ValueInList(list, value, startIndex + 1);
//}

//
//
//
//		
//int	f(int x)
//{
//				if (x == 0)
//								return 1;
//				return 1 + f(x - 1);
//}

