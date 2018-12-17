#include "hash-table.h"
#include "list.h"
#include <vector>
#include <string>
#include <algorithm>

struct HashTable
{
	int size = 0;
	std::vector<List*> buckets;
};

//Creates new hash table
HashTable *newTable()
{
	const int amountOfBuckets = 100;
	HashTable *newTable = new HashTable;
	newTable->buckets.resize(amountOfBuckets);
	for (List *&temp : newTable->buckets)
	{
		temp = createNewList();
	}
	return newTable;
}

//Returns load factor of hash table
float hashLoad(HashTable *table)
{
	return (float)table->size / (float)table->buckets.size();
}

//Returns average length of a word
float avgLength(const HashTable *table)
{
	int sum = 0;
	int amount = 0;
	for (List *temp : table->buckets)
	{
		sum += listSize(temp);
		++amount;
	}
	if (amount == 0)
	{
		return 0;
	}
	return (float)sum / (float)amount;
}


unsigned long long hashFunction(const std::string word)
{
	unsigned long long primeNumber = 73;
	unsigned long long sum = 0;
	for (int i = 0; i < word.size; ++i)
	{
		sum += primeNumber * word[i];
		primeNumber *= 73;
	}
	return sum;
}

//Returns the max length of list in hash table
int maxBucket(HashTable *table)
{
	int answer = 0;
	for (int i = 0; i < table->buckets.size(); ++i)
	{
		answer = std::max(answer, listSize(table->buckets[i]));
	}
	return answer;
}

//Finds out if the word is in the hash table
bool wordExists(HashTable *table, const std::string word)
{
	const int wordHash = hashFunction(word) % table->buckets.size();
	Node *wordNode = find(table->buckets[wordHash], word);
	return (wordNode != nullptr);
}

//Returns the amount of uses of the word
int amountOfWord(HashTable *table, const std::string word)
{
	const int wordHash = hashFunction(word) % table->buckets.size();
	Node *wordNode = find(table->buckets[wordHash], word);
	return (wordNode == nullptr ? 0 : amount(wordNode));
}

void rehash(Node *node, const HashTable *table)
{
	const int hash = hashFunction(word(node)) % table->buckets.size();
	add(table->buckets[hash], word(node), amount(node));
	changeHashFlag(node, true);
}

void expandTable(HashTable *table)
{
	const int oldSize = table->buckets.size();
	table->buckets.resize(table->buckets.size() * 2);
	for (int i = oldSize; i < table->buckets.size(); ++i)
	{
		table->buckets[i] = createNewList();
	}
	for (int i = 0; i < oldSize; ++i)
	{
		Node *tempNode = start(table->buckets[i]);
		while (start != nullptr)
		{
			if (!isRehashed(tempNode))
			{
				rehash(tempNode, table);
				Node *deleted = tempNode;
				tempNode = next(tempNode);
				remove(table->buckets[i], deleted);
			}
			else
			{
				changeHashFlag(tempNode, false);
			}
		}
	}
}

//Adds a word into the hash table
void addWord(HashTable *table, const std::string word)
{
	if (hashLoad(table) > 1.0)
	{
		expandTable(table);
	}
	const int hash = hashFunction(word) % table->buckets.size();
	Node *wordNode = find(table->buckets[hash], word);
	if (wordNode != nullptr)
	{
		addExisting(wordNode);
	}
	else
	{
		add(table->buckets[hash], word, 1);
		++table->size;
	}
}

//Deletes the table
void deleteTable(HashTable *table)
{
	for (List *temp : table->buckets)
	{
		deleteList(temp);
	}
	delete table;
}
