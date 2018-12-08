#pragma once

struct Node;

struct List;

//Returns size of list
int listSize(List *list);

//Creates a new list
List *createNewList();

//Checks if the list is empty
bool isEmpty(List *list);

//Deletes the list
void deleteList(List *list);

//Creates a nww node at the end of the list
void push(List *list, const string name, const string number);

//Merges two lists into one
void merge(List *list, List *left, List *right, const bool cmpByName);

//Splits one list into two
void split(List *list, List *left, List *right);