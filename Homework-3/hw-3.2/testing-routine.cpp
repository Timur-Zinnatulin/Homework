#include "sort.h"
#include "binsearch.h"
#include "testing-routine.h"
#include <stdio.h>

//Pre-run testing function
void testingRoutine()
{
	printf("TESTING PROTOCOL INITIATED\n");
	const int testSize = 8;
	int testArray[testSize] = { 8, 1000, 125, 16384, 12, 666, 1337, 5052000 };
	const int testElementSize = 3;
	//In order to have clever program structure, we put elements that are present in an array in even array positions
	//This way we can check the correctness of our test by checking it with divisibility by 2
	const int testElement[testElementSize] = { 125, 5, 5052000 };
	quickSort(testArray, 0, testSize - 1);
	bool ifFailed = false;
	for (int i = 0; i < testElementSize; ++i)
	{
		if ((i % 2 == 0) != binsearch(testArray, 0, testSize - 1, testElement[i]))
		{
			printf("ERROR FOUND\n");
			ifFailed = true;
		}
	}
	if (!ifFailed)
	{
		printf("TESTING COMPLETE\n");
		printf("READY TO RUN\n");
		printf("__________________\n");
	}
	else
	{
		printf("TESTING FAILED\n");
	}
}