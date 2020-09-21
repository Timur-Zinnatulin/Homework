import math

EPSILON = 0.00001
A = -10
B = 2

F_STRING = "x * sin(x) - 1"

STEPS = 100000

def f(x):
    return x * math.sin(x) - 1

def df(x):
    return x * math.cos(x) + math.sin(x)