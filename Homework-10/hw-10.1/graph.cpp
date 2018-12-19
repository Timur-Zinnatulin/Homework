#include "graph.h"
#include <fstream>
#include <vector>
#include <map>

#define BIG INT_MAX
#define neighborCity graph->vertices[i - 1].neighbors[j]

struct Vertex
{
	int state = -1;
	std::vector<std::pair<int, int>> neighbors;
};

struct Graph
{
	std::vector<Vertex> vertices;
};

//Creates a new graph with assigned amount of cities
Graph *createNewGraph(const int citiesAmount)
{
	auto graph = new Graph;
	graph->vertices.resize(citiesAmount);
	return graph;
}

//Delets the graph
void deleteGraph(Graph *graph)
{
	for (int i = 0; i < graph->vertices.size(); ++i)
	{
		graph->vertices[i].neighbors.clear();
	}
	graph->vertices.clear();
	delete graph;
}

//Adds an edge between cities in a graph
void addEdge(Graph *graph, const int city1, const int city2, const int length)
{
	graph->vertices[city1 - 1].neighbors.push_back({ city2 - 1, length });
	graph->vertices[city2 - 1].neighbors.push_back({ city1 - 1, length });
}

//Returns the state of city
int stateOfCity(Graph *graph, const int city)
{
	return (graph->vertices[city - 1].state);
}

//Changes the state of city
void assignState(Graph *graph, const int city, const int newState)
{
	graph->vertices[city - 1].state = newState;
}

//Captures a city into a state
bool captureCity(Graph *graph, const int state)
{
	int minLength = BIG;
	int minCity = 0;
	for (int i = 1; i <= graph->vertices.size(); ++i)
	{
		if (stateOfCity(graph, i) == state)
		{
			for (int j = 0; j < graph->vertices[i - 1].neighbors.size(); ++j)
			{
				if ((stateOfCity(graph, neighborCity.first + 1) == -1) && (neighborCity.second < minLength))
				{
					minLength = neighborCity.second;
					minCity = neighborCity.first;
				}
			}
		}
	}
	if (minLength == BIG)
	{
		return false;
	}
	assignState(graph, minCity + 1, state);
	return true;
}

