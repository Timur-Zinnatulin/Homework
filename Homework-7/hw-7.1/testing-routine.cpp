#include <fstream>
#include <vector>
#include "set.h"
#include "testing-routine.h"

//Pre-run testing program
bool testingRoutine()
{
	std::ifstream fin("test.txt");
	auto testSet = createNewSet();
	while (!fin.eof())
	{
		int newValue = 0;
		fin >> newValue;
		add(testSet, newValue);
	}
	fin.close();
	fin.open("test.txt");
	while (!fin.eof())
	{
		int existingValue = 0;
		fin >> existingValue;
		if (!exists(testSet, existingValue))
		{
			deleteSet(testSet);
			return false;
		}
	}
	fin.close();
	std::vector<int> ascending = ascendingOrder(testSet);
	std::vector<int> descending = descendingOrder(testSet);
	if (ascending.size() != descending.size())
	{
		deleteSet(testSet);
		return false;
	}
	for (int i = 0; i < ascending.size() - 1; ++i)
	{
		if (ascending[i] >= ascending[i + 1])
		{
			deleteSet(testSet);
			return false;
		}
	}
	for (int i = 0; i < descending.size() - 1; ++i)
	{
		if (descending[i] <= descending[i + 1])
		{
			deleteSet(testSet);
			return false;
		}
	}
	fin.open("test.txt");
	while (!fin.eof())
	{
		int deletedNumber = 0;
		fin >> deletedNumber;
		remove(testSet, deletedNumber);
	}
	fin.close();
	if (!isEmpty(testSet))
	{
		deleteSet(testSet);
		return false;
	}
	deleteSet(testSet);
	return true;
}