#include "hash-table.h"
#include <fstream>
#include <vector>
#include <string>
#include <algorithm>

//Reads file and returns a non-repeating vector of words
std::vector<std::string> readFile(std::ifstream &fin, HashTable *&table)
{
	std::vector<std::string> words{};
	while (!fin.eof())
	{
		std::string input;
		fin >> input;
		if (!wordExists(table, input))
		{
			words.push_back(input);
		}
		addWord(table, input);
	}
	return words;
}