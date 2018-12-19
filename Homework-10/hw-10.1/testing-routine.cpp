#include "testing-routine.h"
#include "graph.h"
#include <fstream>
#include <iostream>
#include <vector>

//Pre-run testing function
bool testingRoutine()
{
	std::ifstream fin("test.txt");
	int amountOfCities = 0;
	int amountOfRoads = 0;
	fin >> amountOfCities >> amountOfRoads;
	auto graph = createNewGraph(amountOfCities);
	
	for (int i = 0; i < amountOfRoads; ++i)
	{
		int from = 0;
		int to = 0;
		int length = 0;
		fin >> from >> to >> length;
		addEdge(graph, from, to, length);
	}
	int amountOfStates = 0;
	fin >> amountOfStates;
	for (int i = 0; i < amountOfStates; ++i)
	{
		int newCapital = 0;
		fin >> newCapital;
		assignState(graph, newCapital, i);
	}
	fin.close();
	std::vector<int> states = {};
	bool ifCitiesToCapture = true;
	while (ifCitiesToCapture)
	{
		ifCitiesToCapture = false;
		for (int i = 0; i < amountOfStates; ++i)
		{
			ifCitiesToCapture = captureCity(graph, i) || ifCitiesToCapture;
		}
	}
	for (int i = 1; i <= amountOfCities; ++i)
	{
		if (stateOfCity(graph, i) != (i >= 5))
		{
			deleteGraph(graph);
			return false;
		}
	}
	deleteGraph(graph);
	return true;
}