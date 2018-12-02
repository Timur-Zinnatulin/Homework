#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include "stack.h"
#include "bracket-control.h"

int main()
{
	char *input = new char[100]{};
	scanf("%[^\n]s", input);
	if (correctSequence(input))
	{
		printf("YEAH!!\n");
	}
	else
	{
		printf("no :(\n");
	}
	return 0;
}
