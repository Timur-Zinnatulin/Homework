#include "maxfinder.h"

//Function that returns the most frequent element in a sorted array
int findMaxElement(int *arrayOfInts, int arraySize)
{
	int currentMax = arrayOfInts[0];
	int maxAmount = 0;
	int currentAmount = 1;
	for (int i = 1; i < arraySize; ++i)
	{
		if (arrayOfInts[i] == arrayOfInts[i + 1])
		{
			++currentAmount;
		}
		else
		{
			if (currentAmount >= maxAmount)
			{
				currentMax = arrayOfInts[i - 1];
				maxAmount = currentAmount;
			}
			currentAmount = 1;
		}
	}
	return currentMax;
}