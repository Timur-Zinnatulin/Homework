#include <iostream>
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
	return 0;
}
