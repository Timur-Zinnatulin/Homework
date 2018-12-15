#include "set.h"
#include <vector>

struct SetElement
{
	int value = 0;
	SetElement *parent = nullptr;
	SetElement *leftChild = nullptr;
	SetElement *rightChild = nullptr;
};

struct Set
{
	SetElement *root = nullptr;
};

//Checks if the set is empty
bool isEmpty(Set *set)
{
	return (set->root == nullptr);
}

//Creates a new set
Set *createNewSet()
{
	return new Set{};
}

//Checks if the element exists in a set
bool exists(Set *set, const int value)
{
	if (isEmpty(set))
	{
		return false;
	}
	auto temp = set->root;
	while ((temp != nullptr) && (temp->value != value))
	{
		if (temp->value > value)
		{
			temp = temp->leftChild;
		}
		else
		{
			temp = temp->rightChild;
		}
	}
	return temp != nullptr;
}

//Adds a new value into the set
bool add(Set *set, const int value)
{
	if (exists(set, value))
	{
		return false;
	}
	if (isEmpty(set))
	{
		set->root = new SetElement{ value, nullptr, nullptr, nullptr };
		return true;
	}
	auto newParent = set->root;
	bool isRight = (newParent->value < value);
	while (((isRight) && (newParent->rightChild != nullptr)) || ((!isRight) && (newParent->leftChild != nullptr)))
	{
		if (isRight)
		{
			newParent = newParent->rightChild;
		}
		else
		{
			newParent = newParent->leftChild;
		}
		isRight = (newParent->value < value);
	}
	if (isRight)
	{
		newParent->rightChild = new SetElement{ value, newParent, nullptr, nullptr };
	}
	else
	{
		newParent->leftChild = new SetElement{ value, newParent, nullptr, nullptr };
	}
	return true;
}

int minimum(SetElement *current)
{
	if (current->leftChild != nullptr)
	{
		return minimum(current->leftChild);
	}
	else
	{
		return current->value;
	}
}

void deleteNode(SetElement *&current, const int value);

void deleteNoChldren(SetElement *&target)
{
	SetElement *temp = target;
	target = nullptr;
	delete temp;
}

void deleteOneChild(SetElement *target)
{
	SetElement *newTarget = (target->leftChild != nullptr ? target->leftChild : target->rightChild);
	target->value = newTarget->value;
	target->leftChild = newTarget->leftChild;
	target->rightChild = newTarget->rightChild;
	delete newTarget;
}

void deleteTwoChildren(SetElement *&target)
{
	const int nextValue = minimum(target->rightChild);
	deleteNode(target, nextValue);
	target->value = nextValue;
}

void deleteNode(SetElement *&current, const int value)
{
	if (current->value < value)
	{
		deleteNode(current->rightChild, value);
	}
	else if (current->value > value)
	{
		deleteNode(current->leftChild, value);
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
	}
}

//Removes a value from the set
bool remove(Set *set, const int value)
{
	if (!exists(set, value))
	{
		return false;
	}
	deleteNode(set->root, value);
	return true;
}

void goingLeft(SetElement *current, std::vector<int> &values)
{
	if (current->leftChild != nullptr)
	{
		goingLeft(current->leftChild, values);
	}
	values.push_back(current->value);
	if (current->rightChild != nullptr)
	{
		goingLeft(current->rightChild, values);
	}
}

void goingRight(SetElement *current, std::vector<int> &values)
{
	if (current->rightChild != nullptr)
	{
		goingRight(current->rightChild, values);
	}
	values.push_back(current->value);
	if (current->leftChild != nullptr)
	{
		goingRight(current->leftChild, values);
	}
}

//Returns a vector of values in ascending order
std::vector<int> ascendingOrder(Set *set)
{
	std::vector<int> values;
	if (isEmpty(set))
	{
		return values;
	}
	goingLeft(set->root, values);
	return values;
}

//Returns a vector of values in descending order
std::vector<int> descendingOrder(Set *set)
{
	std::vector<int> values;
	if (isEmpty(set))
	{
		return values;
	}
	goingRight(set->root, values);
	return values;
}

void deleteSubtree(SetElement *current)
{
	if (current->leftChild != nullptr)
	{
		deleteSubtree(current->leftChild);
	}
	if (current->rightChild != nullptr)
	{
		deleteSubtree(current->rightChild);
	}
	delete current;
}

//Deletes the set
void deleteSet(Set *set)
{
	if (!isEmpty(set))
	{
		deleteSubtree(set->root);
	}
	delete set;
}