#pragma once

//Size of our bit number 
const int bitSize = 32;

//Tranforms a decimal number to binary
void transformToBinary(int decimalNumber, bool *binaryNumber);

//Prints a number in binary form
void printBinary(bool *binaryNumber);

//Calculates the sum of two binary integers in binary
void binarySum(bool *binary1, bool *binary2, bool *result);

//Transforms a binary number to decimal
int transformToDecimal(bool *binaryNumber);