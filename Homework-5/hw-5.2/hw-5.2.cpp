#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include "cyclic-list.h"
#include "testing-routine.h"

int main()
{
	if (testingRoutine())
	{
		printf("TEST PASSED\n");
	}
	printf("Welcome to Josephus Problem Solver ver.1!\n");
	printf("Enter the amount of sicarii: ");
	int amountOfSicarii = 0;
	scanf("%d", &amountOfSicarii);
	CyclicList *list = createNewList();
	generateCycle(list, amountOfSicarii);
	printf("Circle generated.\n");
	printf("Enter the elimintaion modulo: ");
	int moduloOfElimination = 0;
	scanf("%d", &moduloOfElimination);
	printf("The person in position %d survives the elimination.", sicariiCycle(list, moduloOfElimination));
	deleteList(list);
	return 0;
}

