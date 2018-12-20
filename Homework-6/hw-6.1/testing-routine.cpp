#include "stack.h"
#include "testing-routine.h"
#include "expression-calculator.h"

//Checks if the correct test is actually correctly calculated by the program
bool checkTest(char *input, const int answer)
{
	bool ifCorrect = false;
	auto testStack = createNewStack();
	if (calculateInput(testStack, input))
	{
		if (pop(testStack) == answer)
		{
			ifCorrect = true;
		}
	}
	deleteStack(testStack);
	return ifCorrect;
}

//Pre-run testing function
bool testingRoutine()
{
	bool ifCorrect = true;
	char input1[15] = "9 6 - 1 2 + *";
	char input2[15] = "8 4 + 2 3 * /";
	char input3[23] = "2 1 + 3 / 9 * 3 3 - /";
	const int answer1 = 9;
	const int answer2 = 2;
	if ((!checkTest(input1, answer1)) || (!checkTest(input2, answer2)))
	{
		ifCorrect = false;
	}
	auto testStack3 = createNewStack();
	if (calculateInput(testStack3, input3))
	{
		ifCorrect = false;
	}
	deleteStack(testStack3);
	return ifCorrect;
}