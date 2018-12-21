#define _CRT_SECURE_NO_WARNINGS
#include "file.h"
#include "phonebook.h"
#include <stdio.h>

//Reads records from an existing file or creates a new one with given name if it doesn't exist
void openFile(Record *phonebook, int &phonebookSize, const char *fileName)
{
	FILE *file = fopen(fileName, "a+");
	phonebookSize = 0;
	while (!feof(file))
	{
		const int readBytes = fscanf(file, "%s%d", &phonebook[phonebookSize].name, &phonebook[phonebookSize].number);
		if (readBytes < 0)
		{
			break;
		}
		++phonebookSize;
	}
	fclose(file);
}

//Puts the database of records into a file
void saveRecords(Record *phonebook, int phonebookSize, const char *fileName)
{
	FILE *file = fopen(fileName, "w");
	for (int i = 0; i < phonebookSize; ++i)
	{
		fprintf(file, "%s %d\n", phonebook[i].name, phonebook[i].number);
	}
	fclose(file);
}
