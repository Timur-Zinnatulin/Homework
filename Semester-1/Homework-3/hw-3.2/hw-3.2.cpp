#define _CRT_SECURE_NO_WARNINGS
#include "sort.h"
#include "binsearch.h"
#include "testing-routine.h"
#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int pow(int baseNumber)
{
	return baseNumber * baseNumber * baseNumber;
}

int main()
{
	testingRoutine();
	printf("Welcome to the Binary Search program!\n");
	printf("This program shall generate a random array and a random set of numbers.\n");
	printf("Then it shall quickly check if those random numbers are present in our array!\n\n");
	printf("Now, please enter the size of a random array and the amonut of numbers to generate:\n");
	int arraySize = 0;
	int randomsAmount = 0;
	scanf("%d%d", &arraySize, &randomsAmount);
	srand(time(nullptr));
	//We create an array
	int *arrayOfInts = new int[arraySize]();
	for (int i = 0; i < arraySize; ++i)
	{
		//rand() is limited to 2^16 - 1, so we improvise
		arrayOfInts[i] = pow(rand() % 1001);
	}
	for (int i = 0; i < randomsAmount; ++i)
	{
		const int randomNumber = pow((rand() % 1001));
		printf("Random number is %d; ", randomNumber);
		if (binsearch(arrayOfInts, 0, arraySize - 1, randomNumber))
		{
			printf("it is present in an array!\n");
		}
		else
		{
			printf("it is NOT present in an array!\n");
		}
	}
	delete[] arrayOfInts;
	return 0;
}