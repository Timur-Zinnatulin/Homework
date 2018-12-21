#include <iostream>
#include "list.h"
#include "merge-sort.h"
#include "file.h"
#include "testing-routine.h"

using namespace std;

int main()
{
	if (testingRoutine())
	{
		cout << "Testing complete.\n";
	}
	cout << "Welcome to merge sort program ver.1!\n";
	auto list = createNewList();
	cout << "Opening mergesort.txt...\n";
	openFile("mergesort.txt", list);
	if (isEmpty(list))
	{
		cout << "The file is empty!\n";
		deleteList(list);
		return 0;
	}
	cout << "File successfully read.\n\n";
	cout << "How do you want to sort the phonebook?\n";
	cout << "Sort it by name? (Y/N): ";
	char byName = '\0';
	cin >> byName;
	if (byName == 'Y')
	{
		cout << "Sorting by name...\n";
	}
	else
	{
		cout << "Sorting by number...\n";
	}
	bool cmpByName = (byName == 'Y' ? true : false);
	mergeSort(list, cmpByName);
	cout << "Phonebook sorted successfully. Printing...\n";
	printList(list);
	cout << "Exiting program...";
	deleteList(list);
	return 0;
}
