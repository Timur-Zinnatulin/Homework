#include <iostream>
#include <fstream>
#include "tree.h"
#include "testing-routine.h"

using namespace std;

int main()
{
	if (testingRoutine())
	{
		cout << "Testing complete.\n";
	}
	else
	{
		cout << "Testing failed.\n";
		return 0;
	}
	ifstream fin;
	fin.open("expression.txt");
	cout << "Reading the expression...\n";
	Tree *expression = createTree(fin);
	fin.close();
	cout << "Expression parsed.\n";
	cout << "The expression looks like this:\n";
	printTree(expression);
	cout << "If evaluated, the expression is equal to " << treeEvaluation(expression) << ".\n";
	deleteTree(expression);
	cout << "Program complete. Exiting...\n";
}
