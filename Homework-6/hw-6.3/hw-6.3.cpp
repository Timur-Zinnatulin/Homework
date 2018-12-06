#include <iostream>
#include <string>
#include "shunting-yard.h"
#include "testing-routine.h"

using namespace std;

int main()
{
	if (testingRoutine())
	{
		cout << "This is a shunting yard problem. THAT WORKS!!!\n\n";
	}
	cout << "Enter an expression in infix form: ";
	string input;
	getline(cin, input);
	cout << "In Reverse Polish Notation this expression looks like this:\n" << shuntingYard(input) << "\n";
	return 0;
}
