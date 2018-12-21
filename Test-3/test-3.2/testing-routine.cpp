#include "testing-routine.h"
#include "priority-queue.h"

//Pre-run testing function
bool testingRoutine()
{
	auto testQueue = createQueue();
	const int numberOfElements = 10;
	for (int i = 0; i < numberOfElements; ++i)
	{
		enqueue(testQueue, i, i);
	}
	if (isEmpty(testQueue))
	{
		deleteQueue(testQueue);
		return false;
	}
	for (int i = numberOfElements - 1; i >= 0; --i)
	{
		int topElement = dequeue(testQueue);
		if (topElement != i)
		{
			deleteQueue(testQueue);
			return false;
		}
	}
	if (!isEmpty(testQueue))
	{
		deleteQueue(testQueue);
		return false;
	}
	deleteQueue(testQueue);
	return true;
}