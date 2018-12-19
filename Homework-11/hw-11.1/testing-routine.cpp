#include "kmp-algo.h"
#include "testing-routine.h"
#include <fstream>
#include <string>

//Pre-run testing function 
bool testingRoutine()
{
	std::ifstream testFile("test.txt");
	const auto testString = "bee";
	const int actualPosition = 60;
	int answer = substringPosition(testFile, testString);
	testFile.close();
	return (answer == actualPosition);
}