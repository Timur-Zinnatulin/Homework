#pragma once

struct SortedList;

//Creates a new empty list
SortedList *createSortedList();

//Checks if the list is empty
bool isEmpty(SortedList *list);

//Inserts a new element into the sorted list
void insert(SortedList *list, int newValue);

//Deletes the entire list
void deleteList(SortedList *list);

//Deletes all nodes with the given value if those exist. Keeps the list sorted
bool deleteNode(SortedList *list, int value);

//Prints out contents of the list
void printList(SortedList *list);