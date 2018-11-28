#pragma once
#include "phonebook.h"

//Reads records from an existing file or creates a new one with given name if it doesn't exist
void openFile(Record *phonebook, int &phonebookSize, const char *fileName);

//Puts the database of records into a file
void saveRecords(Record *phonebook, int phonebookSize, const char *fileName);