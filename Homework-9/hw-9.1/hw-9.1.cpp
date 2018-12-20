#include <iostream>
#include <fstream>
#include <vector>
#include "testing-routine.h"
#include "hash-table.h"

using namespace std;

int main()
{
	if (testingRoutine())
	{
		cout << "Testing complete.\n\n";
	}
	else
	{
		cout << "Testing failed.\n";
		return 0;
	}
	cout << "Opening file...\n";
	ifstream fin;
	fin.open("input.txt");
	cout << "File opened.\n\n";
	cout << "Creating hash table...\n";
	HashTable *table = createNewTable();
	cout << "Hash table created.\n\n";
	cout << "Processing file contents into the hash table...\n";
	vector<string> words = readFile(fin, table);
	fin.close();
	cout << "File read. Hash table filled.\n\n";
	cout << "Text stats:\n";
	for (string word : words)
	{
		cout << "The word |" << word << "| was encountered " << amountOfWord(table, word) << " times.\n";
	}
	cout << "\n";
	cout.fixed;
	cout.precision(6);
	cout << "The hash load factor is " << hashLoad(table) << "\n";
	cout << "The average list length was " << avgLength(table) << ", while the max list length was " << maxBucket(table) << "\n";
	deleteTable(table);
	cout << "Program complete. Exiting...\n";
	return 0;
}
