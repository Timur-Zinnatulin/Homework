#pragma once
#include <vector>

struct Set;

//Checks if the set is empty
bool isEmpty(Set *set);

//Creates a new set
Set *createNewSet();

//Checks if the element exists in a set
bool exists(Set *set, const int value);

//Adds a new value into the set
bool add(Set *set, const int value);

//Removes a value from the set
bool remove(Set *set, const int value);

//Returns a vector of values in ascending order
std::vector<int> ascendingOrder(Set *set);

//Returns a vector of values in descending order
std::vector<int> descendingOrder(Set *set);

//Deletes the set
void deleteSet(Set *set);