#include <fstream>
#include <vector>
#include "set.h"
#include "testing-routine.h"

//Pre-run testing program
bool testingRoutine()
{
	std::ifstream fin("test.txt", std::ios::in);
	auto testSet = createNewSet();
	while (!fin.eof())
	{
		int newValue = 0;
		fin >> newValue;
		add(testSet, newValue);
	}
	fin.close();
	fin.open("test.txt", std::ios::in);
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
	const auto ascending = ascendingOrder(testSet);
	const auto descending = descendingOrder(testSet);
	if (ascending.size() != descending.size())
	{
		deleteSet(testSet);
		return false;
	}
	for (int i = 0; i < ascending.size(); ++i)
	{
		if (ascending[i] >= ascending[i + 1])
		{
			deleteSet(testSet);
			return false;
		}
	}
	for (int i = 0; i < descending.size(); ++i)
	{
		if (descending[i] <= descending[i + 1])
		{
			deleteSet(testSet);
			return false;
		}
	}
	fin.open("test.txt", std::ios::in);
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