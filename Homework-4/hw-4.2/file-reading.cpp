#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

//Reads a single number from a file
bool scanSize(FILE* inputFile, int &arraySize)
{
	if (feof(inputFile))
	{
		return false;
	}
	fscanf(inputFile, "%d", &arraySize);
	return true;
}

//Reads an array of integers from a file
bool scanArray(FILE* inputFile, int *arrayOfInts, int arraySize)
{
	for (int i = 0; i < arraySize; ++i)
	{
		if (feof(inputFile))
		{
			return false;
		}
		fscanf(inputFile, "%d", &arrayOfInts[i]);
	}
	return true;
}
