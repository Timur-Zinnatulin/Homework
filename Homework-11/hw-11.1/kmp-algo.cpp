#include "kmp-algo.h"
#include <string>
#include <vector>
#include <fstream>

std::vector<int> prefixFunction(const std::string &source)
{
	std::vector<int> prefix;
	prefix.push_back(0);
	for (int i = 1; i < source.size(); ++i)
	{
		int longestPrefix = prefix[i - 1];
		while ((longestPrefix != 0) && (source[longestPrefix] != source[i]))
		{
			longestPrefix = prefix[longestPrefix - 1];
		}
		prefix.push_back((source[longestPrefix] == source[i]) ? longestPrefix + 1 : 0);
	}
	return prefix;
}

//Knuth-Morris-Pratt algorithm that returns the first position where substring is met
int substringPosition(std::ifstream &fin, const std::string &substring)
{
	std::vector<int> substringPrefix = prefixFunction(substring);
	char input = fin.get();
	int substringComp = 0;
	int position = 0;
	while (!fin.eof())
	{
		if (input == substring[substringComp])
		{
			fin.get(input);
			++substringComp;
			++position;
			if (substringComp == substring.size())
			{
				fin.seekg(0, fin.end);
				return (position - substringComp + 1);
			}
		}
		else
		{
			if (substringComp == 0)
			{
				fin.get(input);
				++position;
			}
			else
			{
				substringComp = substringPrefix[substringComp - 1];
			}
		}
	}
	return -1;
}