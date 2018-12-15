#include <fstream>
#include <iostream>
#include "tree.h"

struct TreeNode
{
	int value = 0;
	TreeNode *leftChild = nullptr;
	TreeNode *rightChild = nullptr;
};

struct Tree
{
	TreeNode *root = nullptr;
};

TreeNode *addNode(std::ifstream &fin)
{
	const char next = fin.peek();
	TreeNode *newNode = new TreeNode{};
	if (next == '(')
	{
		fin.get();
		newNode->value = fin.get();
		fin.get();
		newNode->leftChild = addNode(fin);
		fin.get();
		newNode->rightChild = addNode(fin);
		fin.get();
	}
	else
	{
		if ((isdigit(next)) || (next == '-'))
		{
			fin >> newNode->value;
		}
	}
	return newNode;
}

//Creates a new tree
Tree *createTree(std::ifstream &fin)
{
	return new Tree{ addNode(fin) };
}

//Checks if the tree is empty
bool isEmpty(Tree *tree)
{
	return tree->root == nullptr;
}

void deleteSubtree(TreeNode *node)
{
	if (node->leftChild != nullptr)
	{
		deleteSubtree(node->leftChild);
	}
	if (node->rightChild != nullptr)
	{
		deleteSubtree(node->rightChild);
	}
	delete node;
}

//Deletes the tree
void deleteTree(Tree *tree)
{
	if (!isEmpty(tree))
	{
		deleteSubtree(tree->root);
	}
	delete tree;
}

int nodeEvaluation(TreeNode *node)
{
	if (node->value == '*')
	{
		return (nodeEvaluation(node->leftChild) * nodeEvaluation(node->rightChild));
	}
	else if (node->value == '/')
	{
		return (nodeEvaluation(node->leftChild) / nodeEvaluation(node->rightChild));
	}
	else if (node->value == '+')
	{
		return (nodeEvaluation(node->leftChild) + nodeEvaluation(node->rightChild));
	}
	else if (node->value == '-')
	{
		return (nodeEvaluation(node->leftChild) - nodeEvaluation(node->rightChild));
	}
	return node->value;
}

//Prints the result of expression
int treeEvaluation(Tree *tree)
{
	if (isEmpty(tree))
	{
		return 0;
	}
	return nodeEvaluation(tree->root);
}

void printSubtree(TreeNode *node)
{
	if (node->value == '*')
	{
		std::cout << "(* ";
	}
	else if (node->value == '/')
	{
		std::cout << "(/ ";
	}
	else if (node->value == '+')
	{
		std::cout << "(+ ";
	}
	else if (node->value == '-')
	{
		std::cout << "(- ";
	}
	else
	{
		std::cout << node->value;
		return;
	}

	printSubtree(node->leftChild);
	std::cout << ' ';
	printSubtree(node->rightChild);
	std::cout << ')';
}

//Prints the parsing tree
void printTree(Tree *tree)
{
	if (isEmpty(tree))
	{
		std::cout << "The tree is empty.\n";
		return;
	}
	printSubtree(tree->root);
}