#pragma once

#include <vector>
#include <string>

struct HashTable;

//Creates new hash table
HashTable *newTable();

//Returns load factor of hash table
float hashLoad(HashTable *table);

//Returns average length of a word
float avgLength(const HashTable *table);

//Returns the max length of list in hash table
int maxBucket(HashTable *table);

//Finds out if the word is in the hash table
bool wordExists(HashTable *table, const std::string word);

//Returns the amount of uses of the word
int amountOfWord(HashTable *table, const std::string word);

//Adds a word into the hash table
void addWord(HashTable *table, const std::string word);

//Deletes the table
void deleteTable(HashTable *table);