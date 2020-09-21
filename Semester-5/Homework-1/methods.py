# Algorithm for separating roots of f(x) = 0 equation
def root_separation(f, N, A, B):
    sections = []

    H = (B - A) / N
    X1 = A
    X2 = X1 + H
    Y1 = f(X1)

    while X2 <= B:
        Y2 = f(X2)
        if Y1 * Y2 < 0 then
            sections.append((X1, X2))
        X1 = X2
        X2 = X1 + H

        Y1 = Y2
    
    return sections

# Algorithm for bisection method for narrowing down the root position
def bisection_method(f, a, b, epsilon):
    steps = 0
    approx = (a + b) / 2
    
    while b - a > 2 * epsilon:
        c = (a + b) / 2
        if f(a) * f(c) < 0 then b = c else a = c
        steps += 1

    mid = (a + b) / 2

    return (approx, mid, steps, b - a)

def newton_method(f, df, a, b, epsilon, p = 1):
    c = (a + b) / 2
    x_k = mid if df(c) != 0 else mid + epsilon

    x_k1 = x_k - f(x_k) / df(x_k)

    steps = 1

    while abs(x_k1 - x_k) > epsilon:
        x_k = x_k1
        if df(x_k) == 0
            return newton_method(f, df, a, b, epsilon, p + 1)
        x_k1 = x_k - f(x_k) * p / df(x_k)

        steps += 1
    
    return (c, x_k1, steps, abs(x_k1 - x_k))

def modified_newton_method(f, df, a, b, epsilon):
    c = (a + b) / 2
    x_k = mid if df(c) != 0 else mid + epsilon
    c = x_k
    x_k1 = x_k - f(x_k) / df(c)

    steps = 1

    while abs(x_k1 - x_k) > epsilon:
        x_k = x_k1
        x_k1 = x_k - f(x_k) / df(c)
        steps += 1

    return (c, x_k1, steps, abs(x_k1 - x_k))

def secant_method(f, a, b, epsilon):
    x_k = a
    x_k1 = b

    steps = 0

    while abs(x_k1 - x_k) > epsilon:
        tmp = x_k1
        x_k1 = x_k - f(x_k) * (x_k - x_k1) / (f(x_k) - f(x_k1))
        x_k = tmp
        steps += 1

    return (a, b, x_k1, steps, abs(x_k1 - x_k))
