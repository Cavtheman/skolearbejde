import numpy as np
import matplotlib.pyplot as plt
import auto_test_tools as att
import time
import math
'''

First you must implement a function that will compute a vector of
y-values such that

  y(i) = f(x(i))

where

  f(x(i)) = cos(x(i)) exp(-x(i)*x(i)/10.0)

Second you have to implement a function that can evaluate the
value of the Lagrange form (see page 312 in textbook) of the
interpolation polynomial of y's and x's. That is compute

  p(t) = \sum_{i=0}^{n-1} y_i l_i(t)

Where

  l_i(t) = \Pi_{j=0, j \neq i}^{n-1}  \frac{ t-x_j }{x_i-x_j  }

Use a double for-loop to compute the value of p(t). One outer
loop to compute the sum. An one inner loop to compute the products.

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



def f1(x: np.ndarray) -> np.ndarray:
    return np.array( np.exp(-x) * np.cos(4*np.pi*x))

def g(x: np.ndarray) -> np.ndarray:
    return np.array(x * np.sin(1/x))

def error_fun_f (n : np.ndarray) -> np.ndarray:
    return np.array(((3**n) * (1 + 4*np.pi)**(n+1))/math.factorial(n+1))

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


def newton_polynomial(t: float, x: np.ndarray, y: np.ndarray) -> float:
    """
    Evaluate newton polynomial.

    :param t:  The value where the polynomial should be evaluated at
    :param x:  List of x-values
    :param y:  List of y-values

    :return:  The result of the polynomial.
    """

    def prod (i):
        return np.prod([t - elem for (j, elem) in enumerate(x) if j < i])

    ret_val = np.sum([elem * prod(index) for (index,elem) in enumerate(y)])
    return ret_val

# Create data points
x = np.array([9.75815673, 7.91048226, 9.01960577, 5.33256061, 3.11407461])
y = f(x)

# Make some nice plots to visualize approximation of f-function versus true value of the f-function
t = np.linspace(np.min(x), np.max(x), 100)
p = np.array([lagrange_polynomial(t[i], x, y) for i in range(len(t))])
xx = np.linspace(np.min(x), np.max(x), 100)
yy = f(xx)


plt.figure(1)

# My plotting
def plot_fun (values, low_interval, high_interval, fun, poly_fun):

    for i in range(len(values)):
        plt_size = np.ceil(np.sqrt(len(values)))
        plt.subplot(plt_size, plt_size, 1+i)

        x = np.linspace(low_interval,high_interval,values[i])
        y = fun(x)

        t = np.linspace(np.min(x),np.max(x),(values[i]*10))
        p = np.array([poly_fun(t[j], x, y) for j in range(len(t))])

        xx = np.linspace(np.min(x),np.max(x),1000)
        yy = fun(xx)

        plt.plot(x, y, 'ro', label='Data points')
        plt.plot(t, p, 'b-.', label='Approx')
        plt.plot(xx, yy, 'g-', label='Real')
        plt.title('{} Points'.format(values[i]))
        plt.legend(loc='best')

    #plt.tight_layout()
    #plt.show()

def find_integral_error(values, low_interval, high_interval, fun, poly_fun):
    ret_val = []
    for n in values:
        x = np.linspace(low_interval,high_interval,n)
        y = fun(x)

        t = np.linspace(np.min(x),np.max(x),(n*10))
        p = np.array([poly_fun(t[j], x, y) for j in range(len(t))])

        xx = np.linspace(np.min(x),np.max(x),1000)
        yy = fun(xx)

        error_list = [abs(e1 - e2) for e1, e2 in zip(p,yy)]
        #print(error_list)
        ret_val.append(np.sum(error_list))
        plt.plot(t, error_list, label="Error function, n = {}".format(n))

    plt.legend(loc='best')
    plt.show()

    return ret_val
#n_vals = range(1,21)
n_vals = [10,20,50,100]
times = []

def plot_time (n, poly_fun):
    for i in range(2,n,2):
        start = time.time()
        plot_fun([i],-1,1, g)
        end = time.time()
        times.append(end-start)

    plt.show()
    plt.scatter(range(1,101,2),times)
    plt.xlabel('Number of points')
    plt.ylabel('Time taken in seconds')
    plt.show()

# Used to plot the running time
# Takes a long time to run
#plot_time(101)

print(find_integral_error(n_vals, 1, 10, f1, lagrange_polynomial))
# plt.tight_layout()
# plt.show()

plot_fun(n_vals, 1, 10, f, lagrange_polynomial)
plt.tight_layout()
plt.show()

plot_fun(n_vals, 0, 3, f1, lagrange_polynomial)
plt.tight_layout()
plt.show()

plot_fun(n_vals, -1, 1, g, lagrange_polynomial)
plt.tight_layout()
plt.show()


# Given plots
p1, = plt.plot(x, y, 'ro', label='Data points')
#plt.hold(True)
p2, = plt.plot(t, p, 'b-.', label='Approx')
p3, = plt.plot(xx, yy, 'g-', label='Real')
plt.legend(handles=[p1, p2, p3], loc='best')
plt.xlabel('x')
plt.ylabel('y')
plt.title('Lagrange Polynomials')
plt.grid(True)
#plt.hold(False)
plt.show()

att.start()

att.begin_task('Task 1')
pp = np.array([lagrange_polynomial(x[i], x, y) for i in range(len(x))])
att.vector_is_close(y, pp, 10e-7, att.get_linenumber(), ' failed to interpolate data points')

t_known = np.array(
    [3.11407461, 3.85230596, 4.5905373, 5.32876865, 6.067, 6.80523134, 7.54346269, 8.28169404, 9.01992538, 9.75815673])
p_known = np.array(
    [-3.79035755e-01, -1.33495716e-01, -1.06624434e-02, 3.37424501e-02, 3.50066003e-02, 1.94268912e-02, 4.30945460e-03,
     -2.03032948e-03, -2.67833108e-04, -6.91803343e-05])
p_tst = np.array([lagrange_polynomial(t_known[i], x, y) for i in range(len(t_known))])
att.vector_is_close(p_tst, p_known, 10e-7, att.get_linenumber(), ' failed to compute known values')
att.end_task()

att.stop()
