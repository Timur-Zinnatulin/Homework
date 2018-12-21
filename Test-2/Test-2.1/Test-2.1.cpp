#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <vector>
#include <fstream>
#include <algorithm>

using namespace std;

bool testingRoutine()
{
	ifstream testFin("test.txt");
	int rows = 0;
	int columns = 0;
	testFin >> rows >> columns;
	vector<vector<int>> matrix(rows, vector<int>(columns));
	for (int i = 0; i < rows; ++i)
	{
		for (int j = 0; j < columns; ++j)
		{
			testFin >> matrix[i][j];
		}
	}
	testFin.close();
	vector<pair<int, int>> testFirstRow;
	for (int j = 0; j < columns; ++j)
	{
		testFirstRow.push_back({ matrix[0][j], j });
	}
	sort(testFirstRow.begin(), testFirstRow.end());
	for (int i = 0; i < columns - 1; ++i)
	{
		if (testFirstRow[i].first > testFirstRow[i + 1].first)
		{
			return false;
		}
	}
	return true;
}

int main()
{
	if (testingRoutine())
	{
		cout << "Testing complete!\n\n";
	}
	else
	{
		cout << "Testing failed. :(";
		return 1;
	}
	ifstream fin("f.txt");
	int rows = 0;
	int columns = 0;
	fin >> rows >> columns;
	vector<vector<int>> matrix(rows, vector<int>(columns));
	for (int i = 0; i < rows; ++i)
	{
		for (int j = 0; j < columns; ++j)
		{
			fin >> matrix[i][j];
		}
	}
	fin.close();
	vector<pair<int, int>> firstRow;
	for (int j = 0; j < columns; ++j)
	{
		firstRow.push_back({ matrix[0][j], j });
	}
	sort(firstRow.begin(), firstRow.end());
	vector<vector<int>> sortedMatrix(rows, vector<int>(columns));
	for (int j = 0; j < columns; ++j)
	{
		for (int i = 0; i < rows; ++i)
		{
			sortedMatrix[i][j] = matrix[i][firstRow[j].second];
		}
	}
	for (int i = 0; i < rows; ++i)
	{
		for (int j = 0; j < columns; ++j)
		{
			cout << sortedMatrix[i][j] << " ";
		}
		cout << endl;
	}
	return 0;
}