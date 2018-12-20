#include "testing-routine.h"
#include "cyclic-list.h"

//Pre-run testing program
bool testingRoutine()
{
	const int numberOfTests = 5;
	bool ifCorrect = true;
	const int testCircleSize[numberOfTests] = {1, 2, 5, 30, 41};
	const int testModulo[numberOfTests] = { 2, 1, 3, 5, 3 };
	const int testAnswers[numberOfTests] = {1, 2, 4, 3, 31};
	CyclicList *testList[5]{};
	for (int i = 0; i < numberOfTests; ++i)
	{
		testList[i] = createNewList();
		generateCycle(testList[i], testCircleSize[i]);
		if (sicariiCycle(testList[i], testModulo[i]) != testAnswers[i])
		{
			ifCorrect = false;
		}
		deleteList(testList[i]);
	}
	return ifCorrect;
}