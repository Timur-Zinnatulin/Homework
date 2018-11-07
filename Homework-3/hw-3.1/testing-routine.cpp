#include "sort.h"

bool checkIfArraySortedCorrectly(int *arrayOfInts, int arraySize)
{
	for (int i = 0; i < arraySize - 1; ++i)
	{
		if (arrayOfInts[i + 1] > arrayOfInts[i])
		{
			return false;
		}
	}
	return true;
}

void testingRoutine()
{
	srand(time(nullptr));
	const int numberOfTests = 100;
	int testErrors = 0;
	printf("TESTING PROTOCOL INITIATED\n");
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
	printf("PRE-RUN TESTING COMPLETE. TOTAL ERRORS: %d\n", testErrors);
}