#include <iostream>
#include "avl-tree.h"
#include "testing-routine.h"

using namespace std;

int main()
{
	if (testingRoutine())
	{
		cout << "Testing complete.\n";
	}
	else
	{
		cout << "Testing failed.\n";
		return 0;
	}
}
