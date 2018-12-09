#include <iostream>
#include <fstream>
#include <vector>

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

void insert(List *list, int number)
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
	leftNode->next = newNode;
	++list->size;
}

bool checkForSymmetricity(List *list1, List *list2)
{
	auto tempNode1 = list1->start;
	auto tempNode2 = list2->start;
	bool answer = true;
	while (tempNode1 != nullptr)
	{
		if (tempNode1->value != tempNode2->value)
		{
			answer = false;
		}
		tempNode1 = tempNode1->next;
		tempNode2 = tempNode2->next;
	}
	return answer;
}

bool test()
{
	ifstream testIn;
	testIn.open("test.txt");
	List *list = createNewList();
	int testInt = 0;
	vector<int> testData{};
	while (testIn >> testInt)
	{
		insert(list, testInt);
		testData.push_back(testInt);
	}
	List *list1 = createNewList();
	for (int i = testData.size() - 1; i >= 0; --i)
	{
		insert(list1, testData[i]);
	}
	bool testAns = checkForSymmetricity(list, list1);
	deleteList(list);
	deleteList(list1);
	return testAns;
}

int main()
{
	if (test())
	{
		cout << "SUCCESSFUL TEST!!!\n";
	}
	else
	{
		cout << "unsuccessful test :(\n";
	}
	ifstream fin;
	fin.open("f.txt");
	int fileInt = 0;
	vector<int> fileData{};
	List *list = createNewList();
	while (fin >> fileInt)
	{
		insert(list, fileInt);
		fileData.push_back(fileInt);
	}
	List *reverseList = createNewList();
	for (int i = fileData.size() - 1; i >= 0; --i)
	{
		insert(reverseList, fileData[i]);
	}
	bool answer = checkForSymmetricity(list, reverseList);
	deleteList(list);
	deleteList(reverseList);
	if (answer)
	{
		cout << "THE LIST IS SYMMETRICAL\n";
	}
	else
	{
		cout << "THE LIST IS NOT SYMMETRICAL\n";
	}
	return 0;
}



