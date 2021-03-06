#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <locale.h>
#include "binary-operations.h"
#include "testing-routine.h"

int main()
{
	testingRoutine();

	setlocale(LC_ALL, "Russian");
	int decimal1 = 0,
		decimal2 = 0;

	//Decimal numbers input
	printf("Введите первое число:\n");
	scanf("%d", &decimal1);
	printf("Введите второе число:\n");
	scanf("%d", &decimal2);

	//Transformation to binary numbers
	bool binary1[bitSize]{ 0 };
	bool binary2[bitSize]{ 0 };
	transformToBinary(decimal1, binary1);
	transformToBinary(decimal2, binary2);

	//Demonstration of binary numbers
	printf("В двоичной СС ваши числа выглядят так:\n");
	printBinary(binary1);
	printBinary(binary2);

	//Calculation and demonstration of the result
	bool binaryResult[bitSize]{ 0 };
	binarySum(binary1, binary2, binaryResult);
	printf("В двоичной СС сумма чисел выглядит так:\n");
	printBinary(binaryResult);

	//Demonstration of the result in decimal
	printf("В десятичной СС сумма чисел выглядит так:\n");
	printf("%d\n", transformToDecimal(binaryResult));

	return 0;
}
