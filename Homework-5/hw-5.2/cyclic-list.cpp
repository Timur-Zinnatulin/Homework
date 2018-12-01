#include "cyclic-list.h"

struct Node 
{
	int value;
	Node *next;
};

struct CyclicList
{
	Node *start;
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
	while (!isEmpty(list))
	{
		auto tempNode = list->start;
		list->start = list->start->next;
		delete tempNode;
	}
	delete list;
}

//Inserts a value into a cycle
void insert(CyclicList *list, int newValue)
{
	const auto newNode = new Node{ newValue, list->start };
	if (isEmpty(list))
	{
		list->start = newNode;
		newNode->next = list->start;
		return;
	}
	auto rightNode = list->start;
	while (rightNode->next != list->start)
	{
		rightNode = rightNode->next;
	}
	rightNode->next = newNode;
	newNode->next = list->start;
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

	auto killedNode = theOneToKillTheNeighbor->next;
	theOneToKillTheNeighbor->next = killedNode->next;
	delete killedNode;
	return true;
}
