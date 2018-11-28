#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <string.h>
#include "phonebook.h"
#include "file.h"
#include "testing-routine.h"

//Prints a line in order to separate outputs
void printLine()
{
	printf("__________________________\n");
}

//Btw, numbers are represented by integers, so its limitations apply
int main()
{
	testingRoutine();
	printLine();
	Record phonebook[100];
	int phonebookSize = 0;
	openFile(phonebook, phonebookSize, "phonebook.txt");
	printf("Welcome to the phonebook; you can control it using these commands:\n");
	printf("0 - exit\n");
	printf("1 - Add a record (name, phone)\n");
	printf("2 - Print all records to console\n");
	printf("3 - Find a name by phone number\n");
	printf("4 - Find a phone number by name\n");
	printf("5 - Save all changes to file\n");
	int input = -1;
	while (input != 0)
	{
		printf("Enter your command:\n");
		char name[50]{};
		int number = 0;
		scanf("%d", &input);
		switch (input)
		{
		case 1:
			printf("Enter a new name:\n");
			scanf("%s", &name);
			while (findNumber(phonebook, phonebookSize, name) != -1)
			{
				printf("Name already exists, cannot create a record. Try again.\n");
				printf("Enter another name:\n");
				scanf("&s", &name);
			}
			printf("Enter a new phone number:\n");
			scanf("%d", &number);
			while (strcmp(findName(phonebook, phonebookSize, number), "\0") != 0)
			{
				printf("Number already exists, cannot create a record. Try again.\n");
				printf("Enter another number:\n");
				scanf("&d", &number);
			}
			addRecord(phonebook, phonebookSize, name, number);
			printf("Record added.\n");
			break;
		case 2:
			printf("Printing all records, from file and recently added:\n");
			printRecords(phonebook, phonebookSize);
			break;
		case 3:
			printf("Enter a phone number:\n");
			scanf("%d", &number);
			if (strcmp(findName(phonebook, phonebookSize, number), "\0") != 0)
			{
				printf("%s is the person with this phone number.\n", findName(phonebook, phonebookSize, number));
			}
			else
			{
				printf("There is no such phone number in the phonebook.\n");
			}
			break;
		case 4:
			printf("Enter a name:\n");
			scanf("%s", &name);
			if (findNumber(phonebook, phonebookSize, name) != -1)
			{
				printf("This person has this phone number: %d\n", findNumber(phonebook, phonebookSize, name));
			}
			else
			{
				printf("There is no such name in the phonebook.\n");
			}
			break;
		case 5:
			printf("Saving the records to a file...\n");
			saveRecords(phonebook, phonebookSize, "phonebook.txt");
			printf("All records successfully saved!\n");
			break;
		}
		printLine();
	}
	printf("Exiting...\n");
	return 0;
}
