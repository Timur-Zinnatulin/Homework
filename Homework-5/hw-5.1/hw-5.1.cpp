#define _CRT_SECURE_NO_WARNINGS
#include "sorted-list.h"
#include <iostream>

int main()
{
	SortedList *list = createSortedList();
	int input = -1;
	printf("List created\n");
	while (input != 0)
	{
		std::cin >> input;
		int newVal = 0;
		if (input == 1)
		{
			std::cin >> newVal;
			insert(list, newVal);
		}
		if (input == 2)
		{
			printList(list);
		}
		if (input == 3)
		{
			std::cin >> newVal;
			bool ans = deleteNode(list, newVal);
			if (!ans)
			{
				std::cout << "No such element\n";
			}
			else
			{
				std::cout << "Elements deleted successfully\n";
			}
		}
	}
	deleteList(list);
	return 0;
}
