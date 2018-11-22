#include "testing-routine.h"
#include "sort.h"
#include "maxfinder-file.h"
#include <stdio.h>

//Pre-run testing function
void testingRoutine()
{
	printf("TESTING PROTOCOL INITIATED\n");
	const int sizeOfArray1 = 10;
	const int sizeOfArray2 = 9;
	const int answer1 = 10;
	const int answer2 = 2;
	int testArray1[sizeOfArray1] = { 10, 10, 10, 2, 2, 101, 8, 12, 5, 3 };
	int testArray2[sizeOfArray2] = { 8, 0, 2, -10, 2, -10, 2, 0, 8 };
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
}