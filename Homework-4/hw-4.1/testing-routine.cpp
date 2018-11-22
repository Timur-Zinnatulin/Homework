#include "binary-operations.h"
#include <stdio.h>
#include <locale.h>
#include <stdlib.h>
#include <time.h>

//Functions that checks if sums are calculated correctly
bool checkSumCorrectness(int decimal1, int decimal2)
{
	bool binary1[bitSize]{ 0 };
	bool binary2[bitSize]{ 0 };
	transformToBinary(decimal1, binary1);
	transformToBinary(decimal2, binary2);
	
	bool binaryResult[bitSize]{ 0 };
	binarySum(binary1, binary2, binaryResult);
	return (transformToDecimal(binaryResult) == decimal1 + decimal2);
}

//Program test function
void testingRoutine()
{
	setlocale(LC_ALL, "Russian");
	printf("реярхпнбнвмши опнрнйнк гюосыем\n");
	srand(time(nullptr));
	const int numberOfTests = 1000;
	int numberOfErrors = 0;
	for (int i = 0; i < numberOfTests; ++i)
	{
		//Ints from -15000 to 15000 are being checked, but we shall also do a minmax test
		int testDecimal1 = rand() % 30001 - 15000;
		int testDecimal2 = rand() % 30001 - 15000;
		if (!checkSumCorrectness(testDecimal1, testDecimal2))
		{
			++numberOfErrors;
		}
		if (i == numberOfTests / 4)
		{
			printf("реяр опнидем мю 25%%\n");
		}
		if (i == numberOfTests / 2)
		{
			printf("реяр опнидем мю 50%%\n");
		}
		if (i == 3 * numberOfTests / 4)
		{
			printf("реяр опнидем мю 75%%\n");
		}
	}
	//Stress test with 2^31 - 1 and -2^31 + 1
	if (!checkSumCorrectness(2147483647, -2147483647))
	{
		++numberOfErrors;
	}

	printf("реяр гюбепьем. ньханй мюидемн: %d\n", numberOfErrors);
}