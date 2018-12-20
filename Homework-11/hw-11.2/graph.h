#pragma once

struct Graph;

//Creates a new graph with assigned amount of cities
Graph *createNewGraph(const int verticesAmount);

//Delets the graph
void deleteGraph(Graph *graph);

//Adds an edge between cities in a graph
void addEdge(Graph *graph, const int vertex1, const int vertex2, const int length);

//Returns the length of an edge between two vertices
int edgeLength(Graph *graph, const int vertex1, const int vertex2);

void printEdges(Graph *graph, const int vertex);

//Prim algorithm for creating a MST from given graph
Graph *minimumSpanningTree(Graph *graph);