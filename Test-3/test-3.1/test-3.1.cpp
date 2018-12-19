#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

int main()
{
	vector<int> data;
	int input = -1;
	while (input != 0)
	{
		cin >> input;
		if (input != 0)
		{
			data.push_back(input);
		}
	}
	sort(data.begin(), data.end());
	int i = 0;
	while (i < data.size())
	{
		int current = data[i];
		int count = 0;
		while ((i < data.size()) && (data[i] == current))
		{
			++count;
			++i;
		}
		cout << current << " was entered " << count << " time(s).\n";
	}
	return 0;
}
