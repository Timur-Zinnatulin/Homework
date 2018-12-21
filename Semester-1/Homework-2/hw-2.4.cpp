#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <time.h>
#include <stdlib.h>

int getInput()
{
	printf("Please enter the size of an array which you want to generate\n");
	printf("\nSize: ");
	int input = 0;
	scanf("%d", &input);
	return input;
}

void welcomeOutput()
{
	printf("Welcome to the Problem 2.4 solution program ver.1!\n");
}

void swap(int &a, int &b)
{
	int c = a;
	a = b;
	b = c;
}

void generateArray(int arraySize, int* array)
{
	srand(time(nullptr));
	printf("This is our original array:\n");
	for (int i = 0; i < arraySize; ++i)
	{
		array[i] = rand() % 1001 - 500;
		printf("%d ", array[i]);
	}
	printf("\nNow we're going to convert this array:\n");
}

void convertArray(int size, int* array)
{
	int addressFirst = 0;
	int first = array[0];
	for (int i = 0; i < size; ++i)
	{
		if (array[i] < first)
		{
			if (i - addressFirst == 1)
			{
				swap(array[addressFirst], array[addressFirst + 1]);
				++addressFirst;
			}
			else
			{
				swap(array[i], array[addressFirst + 1]);
				swap(array[addressFirst], array[addressFirst + 1]);
				++addressFirst;
			}
		}
	}
}

bool ifConditionFulfilled(int size, int* array, int firstElement)
{
	bool flagIfCorrect = true;
	int count = 0;
	while (array[count] < firstElement && count < size)
	{
		count++;
	}
	while (array[count] >= firstElement && count < size)
	{
		count++;
	}
	if (count != size)
	{
		flagIfCorrect = false;
	}
	return flagIfCorrect;
}

void testingRoutine()
{
	const int numberOfTests = 50;
	printf("TESTING PROTOCOL INITIATED\n");
	srand(time(nullptr));
	int testFailures = 0;
	for (int i = 0; i < numberOfTests; ++i)
	{
		int testSize = rand() % 15 + 1;
		int *testArray = new int[testSize]();
		bool ifTesting = true;
		for (int i = 0; i < testSize; ++i)
		{
			testArray[i] = rand() % 1001 - 500;
		}
		int const testFirstElement = testArray[0];
		convertArray(testSize, testArray);
		if (!ifConditionFulfilled(testSize, testArray, testFirstElement))
		{
			++testFailures;
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
	printf("PRE-RUN TESTING COMPLETE. TOTAL ERRORS: %d\n", testFailures);
}

void printArray(int sizeOfArray, int array[], int firstElement)
{
	int i = 0;
	while (array[i] < firstElement)
	{
		printf("%d ", array[i]);
		++i;
	}
	printf("| This is the first original element -> %d <- | ", array[i]);
	++i;
	while (i < sizeOfArray)
	{
		printf("%d ", array[i]);
		++i;
	}
	printf("\n");
}

int main()
{
	testingRoutine();
	welcomeOutput();
	int arraySize = getInput();
	int* arrayOfInts = new int[arraySize]();
	generateArray(arraySize, arrayOfInts);
	int const firstElement = arrayOfInts[0];
	convertArray(arraySize, arrayOfInts);
	printArray(arraySize, arrayOfInts, firstElement);
	delete[] arrayOfInts;
	return 0;
}
