#include "list.h"
#include <string>

struct Node
{
	bool isRehashed = false;
	std::string word{};
	int amount = 0;
	Node *previous = nullptr;
	Node *next = nullptr;
};

struct List
{
	Node *start = nullptr;
	Node *end = nullptr;
	int size = 0;
};

//Changes the rehash flag
void rehash(Node *target, bool rehash)
{
	target->isRehashed = rehash;
}

//Returns the "rehashed" condition
bool isRehashed(const Node *target)
{
	return target->isRehashed;
}

//Returns word
std::string word(const Node *target)
{
	return target->word;
}

//Returns amount of words
int amount(const Node *target)
{
	return target->amount;
}

//Increments the quantity of word
void addExisting(Node *target)
{
	if (target != nullptr)
	{
		++target->amount;
	}
}

//Returns pointer to the next word
Node *next(const Node *current)
{
	return current->next;
}

//Returns pointer to the previous word
Node *previous(const Node *current)
{
	return current->previous;
}

//Creates a new list
List *createNewList()
{
	return new List;
}

//Returns pointer to the start
Node *start(const List *list)
{
	return list->start;
}

//Returns pointer to the end
Node *end(const List *list)
{
	return list->end;
}

//Returns size of the list
int listSize(const List *list)
{
	return list->size;
}

//Checks if the list is empty
bool isEmpty(List *list)
{
	return (list->size == 0);
}

//Returns pointer to given node, or nullptr if it couldn't be found
Node *find(List *list, const std::string word)
{
	auto tempNode = list->start;
	while (tempNode != nullptr)
	{
		if (tempNode->word == word)
		{
			return tempNode;
		}
		tempNode = tempNode->next;
	}
	return tempNode;
}

//Adds a node to the list
void add(List *list, const std::string word, const int amount)
{
	list->start = new Node{ false, word, amount, nullptr, list->start };
	if (isEmpty(list))
	{
		list->end = list->start;
	}
	else
	{
		list->start->next->previous = list->start;
	}
	++list->size;
}

//Removes a node from the list
void remove(List *list, Node *node)
{
	if (node->previous != nullptr)
	{
		node->previous->next = node->next;
	}
	else
	{
		list->start = node->next;
	}
	if (node->next != nullptr)
	{
		node->next->previous = node->previous;
	}
	else
	{
		list->end = node->previous;
	}
	--list->size;
	delete node;
}

//Deletes the list
void deleteList(List *list)
{
	while (list->start != list->end)
	{
		remove(list, list->start);
	}
	delete list->start;
	delete list;
}