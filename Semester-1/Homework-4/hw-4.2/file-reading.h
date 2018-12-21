#pragma once
#include <stdio.h>

//Reads a single number from a file
bool scanSize(FILE* inputFile, int &arraySize);

//Reads an array of integers from a file
bool scanArray(FILE* inputFile, int *arrayOfInts, int arraySize);