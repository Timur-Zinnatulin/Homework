#include "testing-routine.h"
#include "merge-sort.h"
#include "file.h"
#include "list.h"

//Pre-run testing function
bool testingRoutine()
{
	auto testList = createNewList();
	openFile("test.txt", testList);
	const bool byName = true;
	const bool byNumber = false;
	mergeSort(testList, byName);
	if (!checkIfSorted(testList, byName))
	{
		deleteList(testList);
		return false;
	}
	mergeSort(testList, byNumber);
	if (!checkIfSorted(testList, byNumber))
	{
		deleteList(testList);
		return false;
	}
	deleteList(testList);
	return true;
}