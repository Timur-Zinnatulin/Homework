#include "maxfinder.h"

//Function that returns the most frequent element in a sorted array
int findMaxElement(int *arrayOfInts, int arraySize)
{
	int currentMax = arrayOfInts[0];
	int maxAmount = 0;
	int currentAmount = 1;
	for (int i = 1; i < arraySize; ++i)
	{
		if (arrayOfInts[i] == arrayOfInts[i - 1])
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
	//We have to check if the last element was the most frequent one as well
	if (currentAmount >= maxAmount)
	{
		currentMax = arrayOfInts[arraySize - 1];
		maxAmount = currentAmount;
	}
	return currentMax;
}