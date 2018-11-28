#define _CRT_SECURE_NO_WARNINGS
#include "phonebook.h"
#include <string.h>
#include <stdio.h>

//Creates a new record in our phonebook
void addRecord(Record *phonebook, int &phonebookSize, char *name, int number)
{
	strcpy(phonebook[phonebookSize].name, name);
	phonebook[phonebookSize].number = number;
	++phonebookSize;
}

//Prints out all existing phone numbers in console
void printRecords(Record *phonebook, int phonebookSize)
{
	if (phonebookSize == 0)
	{
		printf("There are no phone numbers!\n");
	}
	else
	{
		for (int i = 0; i < phonebookSize; ++i)
		{
			printf("%s %d\n", phonebook[i].name, phonebook[i].number);
		}
	}
}

//Finds a number in our phonebook that has a given name attached to it
int findNumber(Record *phonebook, int phonebookSize, char *name)
{
	for (int i = 0; i < phonebookSize; ++i)
	{
		if (strcmp(phonebook[i].name, name) == 0)
		{
			return phonebook[i].number;
		}
	}
	return -1;
}

//Finds a name in our phonebook that has a given number attached to it
char* findName(Record *phonebook, int phonebookSize, int number)
{
	for (int i = 0; i < phonebookSize; ++i)
	{
		if (phonebook[i].number == number)
		{
			return phonebook[i].name;
		}
	}
	char failure[2] = "\0";
	return failure;
}



