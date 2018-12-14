#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

int main()
{
	int vertices = 0;
	int paths = 0;
	cout << "Enter the amount of vertices and amount of paths.\n";
	cin >> vertices >> paths;
	vector<vector<int> > graph(vertices, vector<int>(vertices));
	for (int i = 0; i < paths; ++i)
	{
		int a = 0, b = 0;
		cin >> a >> b;
		graph[a - 1][b - 1] = 1;
		graph[b - 1][a - 1] = -1;
	}
	for (int k = 0; k < vertices; ++k)
	{
		for (int i = 0; i < vertices; ++i)
		{
			for (int j = 0; j < vertices; ++k)
			{
				graph[i][j] = min(graph[i][j], graph[i][k] + graph[k][j]);
			}
		}
	}
	for (int i = 0; i < vertices; ++i)
	{
		bool ifAccessible = false;
		for (int j = 0; i < vertices; ++j)
		{
			if (i != j && graph[i][j] == 0)
			{
				ifAccessible = false;
			}
		}
		if (ifAccessible)
		{
			cout << "Vertice " << i + 1 << " is accessible.\n";
		}
	}
	return 0;
}
