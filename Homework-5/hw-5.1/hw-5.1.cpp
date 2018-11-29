#define _CRT_SECURE_NO_WARNINGS
#include "sorted-list.h"
#include "testing-routine.h"
#include <iostream>

int main()
{
	if (!testingRoutine())
	{
		printf("Test failed :(\n");
		return 0;
	}
	printf("Success! Test is passed!\nYou can use the program now.\n");
	SortedList *list = createSortedList();
	printf("\nList created\n");
	printf("Welcome to Sorted List program!\n");
	printf("You have the following commands:\n");
	printf("0 - exit\n");
	printf("1 - add a value to the sorted list\n");
	printf("2 - print contents of the sorted list\n");
	printf("3 - delete a certain value of the sorted list (this means it deletes all elements with this value)\n");
	int input = -1;
	while (input != 0)
	{
		printf("\nEnter your command: ");
		scanf("%d", &input);
		int newVal = 0;
		if (input == 1)
		{
			printf("Enter your value: ");
			scanf("%d", &newVal);
			insert(list, newVal);
			printf("Element added successfully\n");
		}
		if (input == 2)
		{
			printf("Printing the list the way it's kept:\n");
			printList(list);
		}
		if (input == 3)
		{
			printf("Enter your value: ");
			scanf("%d", &newVal);
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
