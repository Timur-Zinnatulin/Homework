#pragma once

struct PriorityQueue;

//Creates a new queue
PriorityQueue *createQueue();

//Checks if the queue is empty
bool isEmpty(PriorityQueue *queue);

//Inserts a value into the priority queue
void enqueue(PriorityQueue *queue, int key, int value);

//Returns the top priority value
int dequeue(PriorityQueue *queue);

//Deletes the queue
void deleteQueue(PriorityQueue *queue);