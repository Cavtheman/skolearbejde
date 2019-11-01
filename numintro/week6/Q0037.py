import numpy as np
import auto_test_tools as att


'''

Implement the Power Method on page 258-259 in the textbook. Make sure your code do
not alter the input values.

Hint: Remember to use "copy" when making a copy of a mutable
      data structure and NOT assignment.

Hint: Be careful about one-based versus zero-based indexing
when converting pseudocode into Python counterparts.

ADVICE: Submit your solution even if your code is
not running or your score is less than 100%

'''


def power_method(A: np.array, x: np.array, iter_max:int) -> (np.float, np.array):
    """
    Uses powers method to estimate the maximum eigenvalue and corresponding eigenvector.

    :param A:           A square input matrix
    :param x:           Initial input vector, can be any random vector
    :param iter_max:    Maximum number of allowed iterations, must be a positive integer
    :return:            A tuple of the maximum eigenvalue and corresponding eigenvector
    """
    ret_val = x.copy()
    r = 0.0

    for i in range(iter_max):
        y = np.dot(A,ret_val)
        r = y[0]/ret_val[0]
        ret_val = y/max(abs(y))

    return r, ret_val

print(power_method(np.array([[1,1],[1,1.001]]), np.array([2,2]), 20)[0])

att.start()

att.begin_task('Task 1')
A = np.array([[6., 5., -5.], [2., 6., -2.], [2., 5., -1.]])
x = np.array([-1., 1., 1.])
A_cpy = A.copy()
x_cpy = x.copy()
(a, v) = power_method(A, x, 30)
a_expected = 6.0
v_expected = np.array([1., 1., 1.])
v /= np.sign(v[0]) #result is only unique up to sign
print("Expected value:", a_expected)
print("Return value:", a,v)
att.float_is_close(a, a_expected, 10e-5, att.get_linenumber(), ' failed to estimate maximum eigenvalue')
print("Expected value:", v_expected)
print("Return value:", a,v)
att.vector_is_close(v, v_expected, 10e-5, att.get_linenumber(), ' failed to estimate eigenvector')
att.end_task()


att.begin_task('Task 2')
A = np.array([[-6., 0., 0.], [0., 2., 0.], [0., 0., -1.]])
x = np.array([1.0, -1.0, 1.])
A_cpy = A.copy()
x_cpy = x.copy()
(a, v) = power_method(A, x, 30)
a_expected = -6.0
v_expected = np.array([1., 0., 0.])
v /= np.sign(v[0]) #result is only unique up to sign
print("Expected value:", a_expected)
print("Return value:", a,v)
att.float_is_close(a, a_expected, 10e-5, att.get_linenumber(), ' failed to estimate maximum eigenvalue')
print("Expected value:", v_expected)
print("Return value:", a,v)
att.vector_is_close(v, v_expected, 10e-5, att.get_linenumber(), ' failed to estimate eigenvector')
att.end_task()

att.stop()
