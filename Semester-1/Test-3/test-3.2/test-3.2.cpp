#include <iostream>
#include "testing-routine.h"
#include "priority-queue.h"

using namespace std;

int main()
{
	if (testingRoutine())
	{
		cout << "TESTING SUCCESSFUL!!!\n\n";
	}
	auto queue = createQueue();
	cout << "Commands:\n";
	cout << "1 - insert value into priority queue.\n";
	cout << "2 - dequeue and print the top element.\n";
	cout << "0 - exit.\n";
	int input = -1;
	while (input != 0)
	{
		cin >> input;
		switch (input)
		{
		case 1:
		{
			cout << "Give me priority and value.\n";
			int priority = 0;
			int value = 0;
			cin >> priority >> value;
			enqueue(queue, priority, value);
			cout << "Value inserted.\n";
			break;
		}
		case 2:
		{
			int top = dequeue(queue);
			cout << "The top element is: " << top << "\n";
			break;
		}
		default:
		{
			input = 0;
			break;
		}
		}
	}
	deleteQueue(queue);
	cout << "Exiting...\n\n";
	return 0;
}
