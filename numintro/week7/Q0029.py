import numpy as np
import matplotlib.pyplot as plt
import auto_test_tools as att

'''

First you must implement a function that will compute a vector of
y-values such that

  y(i) = f(x(i))

where

  f(x(i)) = cos(x(i)) exp(-x(i)*x(i)/10.0)

Second Implement the Newton interpolation method (on page 331-332). Divide the code
into two functions, one named divided_differences corresponding ot bottom on page 331, and
a second named newton_polynomial, that is based on the equation on top of page 332.

ADVICE: Submit your solution even if your code is
not running or your score is less than 100%

'''

def f(x: np.ndarray) -> np.ndarray:
    """
    Generate the vector y = f(x)

    :param x:      The input vector.

    :return:       The output vector.
    """
    ret_val = [np.cos(elem) * np.exp(-elem * elem /10.0) for elem in x]
    return np.array(ret_val)


def divided_differences(x: np.ndarray, y: np.ndarray) -> np.ndarray:
    a = y.copy()
    for j in range(1, len(x)):
        for i in range(n-1, j-1, -1):
            a[i] = float(a[i]-a[i-1])/float(x[i]-x[i-j])
    return a


def newton_polynomial(t: float, x: np.ndarray, y: np.ndarray) -> float:
    """
    Evaluate newton polynomial.

    :param t:  The value where the polynomial should be evaluated at
    :param x:  List of x-values
    :param y:  List of y-values

    :return:  The result of the polynomial.
    """

    def prod (i):
        '''
        ret_val = 1.0
        for j in range(i):
            ret_val *= t - x[j]
        return ret_val
        '''
        return np.prod([t - elem for (j, elem) in enumerate(x) if j < i])

    ret_val = np.sum([elem * prod(index) for (index,elem) in enumerate(y)])
    return ret_val


# Create data points
x = np.array([9.75815673, 7.91048226, 9.01960577, 5.33256061, 3.11407461])
y = f(x)

# Make some nice plots to visualize approximation of f-function versus true value of the f-function
t = np.linspace(np.min(x), np.max(x), 100)
p = np.array([newton_polynomial(t[i], x, y) for i in range(len(t))])
xx = np.linspace(np.min(x), np.max(x), 100)
yy = f(xx)

plt.figure(1)
p1, = plt.plot(x, y, 'ro', label='Data points')
#plt.hold(True)
p2, = plt.plot(t, p, 'b-.', label='Approx')
p3, = plt.plot(xx, yy, 'g-', label='Real')
plt.legend(handles=[p1, p2, p3], loc='best')
plt.xlabel('x')
plt.ylabel('y')
plt.title('Newton Polynomials')
plt.grid(True)
#plt.hold(False)
plt.show()

att.start()

att.begin_task('Task 1')
pp = np.array([newton_polynomial(x[i], x, y) for i in range(len(x))])
att.vector_is_close(y, pp, 10e-7, att.get_linenumber(), ' failed to interpolate data points')

t_known = np.array(
    [3.11407461, 3.85230596, 4.5905373, 5.32876865, 6.067, 6.80523134, 7.54346269, 8.28169404, 9.01992538, 9.75815673])
p_known = np.array(
    [-3.79035755e-01, -1.33495716e-01, -1.06624434e-02, 3.37424501e-02, 3.50066003e-02, 1.94268912e-02, 4.30945460e-03,
     -2.03032948e-03, -2.67833108e-04, -6.91803343e-05])
p_tst = np.array([newton_polynomial(t_known[i], x, y) for i in range(len(t_known))])
att.vector_is_close(p_tst, p_known, 10e-7, att.get_linenumber(), ' failed to compute known values')
att.end_task()

att.stop()
