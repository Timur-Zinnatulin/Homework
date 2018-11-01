#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <math.h>

void welcomeOutput()
{
	printf("Welcome to the Power Script ver.1!\n");
	printf("This program works with natural numbers, so try to be rational with your input.\n");
	printf("(This means you shouldn't try to calculate 29^57 and such.)\n====================\n");
	printf("Please enter the base and the exponent of power you want to get.\n");
}

unsigned int getInputBase()
{
	unsigned int baseOfX = 0;
	printf("Base: ");
	scanf("%d", &baseOfX);
	return baseOfX;
}

unsigned int getInputExponent()
{
	unsigned int exponentOfX = 0;
	printf("Exponent: ");
	scanf("%d", &exponentOfX);
	return exponentOfX;
}

unsigned int linearPower(unsigned int baseOfX, unsigned int exponentOfX)
{
	unsigned int powerOfX = 1;
	for (int i = 0; i < exponentOfX; ++i)
	{
		powerOfX *= baseOfX;
	}
	return powerOfX;
}

unsigned int logarithmicPower(unsigned int baseOfX, unsigned int exponentOfX)
{
	unsigned int powerOfX = 1;
	if (exponentOfX == 0)
	{
		return 1;
	}
	if (exponentOfX % 2 == 1)
	{
		return logarithmicPower(baseOfX, exponentOfX - 1) * baseOfX;
	}
	if (exponentOfX % 2 == 0)
	{
		unsigned int squareRootOfX = logarithmicPower(baseOfX, exponentOfX / 2);
		return squareRootOfX * squareRootOfX;
	}
}

void testingRoutine()
{
	srand(time(nullptr));
	const int numberOfTests = 50;
	printf("TESTING PROTOCOL INITIATED\n");
	int correctAnswers = 0;
	for (int i = 0; i < numberOfTests; ++i)
	{
		unsigned int randomBase = rand() % 9 + 1,
					randomExponent = rand() % 10;
		if (logarithmicPower(randomBase, randomExponent) == linearPower(randomBase, randomExponent))
		{
				++correctAnswers;																																							//Sadly, the standard pow() returns real numbers instead of integers,
		}																																													//so using it as an answer correctness test will not be reliable in some cases that go out of bounds of double
		if (i + 1 == numberOfTests / 4)																																						//Interestingly enough, it (pow()) gives the wrong answer only with bases of 5 and 7 from what I could find myself.
		{																																													//I cannot answer why it happens so. This is weird.
			printf("25%% complete...\n");
		}
		if (i + 1 == numberOfTests / 2)
		{
			printf("50%% complete...\n");
		}
		if (i + 1 == 3 * numberOfTests / 4)
		{
			printf("75%% complete...\n");
		}
		if (linearPower(randomBase, randomExponent) != (int)pow((double)randomBase, randomExponent))
		{
			printf("With base of %d and exponent of %d the standard pow() function returns the wrong answer.\n", randomBase, randomExponent);
		}
	}
	printf("~~~~~~~~~~\nThis pow() test was just to show that I could not rely on this function. Also this was quite interesting to find out!\n~~~~~~~~~~\n");
	printf("Pre-run testing complete! Total errors: %d\n\n", numberOfTests - correctAnswers);
}

void calculateLinearly(unsigned int baseOfX, unsigned int exponentOfX)
{
	const unsigned int linearAnswer = linearPower(baseOfX, exponentOfX);
	printf("Now this program shall calculate this power in linear time.\n");
	printf("The result is %d. Could be faster, right?...\n\n", linearAnswer);
}

void calculateLogarithmically(unsigned int baseOfX, unsigned int exponentOfX)
{
	const unsigned int logarithmicAnswer = logarithmicPower(baseOfX, exponentOfX);
	printf("Of course! We can do it a lot faster!\n");
	printf("Using the correct algorithm, we get %d, which is the same!\n", logarithmicAnswer);
}
int main()
{
	testingRoutine();
	welcomeOutput();
	unsigned int baseOfX = 0,
				exponentOfX = 0;
	baseOfX = getInputBase();
	exponentOfX = getInputExponent();
	calculateLinearly(baseOfX, exponentOfX);
	calculateLogarithmically(baseOfX, exponentOfX);
	return 0;
}
