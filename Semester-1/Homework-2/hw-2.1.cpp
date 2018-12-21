#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif

#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int getIndex()
{
	int input = 0;
	scanf("%d", &input);
	return input;
}

int youAre(int aBadBoy)												//Ибо нечего вводить большие индексы. Очередная проверочка, так сказать
{
	if (aBadBoy == 69)
	{
		printf("You may have to read the recommendations to this program\n");
		printf("Do not enter any number over 40. Try again please :)\n");
	}
	if (aBadBoy == 70)
	{
		printf("I'm not trying to talk down to you, but PLEASE read the recommendations CAREFULLY!\n");
		printf("Numbers over 40 are PROHIBITED. Got it? Then please, show us all how quickly you have learned it.\n");
	}
	if (aBadBoy == 71)
	{
		printf("Are you serious?? This is the last time you will ever get some guidance from this program.\n");
		printf("For those who have missed the memo: ONLY NATURAL NUMBERS NOT GREATER THAN F-O-R-T-Y.\n");
		printf("If you are here just to goof around, I've got news for ya.\nThis program will not do anything unless you enter valid input. Have fun.\n");
	}
	return getIndex();
}

int recursoryFibonacci(int fibonacciIndex)
{
	switch (fibonacciIndex)
	{
		case 1:
			return 1;
		case 2:
			return 1;
		default:
			return recursoryFibonacci(fibonacciIndex - 1) + recursoryFibonacci(fibonacciIndex - 2);
	}
}

int recurrentFibonacci(int fibIndex)
{
	int fibonacciNMinusOne = 1,
		fibonacciNMinusTwo = 1;
	for (int i = 0; i <= fibIndex; ++i)
	{
		if (i > 2)
		{
			int swapFibonacci = fibonacciNMinusOne;
			fibonacciNMinusOne += fibonacciNMinusTwo;
			fibonacciNMinusTwo = swapFibonacci;
		}
	}
	return fibonacciNMinusOne;
}

void debugRoutine()
{
	printf("Pre-launch testing protocol initiated:\n");
	srand(time(nullptr));
	const int numberOfIterations = 40;
	int amountOfFailures = 0;
	for (int i = 1; i <= numberOfIterations; ++i)
	{
		if (recursoryFibonacci(i) != recurrentFibonacci(i))
		{
			printf("ERROR! Test №%d failed. Fibonacci index was %d\n", i + 1, i);
			++amountOfFailures;
		}
		if (i == numberOfIterations / 4)
		{
			printf("25%% complete...\n");
		}
		if (i == numberOfIterations / 2)
		{
			printf("50%% complete...\n");
		}
		if (i == numberOfIterations / 4 * 3)
		{
			printf("75%% complete...\n");
		}
	}
	const int trivialTestIndex = 5;
	const int trivialTest = 5;
	if (recursoryFibonacci(trivialTestIndex) == recurrentFibonacci(trivialTestIndex) && recurrentFibonacci(trivialTestIndex) == trivialTest)
	{
		printf("Trivial test complete, test index was %d...\n", trivialTestIndex);
	}
	printf("Routine complete! Total errors: %d\n\n", amountOfFailures);
}

void entryOutput()
{
	printf("BRIEFLY: Fibonacci numbers 1 and 2 are equal to 1. And PLEASE do not try to enter indexes over 40.\n");
	printf("Please enter the index of wanted Fibonacci number and this program shall calculate it recursively:\n");
}

int main()
{
	debugRoutine();													//I hope this much is enough for testing needs
	entryOutput();
	int fibonacciIndex = getIndex();
	int aBadBoy = 69;
	while(fibonacciIndex > 40)
	{
		fibonacciIndex = youAre(aBadBoy);
		aBadBoy++;
	}
	printf("%d\n__________________________\nAs we can clearly see, recursion is not the best way to calculate Fibonacci numbers(for big numbers of course)\n",
		recursoryFibonacci(fibonacciIndex));
	printf("Let us try calculate it recurrently and see the difference!\n");
	printf("%d\n__________________________\nMuch better!", recurrentFibonacci(fibonacciIndex));
	return 0;
}
