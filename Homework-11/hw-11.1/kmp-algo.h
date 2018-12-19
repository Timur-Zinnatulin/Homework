#pragma once

#include <fstream>
#include <string>

//Knuth-Morris-Pratt algorithm that returns the first position where substring is met
int substringPosition(std::ifstream &fin, const std::string substring);