#include "binsearch.h"

//Binary search that returns result of 1^(Desired element is present in array)
bool binsearch(int *arrayOfInts, int leftBorder, int rightBorder, int desiredElement)
{
	//If the right border goes below the left border, then the desired number is definitely not present
	if (rightBorder < leftBorder)
	{
		return false;
	}
	int middleIndex = (leftBorder + rightBorder) / 2;
	//If we found the desired element, we celebrate!
	if (arrayOfInts[middleIndex] == desiredElement)
	{
		return true;
	}
	//Our desired element must be to the left relative to the middle
	if (arrayOfInts[middleIndex] > desiredElement)
	{
		return binsearch(arrayOfInts, leftBorder, middleIndex - 1, desiredElement);
	}
	//Our desired element must be to the right relative to the middle
	if (arrayOfInts[middleIndex] < desiredElement)
	{
		return binsearch(arrayOfInts, middleIndex + 1, rightBorder, desiredElement);
	}
}