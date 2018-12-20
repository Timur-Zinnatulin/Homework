#include <iostream>
#include <fstream>
#include "graph.h"
#include "testing-routine.h"

using namespace std;

int main()
{
	if (testingRoutine())
	{
		cout << "Testing successful!\n";
	}
	else
	{
		cout << "Testing failed.\n";
		return 1;
	}
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
	int amountOfStates = 0;
	fin >> amountOfStates;
	for (int i = 0; i < amountOfStates; ++i)
	{
		int newCapital = 0;
		fin >> newCapital;
		assignState(graph, newCapital - 1, i);
	}
	fin.close();
	cout << "Graph successfully read.\n";
	cout << "Performing state assignment...\n";
	bool ifCitiesToCapture = true;
	while (ifCitiesToCapture)
	{
		ifCitiesToCapture = false;
		for (int i = 0; i < amountOfStates; ++i)
		{
			ifCitiesToCapture = captureCity(graph, i) || ifCitiesToCapture;
		}
	}
	cout << "All cities are assigned to states. Printing results...\n\n";
	for (int i = 0; i < amountOfCities; ++i)
	{
		cout << "City #" << i + 1 << " belongs to state #" << stateOfCity(graph, i) + 1 << "\n";
	}
	cout << "\nProgram complete. Exiting...";
	deleteGraph(graph);
	return 0;
}
