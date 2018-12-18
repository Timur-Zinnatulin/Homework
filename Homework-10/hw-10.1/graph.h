#pragma once

#include <vector>
#include <fstream>

struct Graph;

//Fills graph with information
void fillGraph(std::ifstream &fin, Graph &graph);

//Checks if there are cities to consume
bool areCitiesLeft(Graph graph);

//Finds the next city for a state to consume
int findNextVertex(Graph graph, int state);

//Performs one consumption cycle loop
void consumptionCycle(Graph graph, int capitalsAmount);