#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

int main()
{
	int rowSize = 0;
	int columnSize = 0;
	cout << "Enter the number of rows and number of columns.\n";
	cin >> rowSize >> columnSize;
	vector<vector<int>> matrix(rowSize, vector<int>(columnSize));

	vector<int> minInRow(rowSize);
	int previous = 0;
	bool ifAllEqual = true;
	for (int i = 0; i < rowSize; ++i)
	{
		int min = 0;
		int minColumn = 0;
		cin >> min;
		if (i == 0)
		{
			previous = min;
		}
		matrix[i][0] = min;
		for (int j = 1; j < columnSize; ++j)
		{
			cin >> matrix[i][j];
			if (previous != matrix[i][j])
			{
				ifAllEqual = false;
			}
			if (matrix[i][j] < min)
			{
				min = matrix[i][j];
				minColumn = j;
			}
			previous = matrix[i][j];
		}
		minInRow[i] = minColumn;
	}

	vector<int> maxInColumn(columnSize);
	for (int j = 0; j < columnSize; ++j)
	{
		int max = matrix[0][j];
		int maxRow = 0;
		for (int i = 0; i < rowSize; ++i)
		{
			if (matrix[i][j] > max)
			{
				max = matrix[i][j];
				maxRow = i;
			}
		}
		maxInColumn[j] = maxRow;
	}

	if (ifAllEqual)
	{
		cout << "All points are saddle points!\n";
		return 0;
	}

	for (int i = 0; i < rowSize; ++i)
	{
		if (maxInColumn[minInRow[i]] == i)
		{
			cout << i << " " << minInRow[i] << "is a saddle point.\n";
		}
	}
	return 0;
}
