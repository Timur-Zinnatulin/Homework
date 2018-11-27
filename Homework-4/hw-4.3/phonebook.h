#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <string.h>
#include <stdio.h>

struct Record
{
	char name[50]{};
	int number = 0;
};

//Creates a new record in our phonebook
void addRecord(Record *phonebook, int &phonebookSize, char *name, int number);

//Prints out all existing phone numbers in console
void printRecords(Record *phonebook, int phonebookSize);

//Finds a number in our phonebook that has a given name attached to it
int findNumber(Record *phonebook, int phonebookSize, char *name);

//Finds a name in our phonebook that has a given number attached to it
char* findName(Record *phonebook, int phonebookSize, int number);
