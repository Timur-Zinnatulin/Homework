#define _CRT_SECURE_NO_WARNINGS
#include "sort.h"
#include "maxfinder-file.h"
#include "testing-routine.h"
#include "file-reading.h"

//The program finds the most frequent element in an array. If there are several, it prints out the greatest one.
int main()
{
	bool ifTestIsSuccessful = true;
	testingRoutine(ifTestIsSuccessful);
	if (!ifTestIsSuccessful)
	{
		printf("TEST FAILED\n");
	}
	FILE *inputFile = fopen("input.txt", "r");
	if (!inputFile)
	{
		printf("File not found, exiting...\n");
		return 0;
	}
	printf("Welcome to the Most Frequent Finder program!\n");
	int arraySize = 0;
	if (!scanSize(inputFile, arraySize))
	{
		fclose(inputFile);
		return 0;
	}
	int *arrayOfInts = new int[arraySize]();
	if (!scanArray(inputFile, arrayOfInts, arraySize))
	{
		fclose(inputFile);
		delete[] arrayOfInts;
		return 0;
	}
	quickSort(arrayOfInts, 0, arraySize - 1);
	printf("The most frequent element is %d\n", findMaxElement(arrayOfInts, arraySize));
	delete[] arrayOfInts;
	return 0;
}