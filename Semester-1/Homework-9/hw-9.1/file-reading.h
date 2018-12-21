#pragma once

#include "hash-table.h"
#include <fstream>
#include <vector>
#include <string>

//Reads file and returns a non-repeating vector of words
std::vector<std::string> readFile(std::ifstream &fin, HashTable *&table);