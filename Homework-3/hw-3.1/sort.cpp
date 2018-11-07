#include "sort.h"

void swap(int &a, int &b)
{
	const int c = a;
	a = b;
	b = c;
}

void insertionSort(int *arrayOfInts, int leftBorder, int rightBorder)
{
	for (int i = leftBorder; i <= rightBorder; ++i)
	{
		const int key = arrayOfInts[i];
		int counter = i;
		while ((counter > leftBorder) && (key < arrayOfInts[counter - 1]))
		{
			swap(arrayOfInts[counter - 1], arrayOfInts[counter]);
			--counter;
		}
	}
}

int arrayPartition(int *arrayOfInts, int leftBorder, int rightBorder)
{
	const int pivot = arrayOfInts[leftBorder];
	int index = leftBorder + 1;
	for (int i = leftBorder + 1; i <= rightBorder; ++i)
	{
		if (arrayOfInts[i] < pivot)
		{
			swap(arrayOfInts[i], arrayOfInts[index]);
			++index;
		}
	}
	swap(arrayOfInts[leftBorder], arrayOfInts[index - 1]);
	return index - 1;
}

void quickSort(int *arrayOfInts, int leftBorder, int rightBorder)
{
	if ((rightBorder - leftBorder + 1) < 10)
	{
		insertionSort(arrayOfInts, leftBorder, rightBorder);
	}
	else
	{
		int dividingElement = arrayPartition(arrayOfInts, leftBorder, rightBorder);
		quickSort(arrayOfInts, leftBorder, dividingElement - 1);
		quickSort(arrayOfInts, dividingElement + 1, rightBorder);
	}
}