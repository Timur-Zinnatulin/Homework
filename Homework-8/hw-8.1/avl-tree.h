#pragma once

struct Node;

struct Tree;

//Creates a new tree
Tree *newTree();

//Checks if the tree is empty
bool isEmpty(Tree *tree);

//Checks if the element with given key exists in the tree
bool exists(Tree *tree, const std::string key);

//Returns element's value by its key
std::string value(Tree *tree, const std::string key);

//Adds an element with given key and value to the tree
void add(Tree *tree, const std::string key, const std::string newValue);

//Removes a value from the set
bool remove(Tree *tree, const std::string value);

//Deletes the tree
void deleteTree(Tree *tree);