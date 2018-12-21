#include "graph.h"
#include "testing-routine.h"
#include <fstream>
#include <iostream>

//Pre-run testing function
bool testingRoutine()
{
	std::ifstream fin("test.txt");
	int testAmountOfCities = 0;
	fin >> testAmountOfCities;
	auto testGraph = createNewGraph(testAmountOfCities);
	inputGraph(fin, testGraph, testAmountOfCities);
	fin.close();
	auto testMinGraph = minimumSpanningTree(testGraph);
	const int vertices = 8;
	const int edges = 7;
	if ((verticesAmount(testMinGraph) == vertices) && (edgesAmount(testMinGraph) == edges))
	{
		deleteGraph(testMinGraph);
		deleteGraph(testGraph);
		return true;
	}
	deleteGraph(testMinGraph);
	deleteGraph(testGraph);
	return false;
}