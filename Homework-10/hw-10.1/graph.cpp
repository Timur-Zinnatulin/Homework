#include "graph.h"
#include <fstream>
#include <vector>

struct Edge
{

};

struct Graph
{
	std::vector<std::vector<int> > edges;
	std::vector<int> vertices;
};

//Fills graph with information
void fillGraph(std::ifstream &fin, Graph &graph)
{
	int citiesAmount = 0;
	fin >> citiesAmount;
	graph.vertices.resize(citiesAmount);
	int edgesAmount = 0;
	fin >> edgesAmount;
	graph.edges.resize(citiesAmount);
	for (int i = 0; i < citiesAmount; ++i)
	{
		graph.edges[i].resize(citiesAmount);
	}
	for (int i = 0; i < edgesAmount; ++i)
	{
		int from = 0;
		int to = 0;
		int len = 0;
		fin >> from >> to >> len;
		graph.edges[from][to] = len;
		graph.edges[to][from] = len;
	}
	int capitalsAmount = 0;
	fin >> capitalsAmount;
	for (int i = 0; i < capitalsAmount; ++i)
	{
		int capital = 0;
		fin >> capital;
		graph.vertices[--capital] = i;
	}
}

//Checks if there are cities to consume
bool areCitiesLeft(Graph graph)
{
	for (int i = 0; i < graph.vertices.size(); ++i)
	{
		if (graph.vertices[i] == 0)
		{
			return false;
		}
	}
	return true;
}

//Finds the next city for a state to consume
int findNextVertex(Graph graph, int state)
{
	std::pair<int, int> nextCity = { 0, 0 };
	for (int i = 0; i < graph.vertices.size(); ++i)
	{
		if (graph.vertices[i] == state)
		{
			for (int j = 0; j < graph.edges[i].size(); ++j)
			{
				if ((graph.edges[i][j] > 0) && ((graph.edges[i][j] < nextCity.second) || (nextCity.second == 0)))
				{
					if (graph.vertices[j] == 0)
					{
						nextCity = { j, graph.edges[i][j] };
					}
				}
			}
		}
	}
	return nextCity.first;
}

//Performs one consumption cycle loop
void consumptionCycle(Graph graph, int capitalsAmount)
{
	for (int i = 0; i < capitalsAmount; ++i)
	{
		int newCity = findNextVertex(graph, i);
		graph.vertices[newCity] = i;
	}
}