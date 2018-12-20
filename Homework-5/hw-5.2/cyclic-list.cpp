#include "cyclic-list.h"

struct Node 
{
	int value;
	Node *next = nullptr;
};

struct CyclicList
{
	Node *start = nullptr;
	Node *lastAdded = nullptr;
};

//Checks if the list is empty
bool isEmpty(CyclicList *list)
{
	return (list->start == nullptr);
}

//Creates an empty list
CyclicList *createNewList()
{
	return new CyclicList;
}

//Deletes the entire list
void deleteList(CyclicList *list)
{
	delete list->start;
	delete list;
}

//Inserts a value into a cycle
void insert(CyclicList *list, int newValue)
{
	const auto newNode = new Node{ newValue, list->start };
	if (isEmpty(list))
	{
		newNode->next = newNode;
		list->start = newNode;
	}
	else
	{
		list->lastAdded->next = newNode;
	}
	list->lastAdded = newNode;
}

//Creates a cycle of size "size" in the list
void generateCycle(CyclicList *list, int size)
{
	for (int i = 1; i <= size; ++i)
	{
		insert(list, i);
	}
}

//Deletes a node unless it's the last node in the cycle
bool deleteNode(CyclicList *list, Node *theOneToKillTheNeighbor)
{
	if (theOneToKillTheNeighbor->next == theOneToKillTheNeighbor)
	{
		return false;
	}

	const auto killedNode = theOneToKillTheNeighbor->next;
	theOneToKillTheNeighbor->next = killedNode->next;
	delete killedNode;
	return true;
}

//Performs the sicarii cycle elimination
int sicariiCycle(CyclicList *list, int modulo)
{
	auto currentNode = list->lastAdded;
	int counter = 1;
	bool flagHavePeopleToKill = true;
	while (flagHavePeopleToKill)
	{
		if (counter % modulo == 0)
		{
			flagHavePeopleToKill = deleteNode(list, currentNode);
		}
		else
		{
			currentNode = currentNode->next;
		}
		++counter;
	}
	list->start = currentNode;
	return currentNode->value;
}