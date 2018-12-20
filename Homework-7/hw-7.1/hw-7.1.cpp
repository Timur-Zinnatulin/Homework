#include <iostream>
#include "set.h"
#include "testing-routine.h"

using namespace std;

int main()
{
	if (testingRoutine())
	{
		cout << "Testing complete.\n";
	}
	else
	{
		cout << "Testing failed.\n";
		return 0;
	}
	auto set = createNewSet();
	cout << "Command list:\n";
	cout << "0 - Exit program.\n";
	cout << "1 - Add a new value to the set.\n";
	cout << "2 - Check if the value is in the set.\n";
	cout << "3 - Remove the value from the set.\n";
	cout << "4 - Print contents of the set in ascending order.\n";
	cout << "5 - Print contents of the set in descending order.\n";
	int input = -1;
	while (input != 0)
	{
		cin >> input;
		switch (input)
		{
		case 1:
		{
			int newValue = 0;
			cout << "Enter the number you want to put into the set: ";
			cin >> newValue;
			if (!add(set, newValue))
			{
				cout << "This value already exists.\n";
			}
			break;
		}
		case 2:
		{
			int checkedValue = 0;
			cout << "Enter the value you want to check the existence of: ";
			cin >> checkedValue;
			if (!exists(set, checkedValue))
			{
				cout << "This value does not exist in the set\n";
			}
			else
			{
				cout << "This value exists in a set.\n";
			}
			break;
		}
		case 3:
		{
			int removedValue = 0;
			cout << "Enter the value you want to remove from the set: ";
			cin >> removedValue;
			if (!remove(set, removedValue))
			{
				cout << "This value was not in the set in the first place.\n";
			}
			else
			{
				cout << "Value successfully removed.\n";
			}
			break;
		}
		case 4:
		{
			cout << "Printing the set in ascending order:\n";
			vector<int> ascending = ascendingOrder(set);
			for (int i = 0; i < ascending.size(); ++i)
			{
				cout << ascending[i] << " ";
			}
			cout << "\n";
			break;
		}
		case 5:
		{
			cout << "Printing the set in descending order:\n";
			vector<int> descending = descendingOrder(set);
			for (int i = 0; i < descending.size(); ++i)
			{
				cout << descending[i] << " ";
			}
			cout << "\n";
			break;
		}
		default:
		{
			input = 0;
			break;
		}
		}
	}
	deleteSet(set);
	cout << "Exiting...\n";
	return 0;
}
