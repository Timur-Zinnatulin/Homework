#include <iostream>
#include "cyclic-list.h"

int main()
{
	int n, m;
	std::cin >> n >> m;
	CyclicList *list = createNewList();
	generateCycle(list, n);
	std::cout << sicariiCycle(list, m) << "\n";
	deleteList(list);
	return 0;
}

