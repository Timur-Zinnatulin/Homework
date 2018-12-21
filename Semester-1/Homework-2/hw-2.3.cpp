#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif

#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int getInput()
{
	printf("Please enter the size of an array which you want to sort.\n");
	printf("(Note: to avoid any long waiting I recommend entering a number not greater than 100)\nSize: ");
	int input = 0;
	scanf_s("%d", &input);
	return input;
}

void getArray(int inputArray[], int anotherInputArray[], int sizeOfArray)
{
	printf("Now enter the elements of an array you want to sort.\n");
	printf("(Note: this program shall work only with integers not less than zero and not greater than 100.)\n");
	printf("((Note: the program will only use the first %d numbers))\nArray: ", sizeOfArray);
	for (int i = 0; i < sizeOfArray; ++i)
	{
		scanf_s("%d", &inputArray[i]);
		anotherInputArray[i] = inputArray[i];
	}
}

void printArray(int arrayOfInts[], int sizeOfArray)
{
	for (int i = 0; i < sizeOfArray; ++i)
	{
		printf("%d ", arrayOfInts[i]);
	}
	printf("\n");
}

int findMaxInArray(int arrayOfInts[], int sizeOfArray)
{
	int maxInArray = 0;
	for (int i = 0; i < sizeOfArray; ++i)
	{
		if (maxInArray < arrayOfInts[i])
		{
			maxInArray = arrayOfInts[i];
		}
	}
	return maxInArray;
}
void bubbleSort(int arrayOfInts[], int sizeOfArray)
{
	for (int i = 0; i < sizeOfArray; ++i)
	{
		bool flagArrayUnsorted = false;
		for (int j = sizeOfArray - 1; j > i; --j)
		{
			if (arrayOfInts[j - 1] > arrayOfInts[j])
			{
				flagArrayUnsorted = true;
				int substituteVariable = arrayOfInts[j - 1];
				arrayOfInts[j - 1] = arrayOfInts[j];
				arrayOfInts[j] = substituteVariable;
			}
		}
		if (!flagArrayUnsorted)
		{
			break;
		}
	}
}

void welcomeOutput()
{
	printf("Welcome to the Sorting program ver.1!\n");
	printf("Since it works with Counting sort algorithm, you have some input limitations.\n");
	printf("They will be shown to you later.\n\n");
}

void countingSort(int arrayOfInts[], int sizeOfArray, int maxElement)
{
	int *countOfElements = new int[maxElement + 1]();
	for (int i = 0; i < sizeOfArray; ++i)
	{
		++countOfElements[arrayOfInts[i]];
	}
	int iter = 0;
	for (int i = 0; i <= maxElement; ++i)
	{
		int arrayFrequencyOfCurrentElement = countOfElements[i];
		while (arrayFrequencyOfCurrentElement > 0)
		{
			arrayOfInts[iter] = i;
			++iter;
			--arrayFrequencyOfCurrentElement;
		}
	}
	delete [] countOfElements;
}

void testingRoutine()
{
	printf("TESTING PROTOCOL INITIATED\n");
	srand(time(nullptr));
	const int numberOfTests = 100;
	int correctTests = 0;
	for (int i = 0; i < numberOfTests; ++i)
	{
		int randomSize = rand() % 100 + 1;
		int *randomArray = new int[randomSize]();
		int *copyOfRandomArray = new int[randomSize]();
		int maxElementInRandomArray = 0;
		for (int j = 0; j < randomSize; ++j)
		{
			randomArray[j] = rand() % 101;
			copyOfRandomArray[j] = randomArray[j];
			if (randomArray[j] > maxElementInRandomArray)
			{
				maxElementInRandomArray = randomArray[j];
			}
		}
		bubbleSort(randomArray, randomSize);
		countingSort(copyOfRandomArray, randomSize, maxElementInRandomArray);
		bool flagArrayCorrectlySorted = true;
		for (int j = 0; j < randomSize - 1; ++j)
		{
			if ((randomArray[j] > randomArray[j + 1]) || (copyOfRandomArray[j] > copyOfRandomArray[j + 1]))
			{
				flagArrayCorrectlySorted = false;
			}
		}
		if (flagArrayCorrectlySorted)
		{
			++correctTests;
		}
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
		delete[] randomArray;
		delete[] copyOfRandomArray;
	}
	printf("TESTING COMPLETE. TOTAL ERRORS: %d\n", numberOfTests - correctTests);
}

int main()
{
	testingRoutine();
	welcomeOutput();
	int sizeOfArray = getInput();
	int arrayOfInts[100] = {};
	int copyOfArray[100] = {};
	getArray(arrayOfInts, copyOfArray, sizeOfArray);
	int maxElement = findMaxInArray(arrayOfInts, sizeOfArray);
	bubbleSort(arrayOfInts, sizeOfArray);
	printf("\n~~~~~~~~~~\nBubble Sort complete! The calculated array is:\n");
	printArray(arrayOfInts, sizeOfArray);
	countingSort(copyOfArray, sizeOfArray, maxElement);
	printf("\n~~~~~~~~~~\nCounting Sort complete! The calculated array is:\n");
	printArray(copyOfArray, sizeOfArray);
	return 0;
}
