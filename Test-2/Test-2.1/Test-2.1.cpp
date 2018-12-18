#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <fstream>

using namespace std;

struct Node
{
	int value = 0;
	Node *next = nullptr;
};

struct List
{
	Node *start = nullptr;
	int size = 0;
};

//Creates a new empty list
List *createNewList()
{
	return new List;
}

//Checks if the list is empty
bool isEmpty(List *list)
{
	return (list->start == nullptr);
}

void deleteList(List *list)
{
	while (!isEmpty(list))
	{
		const Node *tempNode = list->start;
		list->start = list->start->next;
		delete tempNode;
	}
	delete list;
}

//Clears the entire list
void clearList(List *&list)
{
	while (!isEmpty(list))
	{
		const Node *tempNode = list->start;
		list->start = list->start->next;
		delete tempNode;
	}
	list->size = 0;
	list->start = nullptr;
}

void insert(List *&list, int number)
{
	const auto newNode = new Node{ number, nullptr };
	if (isEmpty(list))
	{
		list->start = newNode;
		++list->size;
		return;
	}
	Node *leftNode = nullptr;
	auto rightNode = list->start;
	while (rightNode != nullptr)
	{
		leftNode = rightNode;
		rightNode = rightNode->next;
	}
	if (leftNode != nullptr)
	{
		newNode->next = rightNode;
		leftNode->next = newNode;
	}
	else
	{
		newNode->next = list->start;
		list->start = newNode;
	}
	++list->size;
}

List *subsequence(List *list)
{
	int previous = list->start->value;
	List *subList = createNewList();
	List *maxList = createNewList();
	insert(subList, previous);
	insert(maxList, previous);
	auto tempNode = list->start->next;
	for (int i = 1; i < list->size; ++i)
	{
		if (tempNode->value < previous)
		{
			if (maxList->size < subList->size)
			{
				maxList->start = subList->start;
				maxList->size = subList->size;
			}
			clearList(subList);
		}
		insert(subList, tempNode->value);
		previous = tempNode->value;
		tempNode = tempNode->next;
	}
	deleteList(subList);
	return maxList;
}

void printList(List *list)
{
	auto tempNode = list->start;
	for (int i = 0; i < list->size; ++i)
	{
		cout << tempNode->value << " ";
		tempNode = tempNode->next;
	}
	cout << endl;
}

bool test()
{
	int testValues[7] = { 1, 2, 3, 6, 7, 15, 8 };
	List *testList = createNewList();
	for (int i : testValues)
	{
		insert(testList, i);
	}
	List *testAnswerList = subsequence(testList);
	int testAnswer = testAnswerList->size;
	deleteList(testList);
	deleteList(testAnswerList);
	return (testAnswer == 6);
}

int main()
{
	if (test())
	{
		cout << "SUCCESSFUL TEST!!!\n";
	}
	else
	{
		return 0;
	}
	List *fileList = createNewList();
	ifstream fin("f.txt");
	int input = 0;
	while (!fin.eof())
	{
		fin >> input;
		insert(fileList, input);
	}
	fin.close();
	List *subsequentList = subsequence(fileList);
	printList(subsequentList);
	deleteList(subsequentList);
	deleteList(fileList);
	return 0;
}
