#include "graph.h"
#include <iostream>
#include <fstream>
#include <vector>
#include <map>

struct Vertex
{
	std::vector<std::pair<int, int>> neighbors;
	bool isInMST = false;
};

struct Graph
{
	std::vector<Vertex> vertices;
};

//Creates a new graph with assigned amount of cities
Graph *createNewGraph(const int verticesAmount)
{
	auto graph = new Graph;
	graph->vertices.resize(verticesAmount);
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

//Returns the amount of vertices
int verticesAmount(Graph *graph)
{
	return graph->vertices.size();
}

//Returns the amount of edges
int edgesAmount(Graph *graph)
{
	int answer = 0;
	for (int i = 0; i < graph->vertices.size(); ++i)
	{
		answer += graph->vertices[i].neighbors.size();
	}
	return answer / 2;
}

//Reads the input from the file and automatically creates a graph out of it
void inputGraph(std::ifstream &fin, Graph *graph, const int amountOfVertices)
{
	for (int i = 0; i < amountOfVertices; ++i)
	{
		std::vector<int> inputLine(amountOfVertices);
		for (int j = 0; j < amountOfVertices; ++j)
		{
			int input = 0;
			fin >> input;
			if ((input != 0) && (i < j))
			{
				addEdge(graph, i, j, input);
			}
		}
	}
}

//Adds an edge between cities in a graph
void addEdge(Graph *graph, const int vertex1, const int vertex2, const int length)
{
	graph->vertices[vertex1].neighbors.push_back({ vertex2, length });
	graph->vertices[vertex2].neighbors.push_back({ vertex1, length });
}

//Returns the length of an edge between two vertices
int edgeLength(Graph *graph, const int vertex1, const int vertex2)
{
	for (int i = 0; i < graph->vertices[vertex1].neighbors.size(); ++i)
	{
		if (graph->vertices[vertex1].neighbors[i].first == vertex2)
		{
			return graph->vertices[vertex1].neighbors[i].second;
		}
	}
	return INT_MAX;
}

void printEdges(Graph *graph, const int vertex)
{
	for (int j = 0; j < graph->vertices[vertex].neighbors.size(); ++j)
	{
		if (!graph->vertices[graph->vertices[vertex].neighbors[j].first].isInMST)
		{
			std::cout << vertex + 1 << " " << graph->vertices[vertex].neighbors[j].first + 1 << " " << graph->vertices[vertex].neighbors[j].second << "\n";
		}
	}
	graph->vertices[vertex].isInMST = true;
}

//Prim algorithm for creating a MST from given graph
Graph *minimumSpanningTree(Graph *graph)
{
	Graph *newGraph = createNewGraph(graph->vertices.size());
	std::vector<int> minLength(graph->vertices.size(), INT_MAX);
	std::vector<int> edgeDestination(graph->vertices.size(), -1);
	minLength[0] = 0;
	for (int i = 0; i < graph->vertices.size(); ++i)
	{
		int newVertice = -1;
		for (int j = 0; j < graph->vertices.size(); ++j)
		{
			if ((!graph->vertices[j].isInMST) && ((newVertice == -1) || (minLength[j] < minLength[newVertice])))
			{
				newVertice = j;
			}
		}
		graph->vertices[newVertice].isInMST = true;
		if (edgeDestination[newVertice] != -1)
		{
			addEdge(newGraph, newVertice, edgeDestination[newVertice], minLength[newVertice]);
		}
		for (int destination = 0; destination < graph->vertices.size(); ++destination)
		{
			if (edgeLength(graph, newVertice, destination) < minLength[destination])
			{
				minLength[destination] = edgeLength(graph, newVertice, destination);
				edgeDestination[destination] = newVertice;
			}
		}
	}
	return newGraph;
}