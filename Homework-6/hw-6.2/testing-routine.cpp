#include "bracket-control.h"
#include "testing-routine.h"

//Pre-run testing function
bool testingRoutine()
{
	char test1[15] = "([])([{}])({})";
	char test2[3] = "(}";
	char test3[5] = "()}{";
	const bool answer1 = true;
	const bool answer2 = false;
	const bool answer3 = false;
	if (correctSequence(test1) == answer1)
	{
		if (correctSequence(test2) == answer2)
		{
			if (correctSequence(test3) == answer3)
			{
				return true;
			}
		}
	}
	return false;
}