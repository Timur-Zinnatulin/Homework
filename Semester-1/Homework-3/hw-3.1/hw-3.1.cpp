#define _CRT_SECURE_NO_WARNINGS
#include "sort.h"
#include "testing-routine.h"
#include <stdio.h>

int main()
{
	testingRoutine();
	printf("Welcome to Quick/Insertion Sort Program ver.1!\n");
	printf("This program utilizes QuickSort and InsertionSort algorithms to sort an array of your choice!\n");
	printf("Please enter the size of an array you want to sort:\n");
	int arraySize = 0;
	scanf("%d", &arraySize);
	printf("Now enter an array with the size of %d:\n", arraySize);
	int *arrayOfInts = new int[arraySize] {0};
	for (int i = 0; i < arraySize; ++i)
	{
		scanf("%d", &arrayOfInts[i]);
	}
	quickSort(arrayOfInts, 0, arraySize - 1);
	printf("\nNow you shall get a sorted array:\n");
	for (int i = 0; i < arraySize; ++i)
	{
		printf("%d ", arrayOfInts[i]);
	}
	delete[] arrayOfInts;
	return 0;
}
