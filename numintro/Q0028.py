import auto_test_tools as att
from math import exp, cos, gamma
import numpy as np
import matplotlib.pyplot as plt
import math
'''

Implement a function that uses the composite trapezoidal rule form page 481 in the textbook
to compute a numerical approximating for a given definite integral.

ADVICE: Submit your solution even if your code is
not running or your score is less than 100%

'''
'''
def f1(x):
    return exp(-x) * cos(4 * math.pi * x)
'''

def f1(x: np.ndarray) -> np.ndarray:
    return np.array( np.exp(-x) * np.cos(4*np.pi*x))

def composite_trapezoid(f, a: float, b: float, N: int) -> float:
    """
    This function compute a numerical approximation to the given integral using the composite trapezoid rule.

    :param f:    The integrand.
    :param a:    The lower/left value of the integration interval.
    :param b:    The upper/right value of the integration interval.
    :param N:    The number of equal sized sub-steps_/intervals to use.

    :return:     The approximate value of the integral.

    """
    h=(b-a)/N
    I= h*(f(a)/2 + sum( f(a+i*h) for i in range(1,N))+f(b)/2)
    return I

def lagrange_polynomial(t: float, x: np.ndarray, y: np.ndarray) -> float:
    """
    Evaluate the value of the interpolating Lagrange polynomial.

    :param t:      The evaluation point.
    :param x:      The x-coordinates of the data points to interpolate.
    :param y:      The y-coordinates of the data points to interpolate.

    :return:       The interpolating value at t.
    """
    def l_i(i, t):
        return np.prod([(t - elem)/(x[i] - elem) for (index, elem) in enumerate(x) if index != i])

    return np.sum([elem * l_i(index, t) for (index, elem) in enumerate(y)])

def richardson(f,s,h,M):
    d=np.zeros(M)
    for k in range (M):
        d[k]=(f(s+h)-f(s-h))/(2*h)
        h=h/2
    for k in range (1,M):
        r=d[k]+(d[k]-d[k-1])/3
        print(k,d[k],r)

richardson(f1, 1, 1, 50)

print("Starting plotting now")
n = 0
n_vals = [10,50,100]
#n_vals = range(1,200)
def error_fun (x):
    f_x = f1(x)
    x_list = np.linspace(0,3,n)
    y_list = [f1(elem) for elem in x_list]
    app_x = lagrange_polynomial(x, x_list, y_list)
    return abs(f_x - app_x)

plot_list = []
for elem in n_vals:
    n = elem
    plot_list.append(composite_trapezoid(error_fun, 0, 3, 50))

print(plot_list)
plt.plot(n_vals, plot_list, label="Integral Error at various n")
plt.legend(loc='best')
plt.yscale('log')
plt.show()

'''
att.start()

att.begin_task('Task 1')

I0 = composite_trapezoid(f, -10.0, 10.0, 40)

att.float_is_close(I0, 0.46011090996096409844, 10e-10, att.get_linenumber(),
                   ' failed to compute integral approximation')

att.end_task()

att.stop()
'''
