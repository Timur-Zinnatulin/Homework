#pragma once
#include <fstream>

struct TreeNode;

struct Tree;

//Creates a new tree
Tree *createTree(std::ifstream &fin);

//Checks if the tree is empty
bool isEmpty(Tree *tree);

//Deletes the tree
void deleteTree(Tree *tree);

//Prints the result of expression
int treeEvaluation(Tree *tree);

//Prints the parsing tree
void printTree(Tree *tree);
