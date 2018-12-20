#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include "stack.h"
#include "testing-routine.h"
#include "expression-calculator.h"

int main()
{
	if (testingRoutine())
	{
		printf("Testing successful! Ready to run.\n\n");
	}
	else
	{
		printf("Testing unsuccessful :(\n");
		//return 0;
	}
	printf("Welcome to Reverse Polish Notation Calculator ver.1!\n");
	printf("Please enter a string of digits and signs in this notation that you wish to calculate.\n");
	printf("Input: ");
	char *input = new char[100]{};
	scanf("%[^\n]s", input);
	auto stack = createNewStack();
	bool correctionCheck = calculateInput(stack, input);
	if (!correctionCheck)
	{
		printf("There was division by zero!!\n");
		printf("Cannot calculate, exiting...");
	}
	else
	{
		printf("The result of calculation is %d\n", pop(stack));
	}
	delete[] input;
	deleteStack(stack);
	return 0;
}

