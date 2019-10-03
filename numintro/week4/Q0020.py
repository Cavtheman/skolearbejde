import numpy as np
import auto_test_tools as att
from math import exp, sin
import math
import matplotlib.pyplot as plt

'''

  First implement the f-function defined by

    f(x)= exp(x)-sin(x) closest to zero.

  Second implement the Secant method on page 95 and use it
  to find the root of the f-function given x0 = -3.5 and x1 = -2.5 as
  input values for the secant method. Add an absolute test

    abs(f(x) ) < epsilon

  And a relative test

    abs(x^k - x^{k-1})/ abs(x^{k}) \leq delta

   And a maximum iteration guard

    k < iter_max

  In each iteration print out the iteration number k, the
  value of current root and current f-value. Print float numbers with 20 digits.

ADVICE: Submit your solution even if your code is
not running or your score is less than 100%

'''


def f(x: float) -> float:
    """
    Compute the function value of x.

    :param x:         The x-value.

    :return:            The function value.
    """
    return exp(x) - sin(x)     # TODO Add your code here!

def r(x:float) -> float:
    return float(math.pi) * x * math.sqrt(x**2 + 400) + math.pi * x**2 - 1200

def bisect(x0: float, x1: float, f, epsilon: float, iter_max: int) -> float:
    print("\nStarting Bisect algorithm with x0 = {0} and x1 = {1}".format(x0,x1))
    for i in range(iter_max):

        mid = (x0+x1)/2
        print(i,mid,f(mid))

        if (f(mid) == 0) or ((x1-x0)/2 < epsilon):
            return mid

        if f(x0) * f(mid) < 0:
            x1 = mid
        else:
            x0 = mid

    print("Reached max number of iterations")
    return(mid)

def secant(x0: float, x1: float, f, epsilon: float, delta: float, iter_max: int) -> float:
    """
    Generates root of f using Secant method.

    :param x0:         First input value
    :param x1:         Second input value
    :param f:          The function to find the root for
    :param epsilon:    A absolute stop threshold
    :param delta:      A relative stop threshold
    :param iter_max:   The maximum number of iterations allowed.


    :return:            The approximate root.
    """

    fx0 = f(x0)
    fx1 = f(x1)
    print("\nStarting Secant algorithm with x0 = {0} and x1 = {1}".format(x0,x1))
    print(0,x0,fx0)
    print(1,x1,fx1)

    for i in range(2,iter_max):
        if abs(fx0) > abs(fx1):
            x0,x1 = x1,x0
            fx0, fx1 = fx1, fx0
        s = (x1-x0)/(fx1-fx0)
        x1 = x0
        fx1 = fx0
        x0 -= fx0 * s
        fx0 = f(x0)
        print(i,x0,fx0)
        if abs(fx0) < epsilon or abs(x1-x0) < delta:
            break

    return x0   # TODO Add your code here!


# Just some fancy plotting to see what goes on, can be out commented if not needed
'''
x = np.linspace(8, 14.0, 100)
y = [r(xi) for xi in x]
plt.figure()
plt.plot(x, y, 'r-')
plt.grid(True)
plt.xlabel('x')
plt.ylabel('y')
plt.show()
'''

secant(10, 12, r, 0.00000000001, 0.000001, 10)
bisect(10, 12, r, 0.00000000001, 100)

att.start()

att.begin_task('Task 1')
root = secant(-3.5, -2.5, f, 0.00000000001, 0.000001, 10)
att.float_is_close(-3.18306301193449447950, root, 10e-7, att.get_linenumber(), ' failed to find root')

att.end_task()

att.stop()
