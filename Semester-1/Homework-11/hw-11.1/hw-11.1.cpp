#include <iostream>
#include <string>
#include <fstream>
#include "kmp-algo.h"
#include "testing-routine.h"

using namespace std;

int main()
{
	if (testingRoutine())
	{
		cout << "Testing complete!\n\n";
	}
	else
	{
		cout << "Testing failed.\n";
		return 1;
	}
	cout << "Enter the string you want to find in the text: \n";
	string input;
	getline(cin, input);
	ifstream fin("input.txt");
	cout << "Starting to look for it in input.txt...\n";
	const int answer = substringPosition(fin, input);
	if (answer == -1)
	{
		cout << "The string was not found in the text.\n";
	}
	else
	{
		cout << "The string was found in the text in position " << answer << ".\n";
	}
	fin.close();
	cout << "\nProgram complete. Exiting...\n";
	return 0;
}
