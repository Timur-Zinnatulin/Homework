#include <iostream>
#include <fstream>
#include <vector>
#include "graph.h"

using namespace std;

int main()
{
	ifstream fin("input.txt");
	cout << "Reading graph from input.txt...\n";
	int amountOfCities = 0;
	fin >> amountOfCities;
	auto graph = createNewGraph(amountOfCities);
	for (int i = 0; i < amountOfCities; ++i)
	{
		vector<int> inputLine(amountOfCities);
		for (int j = 0; j < amountOfCities; ++j)
		{
			int input = 0;
			fin >> input;
			if ((input != 0) && (i < j))
			{
				addEdge(graph, i, j, input);
			}
		}
	}
	fin.close();
	auto minGraph = minimumSpanningTree(graph);
	for (int i = 0; i < amountOfCities; ++i)
	{
		printEdges(minGraph, i);
	}
	return 0;
}
