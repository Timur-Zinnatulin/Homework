#include "sort.h"
#include "testing-routine.h"
#include <stdio.h>
#include <time.h>
#include <stdlib.h>

//Checks if the array if sorted correctly after using our sort function
bool checkIfArraySortedCorrectly(int *arrayOfInts, int arraySize)
{
	for (int i = 0; i < arraySize - 1; ++i)
	{
		if (arrayOfInts[i + 1] < arrayOfInts[i])
		{
			return false;
		}
	}
	return true;
}

//Prints a string dividing line that imoroves readablilty
void printLine()
{
	printf("____________________________________________\n");
}

//Pre-run test function that checks for any errors in our program's algorithm
void testingRoutine()
{
	srand(time(nullptr));
	const int numberOfTests = 100;
	int testErrors = 0;
	printf("TESTING PROTOCOL INITIATED\n");
	printLine();
	printf("STAGE 1: RANDOM ARRAY TEST\n");
	for (int i = 0; i < numberOfTests; ++i)
	{
		int testSize = rand() % 20 + 1;
		int *testArray = new int[testSize]();
		for (int i = 0; i < testSize; ++i)
		{
			testArray[i] = rand() % 1001 - 500;
		}
		quickSort(testArray, 0, testSize - 1);
		if (!checkIfArraySortedCorrectly(testArray, testSize))
		{
			++testErrors;
		}
		delete[] testArray;
		if (i == numberOfTests / 4)
		{
			printf("25%% complete...\n");
		}
		if (i == numberOfTests / 2)
		{
			printf("50%% complete...\n");
		}
		if (i == 3 * numberOfTests / 4)
		{
			printf("75%% complete...\n");
		}
	}
	printf("STAGE 1 TESTING COMPLETE. TOTAL ERRORS: %d\n", testErrors);
	printLine();
	//I hope this is enough for testing on arrays consisting of equal elements
	printf("STAGE 2: ALGORITHM SPECIFIC TESTING\n");
	const int specificArraySize = 10;
	int testSpecificArray[specificArraySize] = { 1, 1, 1, 1 ,1, 1, 1, 1, 1, 1 };
	quickSort(testSpecificArray, 0, specificArraySize - 1);
	if (!checkIfArraySortedCorrectly(testSpecificArray, specificArraySize))
	{
		++testErrors;
	}
	printf("STAGE 2 TESTING COMPLETED SUCCESSFULLY. TOTAL ERRORS: %d\n", testErrors);
	printLine();
}