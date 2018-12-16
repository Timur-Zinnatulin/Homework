#include <iostream>
#include <string>
#include "avl-tree.h"
#include "testing-routine.h"

using namespace std;

string getKey()
{
	string key;
	cout << "Enter the key: ";
	cin.get();
	getline(cin, key);
	return key;
}

int main()
{
	if (testingRoutine())
	{
		cout << "Testing complete.\n\n";
	}
	else
	{
		cout << "Testing failed.\n";
		return 0;
	}
	cout << "Welcome to AVL-tree map demonstration program!\n";
	cout << "You can use the following commands:\n";
	cout << "1 - add a value with a key to the map {key, value}.\n";
	cout << "2 - get a value from a map by the given key.\n";
	cout << "3 - check if the given key is present in the map.\n";
	cout << "4 - delete an element with the given key from the map.\n";
	cout << "0 - exit the program.\n\n";
	int input = -1;
	Tree *map = createNewTree();
	while (input != 0)
	{
		cout << "Enter the command: ";
		cin >> input;
		switch (input)
		{
		case 1:
		{
			string key = getKey();
			string value;
			cout << "Enter the value: ";
			getline(cin, value);
			add(map, key, value);
			cout << "An element with key = " << key << " and value = " << value << " has been successfully added.\n";
			break;
		}
		case 2:
		{
			string key = getKey();
			if (!exists(map, key))
			{
				cout << "The element with key = " << key << " does not exist.\n";
			}
			else
			{
				cout << "The element with key = " << key << " has a value = " << value(map, key) << "\n";
			}
			break;
		}
		case 3:
		{
			string key = getKey();
			if (!exists(map, key))
			{
				cout << "The element with key = " << key << " does not exist.\n";
			}
			else
			{
				cout << "The element with key = " << key << " exists.\n";
			}
			break;
		}
		case 4:
		{
			string key = getKey();
			if (!exists(map, key))
			{
				cout << "There is no such element, map is unchanged.\n";
			}
			else
			{
				remove(map, key);
				cout << "Element with key = " << key << " successfully removed.\n";
			}
			break;
		}
		default:
		{
			input = 0;
			break;
		}
		}
		cout << "_____________________\n";
	}
	deleteTree(map);
	cout << "Program finished working. Exiting...\n";
	return 0;
}
