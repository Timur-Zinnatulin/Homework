#define _CRT_SECURE_NO_WARNINGS
#include "testing-routine.h"
#include "sort.h"
#include "maxfinder-file.h"
#include "file-reading.h"

//Pre-run testing function
void testingRoutine(bool &ifTestIsSuccessful)
{
	ifTestIsSuccessful = true;
	printf("TESTING PROTOCOL INITIATED\n");
	FILE *inputFile = fopen("test.txt", "r");
	int sizeOfArray1 = 0;
	int sizeOfArray2 = 0;
	if (!scanSize(inputFile, sizeOfArray1))
	{
		fclose(inputFile);
		ifTestIsSuccessful = false;
		return;
	}
	int *testArray1 = new int[sizeOfArray1]();
	if (!scanArray(inputFile, testArray1, sizeOfArray1))
	{
		fclose(inputFile);
		delete[] testArray1;
		ifTestIsSuccessful = false;
		return;
	}

	if (!scanSize(inputFile, sizeOfArray2))
	{
		fclose(inputFile);
		delete[] testArray1;
		ifTestIsSuccessful = false;
		return;
	}
	int *testArray2 = new int[sizeOfArray2]();
	if (!scanArray(inputFile, testArray2, sizeOfArray2))
	{
		fclose(inputFile);
		delete[] testArray1;
		delete[] testArray2;
		ifTestIsSuccessful = false;
		return;
	}
	fclose(inputFile);
	const int answer1 = 10;
	const int answer2 = 2;
	quickSort(testArray1, 0, sizeOfArray1 - 1);
	quickSort(testArray2, 0, sizeOfArray2 - 1);
	if ((findMaxElement(testArray1, sizeOfArray1) != answer1) || (findMaxElement(testArray2, sizeOfArray2) != answer2))
	{
		printf("TEST FAILED\n");
	}
	else
	{
		printf("TEST COMPLETE\nREADY TO RUN\n");
		printf("________________\n");
	}
	delete[] testArray1;
	delete[] testArray2;
}