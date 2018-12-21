#include <iostream>
#include <vector>
#include <fstream>

using namespace std;

void reverseDFS(vector<vector<int>> &graph, const int vertice, vector<bool> &used)
{
	for (int j = 0; j < (int)graph[vertice].size(); ++j)
	{
		if (graph[vertice][j] == -1)
		{
			int fromVertice = 0;
			while (graph[fromVertice][j] != 1)
			{
				++fromVertice;
			}
			if (!used[fromVertice])
			{
				used[vertice] = true;
				reverseDFS(graph, fromVertice, used);
			}
		}
	}
	used[vertice] = true;
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
	fin.close();
	vector<bool> used(vertices, false);
	for (int i = 0; i < vertices; ++i)
	{
		used.resize(vertices, false);
		reverseDFS(graph, i, used);
		bool ifCanReachAll = true;
		for (int j = 0; j < vertices; ++j)
		{
			if (!used[j])
			{
				ifCanReachAll = false;
				break;
			}
		}
		if (ifCanReachAll)
		{
			cout << "Vertice " << i + 1 << " is accessible from all edges.\n";
		}
	}
	return 0;
}
