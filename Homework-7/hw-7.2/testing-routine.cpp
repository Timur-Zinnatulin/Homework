#include "testing-routine.h"
#include "tree.h"
#include <fstream>

//Pre-run testing function
bool testingRoutine()
{

	std::ifstream fin("test.txt", std::ios::in);
	Tree *test1 = createTree(fin);
	fin.get();
	Tree *test2 = createTree(fin);
	fin.close();
	if (isEmpty(test1) || isEmpty(test2))
	{
		deleteTree(test1);
		deleteTree(test2);
		return false;
	}
	const int result1 = treeEvaluation(test1);
	const int result2 = treeEvaluation(test2);
	const int answer1 = 4;
	const int answer2 = -4;
	if ((result1 != answer1) || (result2 != answer2))
	{
		deleteTree(test1);
		deleteTree(test2);
		return false;
	}
	deleteTree(test1);
	deleteTree(test2);
	return true;
}