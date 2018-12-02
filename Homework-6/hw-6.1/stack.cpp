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

//Checks if the stack is empty
bool isEmpty(Stack *stack)
{
	return (stack->head == nullptr);
}

//Creates a new empty stack
Stack *createNewStack()
{
	return new Stack;
}

//Deletes the stack
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

//Pushes a value into the stack
void push(Stack *stack, int newValue)
{
	const auto newElement = new StackElement{ newValue, stack->head };
	stack->head = newElement;
}

//Pops a value out of the stack
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
