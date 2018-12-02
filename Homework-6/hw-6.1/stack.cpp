#include "stack.h"

struct StackElement
{
	int value = 0;
	StackElement *next = nullptr;
};

struct Stack
{
	StackElement *head = nullptr;
};

bool isEmpty(Stack *stack)
{
	return (stack->head == nullptr);
}

Stack *createNewStack()
{
	return new Stack;
}

void deleteStack(Stack *stack)
{
	while (!isEmpty(stack))
	{
		const auto tempStackElement = stack->head;
		stack->head = stack->head->next;
		delete tempStackElement;
	}
	delete stack;
}

void push(Stack *stack, int newValue)
{
	const auto newElement = new StackElement{ newValue, stack->head };
	stack->head = newElement;
}

int pop(Stack *stack)
{
	if (isEmpty(stack))
	{
		return 0;
	}
	StackElement *poppedHead = stack->head;
	stack->head = stack->head->next;
	int value = poppedHead->value;
	delete poppedHead;
	return value;
}
