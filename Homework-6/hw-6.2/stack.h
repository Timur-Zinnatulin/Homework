#pragma once

struct StackElement;

struct Stack;

//Checks if the stack is empty
bool isEmpty(Stack *stack);

//Creates a new empty stack
Stack *createNewStack();

//Deletes the stack
void deleteStack(Stack *stack);

//Returns the value of head
char top(Stack *stack);

//Pushes a value into the stack
void push(Stack *stack, char newValue);

//Pops a value out of the stack
void pop(Stack *stack);