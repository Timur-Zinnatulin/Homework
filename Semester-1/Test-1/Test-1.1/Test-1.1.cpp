#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <string>


using namespace std;

bool checkIfPalindrome(string str)
{
	int leftBorder = 0;
	int rightBorder = str.size() - 1;
	while (leftBorder < rightBorder)
	{
		while (str[leftBorder] == ' ')
		{
			++leftBorder;
		}
		while (str[rightBorder] == ' ')
		{
			--rightBorder;
		}
		if (str[leftBorder] != str[rightBorder])
		{
			return false;
		}
		++leftBorder;
		--rightBorder;
	}
	return true;
}

int main()
{
	cout << "This program determines whether the input string is a palindrome or not\n";
	cout << "Please enter a row of characters which you want to check:\n";
	string stringOfChar;
	getline(cin, stringOfChar);
	if (checkIfPalindrome(stringOfChar))
	{
		cout << "This string is a palindrome\n";
	}
	else
	{
		cout << "This string is NOT a palindrome\n";
	}
	return 0;
}
