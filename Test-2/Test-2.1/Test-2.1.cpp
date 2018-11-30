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

//Deletes the entire list
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

int condition(int number, int a, int b)
{
	if (number < a)
	{
		return 0;
	}
	if (number >= a)
	{
		if (number <= b)
		{
			return 1;
		}
		else
		{
			return 2;
		}
	}
}

void insert(List *list, int number, int a, int b)
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
	while ((rightNode != nullptr) && (condition(number, a, b) >= condition(rightNode->value, a, b)))
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

bool test()
{
	bool ifCorrect = true;
	int testValues[7] = { 1, 2, 3, 6, 7, 15, 20 };
	const int testA = 5;
	const int testB = 10;
	List *testList = createNewList();
	ifstream testIn;
	testIn.open("test.txt");
	int testInt = 0;
	while (testIn >> testInt)
	{
		insert(testList, testInt, testA, testB);
	}
	testIn.close();
	int iterator = 0;
	auto tempNode = testList->start;
	while (tempNode != nullptr)
	{
		if (testValues[iterator] != tempNode->value)
		{
			ifCorrect = false;
		}
		++iterator;
		tempNode = tempNode->next;
	}
	deleteList(testList);
	return ifCorrect;
}

int main()
{
	if (test)
	{
		cout << "SUCCESSFUL TEST!!!\n";
	}
	else
	{
		return 0;
	}
	int a, b;
	cout << "Enter the left border: ";
	cin >> a;
	cout << "Enter the right border: ";
	cin >> b;
	ifstream fin;
	fin.open("f.txt");
	int fileInt = 0;
	List *list = createNewList();
	while(fin >> fileInt)
	{
		insert(list, fileInt, a, b);
	}
	fin.close();
	ofstream fout;
	fout.open("g.txt");
	auto tempNode = list->start;
	while (tempNode != nullptr)
	{
		fout << tempNode->value << " ";
		tempNode = tempNode->next;
	}
	fout.close();
	deleteList(list);
	return 0;
}
