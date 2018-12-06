#include <iostream>
#include <string>
#include "shunting-yard.h"
#include "testing-routine.h"

using namespace std;

int main()
{
	if (testingRoutine())
	{
		cout << "This is a shunting yard problem. THAT WORKS!!!\n";
	}
	string s;
	getline(cin, s);
	cout << shuntingYard(s) << "\n";
	return 0;
}
