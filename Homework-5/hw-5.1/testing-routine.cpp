#include "sorted-list.h"
#include "testing-routine.h"
#include <stdlib.h>
#include <time.h>

//Checks if the list is sorted
bool checkIfSorted(SortedList *list)
{
	auto node = list->start;
	if (node == nullptr)
	{
		return true;
	}
	while (node->next != nullptr)
	{
		if (node->value > node->next->value)
		{
			return false;
		}
		node = node->next;
	}
	return true;
}

//Pre-run testing function
bool testingRoutine()
{
	SortedList *list = createSortedList();
	const int desiredSize = 1;
	const int randomValue1 = rand() % 1001 - 500;
	//Check if values are actually inserted
	insert(list, randomValue1);
	if (list->size != desiredSize)
	{
		deleteList(list);
		return false;
	}
	//Inserting a duplicate for later check
	insert(list, randomValue1);
	//Insert a lesser value and check if it sorts correctly
	const int lesserValue = randomValue1 - 1;
	insert(list, lesserValue);
	if (!checkIfSorted(list))
	{
		deleteList(list);
		return false;
	}
	//Check if nodes are deleted correctly
	deleteNode(list, randomValue1);
	if (list->size != desiredSize)
	{
		deleteList(list);
		return false;
	}
	//Check if list can empty itself correctly through deleting nodes
	deleteNode(list, lesserValue);
	if (!isEmpty(list))
	{
		deleteList(list);
		return false;
	}
	//We have checked everything so we can return triumphantly
	deleteList(list);
	return true;
}