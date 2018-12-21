#pragma once

#include <fstream>

struct Graph;

//Creates a new graph with assigned amount of cities
Graph *createNewGraph(const int verticesAmount);

//Delets the graph
void deleteGraph(Graph *graph);

//Adds an edge between cities in a graph
void addEdge(Graph *graph, const int vertex1, const int vertex2, const int length);

//Returns the length of an edge between two vertices
int edgeLength(Graph *graph, const int vertex1, const int vertex2);

//Prints the edges of a graph
void printEdges(Graph *graph, const int vertex);

//Prim algorithm for creating a MST from given graph
Graph *minimumSpanningTree(Graph *graph);

//Reads the input from the file and automatically creates a graph out of it
void inputGraph(std::ifstream &fin, Graph *graph, const int amountOfVertices);

//Returns the amount of vertices
int verticesAmount(Graph *graph);

//Returns the amount of edges
int edgesAmount(Graph *graph);