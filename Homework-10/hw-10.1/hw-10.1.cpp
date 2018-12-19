#include <iostream>
#include "graph.h"
#include "testing-routine.h"

using namespace std;

int main()
{
	if (testingRoutine())
	{
		cout << "Testing successful!\n";
	}
	else
	{
		cout << "Testing failed.\n";
		return 1;
	}
}
