#include "list.h"
#include <string>

using namespace std;

struct Node
{
	string name{};
	string number{};
	Node *previous = nullptr;
	Node *next;
};

struct List
{
	Node *start = nullptr;
	Node *end = nullptr;
	int size = 0;
};

//Returns size of list
int listSize(List *list)
{
	return list->size;
}

//Creates a new list
List *createNewList()
{
	return new List;
}

//Checks if the list is empty
bool isEmpty(List *list)
{
	return (list->start == nullptr);
}

//Deletes the list
void deleteList(List *list)
{
	while (list->start != list->end)
	{
		const auto temp = list->start;
		list->start = list->start->next;
		delete temp;
	}
	delete list->start;
	delete list;
}

//Creates a nww node at the end of the list
void push(List *list, const string name, const string number)
{
	list->end = new Node{ name, number, list->end, nullptr };
	if (isEmpty(list))
	{
		list->start = list->end;
	}
	else
	{
		list->end->previous->next = list->end;
	}
	++list->size;
}

//Merges two lists into one
void merge(List *list, List *left, List *right, const bool cmpByName)
{
	auto mergeNode = list->start;
	auto leftNode = left->start;
	auto rightNode = right->start;

	while (leftNode != nullptr || rightNode != nullptr)
	{
		if (leftNode == nullptr || (rightNode != nullptr && cmpByName ? leftNode->name.compare(rightNode->name) : leftNode->number.compare(rightNode->number)))
		{
			mergeNode->name = rightNode->name;
			mergeNode->number = rightNode->number;
			rightNode = rightNode->next;
		}
		else
		{
			mergeNode->name = leftNode->name;
			mergeNode->number = leftNode->number;
			leftNode = leftNode->next;
		}
		mergeNode = mergeNode->next;
	}
}

//Splits one list into two
void split(List *list, List *left, List *right)
{
	auto temp = list->start;
	for (int i = 1; i <= list->size; ++i)
	{
		if (i <= list->size / 2)
		{
			push(left, temp->name, temp->number);
		}
		else
		{
			push(right, temp->name, temp->number);
		}
		temp = temp->next;
	}
}
