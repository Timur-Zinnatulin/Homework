#pragma once
#include <string>

struct Node;
struct List;

//Changes the rehash flag
void changeHashFlag(Node *target, bool rehash);

//Returns the "rehashed" condition
bool isRehashed(const Node *target);

//Returns word
std::string word(const Node *target);

//Returns amount of words
int amount(const Node *target);

//Increments the quantity of word
void addExisting(Node *target);

//Returns pointer to the next word
Node *next(const Node *current);

//Returns pointer to the previous word
Node *previous(const Node *current);

//Creates a new list
List *createNewList();

//Returns pointer to the start
Node *start(const List *list);

//Returns pointer to the end
Node *end(const List *list);

//Returns size of the list
int listSize(const List *list);

//Checks if the list is empty
bool isEmpty(List *list);

//Returns pointer to given node, or nullptr if it couldn't be found
Node *find(List *list, const std::string word);

//Adds a node to the list
void add(List *list, const std::string word, const int amount);

//Removes a node from the list
void remove(List *list, Node *node);

//Deletes the list
void deleteList(List *list);