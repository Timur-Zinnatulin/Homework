#include "testing-routine.h"
#include "phonebook.h"
#include "file.h"
#include <string.h>
#include <stdio.h>

//Pre-run testing program
void testingRoutine()
{
	printf("Pre-run testing initiated.\n");
	bool ifSuccess = true;
	Record testPhonebook[100]{};
	int testPhonebookSize = 0;
	openFile(testPhonebook, testPhonebookSize, "test.txt");
	char testName[6] = "Testo";
	int testNumber = 12321;
	addRecord(testPhonebook, testPhonebookSize, testName, testNumber);
	saveRecords(testPhonebook, testPhonebookSize, "test.txt");
	
	openFile(testPhonebook, testPhonebookSize, "test.txt");
	if (strcmp(findName(testPhonebook, testPhonebookSize, testNumber), testName) != 0)
	{
		ifSuccess = false;
	}
	if (findNumber(testPhonebook, testPhonebookSize, testName) != testNumber)
	{
		ifSuccess = false;
	}

	if (ifSuccess)
	{
		printf("Testing successful!\n");
	}
	else
	{
		printf("Testing failed!\n");
	}
}