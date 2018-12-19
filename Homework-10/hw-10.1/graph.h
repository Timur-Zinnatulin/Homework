#pragma once

#include <vector>
#include <fstream>

struct Graph;

//Creates a new graph with assigned amount of cities
Graph *createNewGraph(const int citiesAmount);

//Adds an edge between cities in a graph
void addEdge(Graph *graph, const int city1, const int city2, const int length);

//Returns the state of city
int stateOfCity(Graph *graph, const int city);

//Changes the state of city
void assignState(Graph *graph, const int city, const int newState);

//Captures a city into a state
bool captureCity(Graph *graph, const int state);