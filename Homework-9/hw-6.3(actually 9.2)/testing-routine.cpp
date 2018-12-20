#include "testing-routine.h"
#include "shunting-yard.h"
#include <string>

//Pre-run testing program
bool testingRoutine()
{
	const std::string test1 = "(1 + 1) * 2";
	const std::string test2 = "2 + 2 * 2";
	const std::string answer1 = "1 1 + 2 * ";
	const std::string answer2 = "2 2 2 * + ";
	if ((shuntingYard(test1).compare(answer1) == 0) && (shuntingYard(test2).compare(answer2) == 0))
	{
		return true;
	}
	return false;
}