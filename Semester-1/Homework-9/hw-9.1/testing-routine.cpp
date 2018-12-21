#include "testing-routine.h"

//Pre-run testing function
bool testingRoutine()
{
	std::ifstream fin("test.txt", std::ios::in);
	HashTable *table = createNewTable();
	auto testWords = readFile(fin, table);
	fin.close();
	for (std::string tempWord : testWords)
	{
		int wordFrequency = 0;
		fin.open("test.txt");
		while (!fin.eof())
		{
			std::string input;
			fin >> input;
			if (input == tempWord)
			{
				++wordFrequency;
			}
		}
		fin.close();
		if (wordFrequency != amountOfWord(table, tempWord))
		{
			deleteTable(table);
			return false;
		}
	}
	if ((hashLoad(table) > 1.0) || ((float)maxBucket(table) < (float)avgLength(table)))
	{
		deleteTable(table);
		return false;
	}
	deleteTable(table);
	return true;
}