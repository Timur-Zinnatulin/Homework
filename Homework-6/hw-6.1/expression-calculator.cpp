#include "stack.h"
#include "expression-calculator.h"

//Checks if the char is a digit
bool isNumber(char digit)
{
	return (digit >= '0' && digit <= '9');
}

//Checks if the char is an operator
bool isOperator(char sign)
{
	return (sign == '+' || sign == '-' || sign == '*' || sign == '/');
}

//Converts char to int
int charToInt(char digit)
{
	return (digit - '0');
}

//Calculates the result of one binary expression
int result(int digit1, int digit2, char sign)
{
	switch (sign)
	{
		case '+':
			return digit1 + digit2;
		case '-':
			return digit1 - digit2;
		case '*':
			return digit1 * digit2;
		case '/':
			if (digit2 == 0)
			{
				return -1;
			}
			else
			{
				return digit1 / digit2;
			}
		default:
			return 0;
	}
}

//Calculates the result of the entire string
bool calculateInput(Stack *stack, char *input)
{
	bool ifNoDivisionsByZero = true;
	for (int i = 0; input[i] != '\0'; ++i)
	{
		if (isNumber(input[i]))
		{
			push(stack, charToInt(input[i]));
		}
		if (isOperator(input[i]))
		{
			int number2 = pop(stack);
			int number1 = pop(stack);
			if ((result(number1, number2, input[i]) == -1) && (input[i] == '/'))
			{
				ifNoDivisionsByZero = false;
				break;
			}
			push(stack, result(number1, number2, input[i]));
		}
	}
	return ifNoDivisionsByZero;
}