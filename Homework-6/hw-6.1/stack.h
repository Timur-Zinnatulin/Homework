#pragma once

struct StackElement;

struct Stack;

//Checks if the stack is empty
bool isEmpty(Stack *stack);

//Creates a new empty stack
Stack *createNewStack();

//Deletes the stack
void deleteStack(Stack *stack);

//Pushes a value into the stack
void push(Stack *stack, int newValue);

//Pops a value out of the stack
int pop(Stack *stack);