#include "sorted-list.h"
#include <stdio.h>

//Creates a new empty list
SortedList *createSortedList()
{
	return new SortedList;
}

//Checks if the list is empty
bool isEmpty(SortedList *list)
{
	return (list->start == nullptr);
}

//Instert a new element into the sorted list
void insert(SortedList *list, int newValue)
{
	const auto newElement = new Node{newValue, nullptr};
	if (isEmpty(list))
	{
		list->start = newElement;
	}
	else
	{
		Node *leftNode = nullptr;
		auto rightNode = list->start;
		while ((rightNode != nullptr) && (newElement->value > rightNode->value))
		{
			leftNode = rightNode;
			rightNode = rightNode->next;
		}
		if (leftNode != nullptr)
		{
			newElement->next = rightNode;
			leftNode->next = newElement;
		}

		else
		{
			newElement->next = list->start;
			list->start = newElement;
		}
	}
	++list->size;
}

//Deletes the entire list
void deleteList(SortedList *list)
{
	while (!isEmpty(list))
	{
		const Node *tempNode = list->start;
		list->start = list->start->next;
		delete tempNode;
	}
	delete list;
}

//Deletes all nodes with the given value if those exist. Keeps the list sorted
bool deleteNode(SortedList *list, int value)
{
	Node *leftNode = nullptr;
	auto rightNode = list->start;
	if (rightNode == nullptr)
	{
		return false;
	}

	while ((rightNode->next != nullptr) && (rightNode->value < value))
	{
		leftNode = rightNode;
		rightNode = rightNode->next;
	}
	if (rightNode->value > value)
	{
		return false;
	}
	else
	{
		while ((rightNode->value == value) && (rightNode->next != nullptr))
		{
			const Node *tempNode = rightNode;
			rightNode = rightNode->next;
			delete tempNode;
			--list->size;
		}
		if (rightNode->value == value)
		{
			const Node *tempNode = rightNode;
			rightNode = nullptr;
			delete tempNode;
			--list->size;
		}
		if (leftNode != nullptr)
		{
			leftNode->next = rightNode;
		}
		else
		{
			list->start = rightNode;
		}
		return true;
	}
}

//Prints out contents of the list
void printList(SortedList *list)
{
	if (isEmpty(list))
	{
		printf("The list is empty.\n");
		return;
	}

	auto tempNode = list->start;
	while (tempNode != nullptr)
	{
		printf("%d ", tempNode->value);
		tempNode = tempNode->next;
	}
	printf("\n");
}