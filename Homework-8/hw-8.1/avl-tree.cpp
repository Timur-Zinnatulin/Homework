#include <string>
#include "avl-tree.h"

struct Node
{
	std::string key;
	std::string value;
	int height = 0;
	Node *leftChild = nullptr;
	Node *rightChild = nullptr;
};

struct Tree
{
	Node *root = nullptr;
};

//Creates a new tree
Tree *createNewTree()
{
	return new Tree{};
}

//Checks if the tree is empty
bool isEmpty(Tree *tree)
{
	return (tree->root == nullptr);
}

int height(Node *node)
{
	return (node != nullptr ? node->height : 0);
}

void updateHeight(Node *node)
{
	node->height = ((height(node->rightChild) > height(node->leftChild)) ? height(node->rightChild) : height(node->leftChild) + 1);
}

int balance(Node *node)
{
	return (node != nullptr ? height(node->rightChild) - height(node->leftChild) : 0);
}

//Checks if the element with given key exists in the tree
bool exists(Tree *tree, const std::string key)
{
	if (isEmpty(tree))
	{
		return false;
	}
	Node *temp = tree->root;
	while ((temp != nullptr) && (temp->key != key))
	{
		temp = ((key > temp->key) ? temp->rightChild : temp->leftChild);
	}
	return (temp != nullptr);
}

void leftRotation(Node *&node)
{
	Node *temp = node->rightChild;
	node->rightChild = temp->leftChild;
	temp->leftChild = node;
	updateHeight(node);
	node = temp;
}

void rightRotation(Node *&node)
{
	Node *temp = node->leftChild;
	node->leftChild = temp->rightChild;
	temp->rightChild = node;
	updateHeight(node);
	node = temp;
}

void balanceSubtree(Node *&node)
{
	if (balance(node) == -2)
	{
		//Double right rotation
		if (balance(node->leftChild) > 0)
		{
			leftRotation(node->leftChild);
		}
		rightRotation(node);
	}
	else
	{
		//Double left rotation
		if (balance(node->rightChild) < 0)
		{
			rightRotation(node->rightChild);
		}
		leftRotation(node);
	}
}

//Returns element's value by its key
std::string value(Tree *tree, const std::string key)
{
	if (isEmpty(tree))
	{
		return "";
	}
	Node *temp = tree->root;
	while ((temp != nullptr) && (temp->key != key))
	{
		temp = ((key > temp->key) ? temp->rightChild : temp->leftChild);
	}
	return ((temp != nullptr) ? temp->value : "");
}

void addToSubtree(Node *&node, Node *previous, const std::string key, const std::string newValue)
{
	if (node == nullptr)
	{
		if (key < previous->key)
		{
			previous->leftChild = new Node{ key, newValue, 1, nullptr, nullptr };
		}
		else
		{
			previous->rightChild = new Node{ key, newValue, 1, nullptr, nullptr };
		}
		return;
	}
	if (node->key == key)
	{
		node->value = newValue;
		return;
	}
	if (key < node->key)
	{
		addToSubtree(node->leftChild, node, key, newValue);
	}
	else
	{
		addToSubtree(node->rightChild, node, key, newValue);
	}
	if ((balance(node) > 1) || (balance(node) < -1))
	{
		balanceSubtree(node);
	}
	updateHeight(node);
}

//Adds an element with given key and value to the tree
void add(Tree *tree, const std::string key, const std::string newValue)
{
	if (isEmpty(tree))
	{
		tree->root = new Node{ key, newValue, 1, nullptr, nullptr };
	}
	else
	{
		addToSubtree(tree->root, nullptr, key, newValue);
	}
}

//Copying node removal from my previous tree set solution because they're practically the same

std::pair<std::string, std::string> minimum(Node *current)
{
	if (current->leftChild != nullptr)
	{
		return minimum(current->leftChild);
	}
	else
	{
		return { current->key, current->value };
	}
}

void deleteNode(Node *&current, const std::string key);

void deleteNoChldren(Node *&target)
{
	Node *temp = target;
	target = nullptr;
	delete temp;
}

void deleteOneChild(Node *target)
{
	Node *newTarget = (target->leftChild != nullptr ? target->leftChild : target->rightChild);
	target->key = newTarget->key;
	target->height = newTarget->height;
	target->value = newTarget->value;
	target->leftChild = newTarget->leftChild;
	target->rightChild = newTarget->rightChild;
	delete newTarget;
}

void deleteTwoChildren(Node *&target)
{
	const std::pair<std::string, std::string> nextPair = minimum(target->rightChild);
	deleteNode(target, nextPair.first);
	target->key = nextPair.first;
	target->value = nextPair.second;
}

void deleteNode(Node *&current, const std::string key)
{
	if (current->key < key)
	{
		deleteNode(current->rightChild, key);
	}
	else if (current->key > key)
	{
		deleteNode(current->leftChild, key);
	}
	else
	{
		if ((current->leftChild == nullptr) && (current->rightChild == nullptr))
		{
			deleteNoChldren(current);
		}
		else if ((current->leftChild != nullptr) && (current->rightChild != nullptr))
		{
			deleteTwoChildren(current);
		}
		else
		{
			deleteOneChild(current);
		}
		return;
	}
	if ((balance(current) > 1) || (balance(current) < -1))
	{
		balanceSubtree(current);
	}
	updateHeight(current);
}

//Removes a value from the set
bool remove(Tree *tree, const std::string key)
{
	if (!exists(tree, key))
	{
		return false;
	}
	deleteNode(tree->root, key);
	return true;
}

void deleteSubtree(Node *node)
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