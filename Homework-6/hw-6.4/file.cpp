#include "file.h"
#include "list.h"
#include <string>
#include <iostream>
#include <fstream>

using namespace std;

//Reads the contents of a file and puts them into list
void openFile(const char *fileName, List *list)
{
	ifstream fin;
	fin.open(fileName);
	while (!fin.eof())
	{
		string nameIn;
		string numberIn;
		getline(fin, nameIn);
		getline(fin, numberIn);
		push(list, nameIn, numberIn);
	}
	fin.close();
}