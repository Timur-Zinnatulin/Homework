#include <iostream>
#include <fstream>
#include "graph.h"

using namespace std;

int main()
{
	ifstream fin("input.txt");
	cout << "Reading graph from input.txt...\n";
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
		addEdge(graph, from - 1, to - 1, length);
	}
	auto minGraph = minimumSpanningTree(graph);
	for (int i = 0; i < amountOfCities; ++i)
	{
		printEdges(minGraph, i);
	}
	return 0;
}
