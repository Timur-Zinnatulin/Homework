#pragma once

#include <stdio.h>
#include <time.h>
#include <stdlib.h>

void swap(int &a, int &b);												//Simple swap function
void insertionSort(int *arrayOfInts, int leftBorder, int rightBorder);	//Function that performs insertion sort in an array in given borders
int arrayPartition(int *arrayOfInts, int leftBorder, int rightBorder);	//Function that divides an array into two for further sorting
void quickSort(int *arrayOfInts, int leftBorder, int rightBorder);		//Quicksort function that makes everything work
