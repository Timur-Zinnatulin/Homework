#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <fstream>

using namespace std;

//This program didn't feel like it needed any functions because everything here is elementary
int main()
{
	int comparedInt = 0;
	int intFromFirstFile = 0;
	ifstream fin;
	//Read the number we will be comparing to
	fin.open("g.txt");
	fin >> comparedInt;
	fin.close();
	//Ready to read an array of integers from the first file
	fin.open("f.txt");
	ofstream fout;
	//Created a new file and prepared to write our numbers there
	fout.open("h.txt");
	while (fin >> intFromFirstFile)
	{
		if (intFromFirstFile < comparedInt)
		{
			fout << intFromFirstFile << " ";
		}
	}
	fin.close();
	fout.close();
	return 0;
}
