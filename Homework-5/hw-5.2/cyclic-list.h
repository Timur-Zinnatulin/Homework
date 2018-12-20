#pragma once

struct Node;

struct CyclicList;

//Checks if the list is empty
bool isEmpty(CyclicList *list);

//Creates an empty list
CyclicList *createNewList();

//Deletes the entire list
void deleteList(CyclicList *list);

//Inserts a value into a cycle
void insert(CyclicList *list, int newValue);

//Creates a cycle of size "size" in the list
void generateCycle(CyclicList *list, int size);

//Deletes a node unless it's the last node in the cycle
bool deleteNode(CyclicList *list, Node *theOneToKillTheNeighbor);

//Performs the sicarii cycle elimination
int sicariiCycle(CyclicList *list, int modulo);