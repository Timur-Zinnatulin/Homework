#include "binary-operations.h"
#include <stdio.h>

//Tranforms a decimal number to binary
void transformToBinary(int decimalNumber, bool *binaryNumber)
{
	//Our number's absolute value is less that 2^31
	//
	unsigned int compareBit = 0b01000000000000000000000000000000;
	//The first bit determines whether the number is positive or negative
	binaryNumber[0] = decimalNumber < 0;
	for (int i = 1; i < bitSize; ++i)
	{
		binaryNumber[i] = (decimalNumber & compareBit);
		compareBit = compareBit >> 1;
	}
}

//Prints a number in binary form
void printBinary(bool *binaryNumber)
{
	for (int i = 0; i < bitSize; ++i)
	{
		printf("%d", binaryNumber[i]);
	}
	printf("\n");
}

//Calculates the sum of two binary integers in binary
void binarySum(bool *binary1, bool *binary2, bool *result)
{
	bool overflowBit = 0;
	for (int i = bitSize - 1; i >= 0; --i)
	{
		switch (binary1[i] + binary2[i] + overflowBit)
		{
			case 1:
			{
				result[i] = 1;
				overflowBit = 0;
				break;
			}
			case 2:
			{
				result[i] = 0;
				overflowBit = 1;
				break;
			}
			case 3:
			{
				result[i] = 1;
				overflowBit = 1;
				break;
			}
			default:
			{
				result[i] = 0;
				overflowBit = 0;
				break;
			}
		}
	}
}

//Transforms a binary number to decimal
int transformToDecimal(bool *binaryNumber)
{
	int decimalNumber = 0;
	int exponentOfTwo = 1;
	for (int i = bitSize - 1; i >= 0; --i)
	{
		//For positive numbers we count bits with 1, for negative - with 0, because we inverted them in the process of transformation
		if (!(binaryNumber[i] & binaryNumber[0]))
		{
			decimalNumber += exponentOfTwo;
		}
		exponentOfTwo *= 2;
	}
	//The algorithm of transformation of negative numbers between binary and decimal forms 
	if (binaryNumber[0])
	{
		decimalNumber += 1;
		decimalNumber *= -1;
	}
	return decimalNumber;
}