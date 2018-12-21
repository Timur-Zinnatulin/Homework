#include "priority-queue.h"

struct QueueElement
{
	int key = 0;
	int value = 0;
	QueueElement *next = nullptr;
};

struct PriorityQueue
{
	QueueElement *top = nullptr;
};

//Creates a new queue
PriorityQueue *createQueue()
{
	return new PriorityQueue;
}

//Checks if the queue is empty
bool isEmpty(PriorityQueue *queue)
{
	return (queue->top == nullptr);
}

//Inserts a value into the priority queue
void enqueue(PriorityQueue *queue, int key, int value)
{
	const auto newElement = new QueueElement{ key, value, nullptr };
	if (isEmpty(queue) || (key > queue->top->key))
	{
		newElement->next = queue->top;
		queue->top = newElement;
		return;
	}
	QueueElement *last = queue->top;
	while ((last->next != nullptr) && (last->next->key >= key))
	{
		last = last->next;
	}
	if (last->next != nullptr)
	{
		newElement->next = last->next;
	}
	last->next = newElement;
}

//Returns the top priority value
int dequeue(PriorityQueue *queue)
{
	if (isEmpty(queue))
	{
		return -1;
	}
	const int topPriority = queue->top->value;
	const auto deletedTop = queue->top;
	queue->top = queue->top->next;
	delete deletedTop;
	return topPriority;
}

//Deletes the queue
void deleteQueue(PriorityQueue *queue)
{
	while (!isEmpty(queue))
	{
		const auto deletedTop = queue->top;
		queue->top = queue->top->next;
		delete deletedTop;
	}
	delete queue;
}