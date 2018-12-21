#include <iostream>
#include <fstream>
#include <vector>
#include "graph.h"
#include "testing-routine.h"

using namespace std;

int main()
{
	if (testingRoutine())
	{
		cout << "Testing successful!\n\n";
	}
	ifstream fin("input.txt");
	cout << "Reading graph from input.txt...\n";
	int amountOfCities = 0;
	fin >> amountOfCities;
	auto graph = createNewGraph(amountOfCities);
	inputGraph(fin, graph, amountOfCities);
	fin.close();
	cout << "Graph successfully read; creating minimal spanning tree...\n";
	auto minGraph = minimumSpanningTree(graph);
	cout << "The minimal subtree graph looks like this (I'm printing all the edges in it): \n";
	for (int i = 0; i < amountOfCities; ++i)
	{
		printEdges(minGraph, i);
	}
	cout << "Program complete. Exiting...\n";
	deleteGraph(minGraph);
	deleteGraph(graph);
	return 0;
}
