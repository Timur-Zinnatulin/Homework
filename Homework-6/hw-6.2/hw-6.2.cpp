#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include "bracket-control.h"
#include "testing-routine.h"

int main()
{
	if (testingRoutine())
	{
		printf("YEAH!! TESTING SUCCESSFUL! You can use the program now.\n");
	}
	else
	{
		printf("Testing failed :(\n");
		return 0;
	}
	printf("Welcome to Bracket Sequence Correctness Checikng program ver.1!\n");
	printf("Please enter the bracket sequence: ");
	char *input = new char[100]{};
	scanf("%[^\n]s", input);
	if (correctSequence(input))
	{
		printf("The bracket sequence is correct!\n");
	}
	else
	{
		printf("The bracket sequence is incorrect.\n");
	}
	return 0;
}
