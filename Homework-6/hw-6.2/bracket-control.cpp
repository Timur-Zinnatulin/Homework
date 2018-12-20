#include "stack.h"
#include "bracket-control.h"

bool leftBracket(char bracket)
{
	return (bracket == '(' || bracket == '[' || bracket == '{');
}

bool rightBracket(char bracket)
{
	return (bracket == ')' || bracket == ']' || bracket == '}');
}

bool matchingBrackets(char bracket1, char bracket2)
{
	return ((bracket1 == '{' && bracket2 == '}') || (bracket1 == '[' && bracket2 == ']') || (bracket1 == '(' && bracket2 == ')'));
}

//Checks if bracket sequence is correct
bool correctSequence(char *input)
{
	bool ifCorrect = true;
	auto stack = createNewStack();
	for (int i = 0; input[i] != '\0'; ++i)
	{
		if (leftBracket(input[i]))
		{
			push(stack, input[i]);
		}
		else
		{
			if (rightBracket(input[i]))
			{
				if (matchingBrackets(top(stack), input[i]))
				{
					pop(stack);
				}
				else
				{
					ifCorrect = false;
					break;
				}
			}
		}
	}
	if (!isEmpty(stack))
	{
		ifCorrect = false;
	}
	deleteStack(stack);
	return ifCorrect;
}