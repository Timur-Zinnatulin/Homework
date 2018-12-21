#include <iostream>
#include <vector>
#include <fstream>

using namespace std;

bool isAccessible(const int vertice)
{
	return false;
}

int main()
{
	int vertices = 0;
	int edges = 0;
	std::ifstream fin("input.txt");
	fin >> vertices >> edges;
	vector<vector<int>> graph(vertices, vector<int>(edges));
	for (int i = 0; i < vertices; ++i)
	{
		for (int j = 0; j < edges; ++j)
		{
			fin >> graph[i][j];
		}
	}
	for (int i = 0; i < vertices; ++i)
	{
		if (isAccessible(i))
		{
			cout << "Vertice " << i + 1 << " is accessible.\n";
		}
	}
	return 0;
}
