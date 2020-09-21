import methods
import settings as s
import sys

def print_title():
    print('Лабораторная работа №1 \n')
    print('Тема: Численные методы в нелинейных уравнениях \n')
    print('Исходные параметры задачи: \n')
    print('f(x) = ', s.F_STRING)
    print('[A; B] = [', s.A, '; ', s.B, ']')
    print('\u03B5 = ', s.EPSILON, '\n')

def print_separation(A, B):
    print('Отделение корней.\n')
    print('Количество шагов: ', s.STEPS)
    sections = methods.root_separation(s.f, s.STEPS, s.A, s.B)
    print('Количество отрезков со сменой знака функции: ', len(sections))
    print('Отрезки, содержащие корни уравнения: ')
    for section in sections:
        print('[', round(section[0], 6), '; ', round(section[1], 6), ']')

    return sections

def print_methods(section):
    print_bisec(section)
    print_newton(section)
    print_mod_newton(section)
    print_secant(section)

def print_bisec(section):
    print('\n Метод бисекции:')
    (init_approx, x, steps, last_section_length) = methods.bisection_method(
        s.f, section[0], section[1], s.EPSILON)
    print_res(x, steps, last_section_length, init_approx)
    
def print_newton(section):
    print('\nМетод Ньютона:')
    (init_approx, x, steps, last_section_length) = methods.newton_method(
        s.f, s.df, section[0], section[1], s.EPSILON)
    print_res(x, steps, last_section_length, init_approx)

def print_mod_newton(section):
    print('\nМодифицированный метод Ньютона:')
    (init_approx, x, steps, last_section_length) = methods.modified_newton_method(
        s.f, s.df, section[0], section[1], s.EPSILON)
    print_res(x, steps, last_section_length, init_approx)

def print_secant(section):
    print('\nМетод секущих:')
    (init_approx, init_approx_second, x, steps, last_section_length) = methods.secant_method   (
        s.f, section[0], section[1], s.EPSILON)
    print_res(x, steps, last_section_length, init_approx, init_approx_second)

def print_res(x, steps, section_len, init_approx, init_approx_sec=None):
    print('Количество шагов: ', s.STEPS)
    
    if (init_approx_sec == None):
        print('Начальное приближение: ', round(init_approx, 6))
    else:
        print('Начальное приближение: x0 = ', round(init_approx, 6),
                '; x1 = ', round(init_approx_sec, 6))

    print('x = ', round(x, 6))
    print('|f(x) - 0| = ', round(abs(s.f(x)), 6))
    print('Длина последнего отрезка: ', round(section_len, 6), '\n')