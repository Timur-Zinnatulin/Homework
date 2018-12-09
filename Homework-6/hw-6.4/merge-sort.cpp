#include "list.h"
#include "merge-sort.h"

//MergeSort function
void mergeSort(List *list, const bool cmpByName)
{
	if (listSize(list) == 1)
	{
		return;
	}
	auto left = createNewList();
	auto right = createNewList();
	split(list, left, right);
	mergeSort(left, cmpByName);
	mergeSort(right, cmpByName);
	merge(list, left, right, cmpByName);
	deleteList(left);
	deleteList(right);
}