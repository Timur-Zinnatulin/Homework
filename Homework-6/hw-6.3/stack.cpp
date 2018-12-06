#include "stack.h"

struct StackElement
{
	char value = '\0';
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

//Returns the value of head
bool top(Stack *stack, char &value)
{
	if (isEmpty(stack))
	{
		return false;
	}
	value = stack->head->value;
	return true;
}

//Pushes a value into the stack
void push(Stack *stack, char newValue)
{
	const auto newElement = new StackElement{ newValue, stack->head };
	stack->head = newElement;
}

//Pops a value out of the stack
void pop(Stack *stack)
{
	if (isEmpty(stack))
	{
		return;
	}
	StackElement *poppedHead = stack->head;
	stack->head = stack->head->next;
	delete poppedHead;
}