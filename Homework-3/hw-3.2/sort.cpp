#include "sort.h"

//Simple swap function
void swap(int &a, int &b)
{
	const int c = a;
	a = b;
	b = c;
}

//Function that divides an array into two for further sorting
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

//Array sort function
void quickSort(int *arrayOfInts, int leftBorder, int rightBorder)
{
	int dividingElement = arrayPartition(arrayOfInts, leftBorder, rightBorder);
	quickSort(arrayOfInts, leftBorder, dividingElement - 1);
	quickSort(arrayOfInts, dividingElement + 1, rightBorder);
}