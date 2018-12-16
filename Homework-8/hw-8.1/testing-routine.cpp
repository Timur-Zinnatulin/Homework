#include <fstream>
#include <string>
#include <vector>
#include "avl-tree.h"
#include "testing-routine.h"

#define TEST_FAILED deleteTree(testAVL); return false
#define TEST_PASSED deleteTree(testAVL); return true

//Pre-run testing function
bool testingRoutine()
{
	Tree *testAVL = createNewTree();
	if (!isEmpty(testAVL))
	{
		TEST_FAILED;
	}
	std::vector<std::pair<std::string, std::string> > records;
	std::ifstream fin;
	fin.open("test.txt", std::ios::in);
	while (!fin.eof())
	{
		std::string key;
		std::string value;
		std::getline(fin, key);
		std::getline(fin, value);
		add(testAVL, key, value);
		records.push_back({ key, value });
	}
	fin.close();
	if (isEmpty(testAVL))
	{
		TEST_FAILED;
	}
	for (int i = 0; i < records.size(); ++i)
	{
		if (!exists(testAVL, records[i].first))
		{
			TEST_FAILED;
		}
		if (value(testAVL, records[i].first) != records[i].second)
		{
			TEST_FAILED;
		}
		remove(testAVL, records[i].first);
		if (exists(testAVL, records[i].first))
		{
			TEST_FAILED;
		}
	}
	if (!isEmpty(testAVL))
	{
		TEST_FAILED;
	}
	TEST_PASSED;
}