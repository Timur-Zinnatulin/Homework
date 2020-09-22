import math

EPSILON = 0.00000001
A = -2
B = 1

F_STRING = "cos(3x) - x^3"

STEPS = 100000

def f(x):
    return math.cos(3 * x) - x ** 3

def df(x):
    return (-3) * math.sin(3 * x) - 3 * (x ** 2)