#define _CRT_SECURE_NO_WARNINGS
#include "sort.h"
#include "maxfinder-file.h"
#include "testing-routine.h"
#include <stdio.h>

//The program finds the most frequent element in an array. If there are several, it prints out the greatest one.
int main()
{
	testingRoutine();
	printf("Welcome to the Most Frequent Finder program!\n");
	printf("Please enter the size of an array in which you want to find the most frequent element:\n");
	int arraySize = 0;
	scanf("%d", &arraySize);
	int *arrayOfInts = new int[arraySize]();
	printf("Now enter the contents of your array:\n");
	for (int i = 0; i < arraySize; ++i)
	{
		scanf("%d", &arrayOfInts[i]);
	}
	quickSort(arrayOfInts, 0, arraySize - 1);
	printf("The most frequent element is %d\n", findMaxElement(arrayOfInts, arraySize));
	delete[] arrayOfInts;
	return 0;
}