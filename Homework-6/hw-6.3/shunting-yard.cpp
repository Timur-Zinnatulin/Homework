#include "shunting-yard.h"
#include "stack.h"
#include <string>

bool isDigit(char value)
{
	return (value >= '0' && value <= '9');
}

bool isOperator(char value)
{
	return (value == '+' || value == '-' || value == '*' || value == '/');
}

bool hasPriority(char value)
{
	return (value == '*' || value == '/');
}

//Transforms the infix expression into postfix form
std::string shuntingYard(std::string input)
{
	std::string output{};
	Stack *stack = createNewStack();
	for (int i = 0; i < input.size(); ++i)
	{
		if (isDigit(input[i]))
		{
			output.push_back(input[i]);
			output.push_back(' ');
		}
		else if (isOperator(input[i]))
		{
			if (!isEmpty(stack) && hasPriority(top(stack)))
			{
				output.push_back(top(stack));
				output.push_back(' ');
			}
			push(stack, input[i]);
		}
		else if (input[i] == '(')
		{
			push(stack, input[i]);
		}
		else if (input[i] == ')')
		{
			while (top(stack) != '(')
			{
				output.push_back(top(stack));
				output.push_back(' ');
				pop(stack);
			}
			pop(stack);
		}
	}
	while (!isEmpty(stack))
	{
		output.push_back(top(stack));
		output.push_back(' ');
		pop(stack);
	}
	deleteStack(stack);
	return output;
}