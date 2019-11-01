import numpy as np
import scipy.linalg
import Q0038 as lu
import auto_test_tools as att


'''

Implement the Inverse Power Method on page 261 in the textbook. Make sure your code do
not alter the input values.

Hint: Remember to use "copy" when making a copy of a mutable
      data structure and NOT assignment.

Hint: Be careful about one-based versus zero-based indexing
when converting pseudocode into Python counterparts.

ADVICE: Submit your solution even if your code is
not running or your score is less than 100%

'''


def inverse_power_method(A: np.array, x: np.array, iter_max:int) -> (np.float, np.array):
    """
    Uses powers method to estimate the minimum eigenvalue and corresponding eigenvector.

    :param A:           A square input matrix
    :param x:           Initial input vector, can be any random vector
    :param iter_max:    Maximum number of allowed iterations, must be a positive integer
    :return:            A tuple of the minimum eigenvalue and corresponding eigenvector
    """
    r = 0.0
    old_x = x.copy()

    for i in range(iter_max):
        new_x = lu.solve_system(A,old_x)
        r = new_x[len(old_x)-1] / old_x[len(old_x)-1]
        old_x = new_x/max(abs(new_x))

    return 1/r, old_x

print("test 1",inverse_power_method(np.array([[1,1],[1,1.001]]), np.array([2,2]), 20)[0])
print("test 2",inverse_power_method(np.array([[1,1],[1,1.001]]), np.array([2,2]), 20)[0])
att.start()

att.begin_task('Task 1')
A = np.array([[6., 5., -5.], [2., 6., -2.], [2., 5., -1.]])
x = np.array([-1., 1., 1.])
A_cpy = A.copy()
x_cpy = x.copy()
(a, v) = inverse_power_method(A, x, 50)
a_expected = 1.0
v_expected = np.array([-1., 0., -1.])
print("Expected:",a_expected)
att.float_is_close(a, a_expected, 10e-5, att.get_linenumber(), ' failed to estimate minimum eigenvalue')
print("Expected:\n",v_expected)
att.vector_is_close(v, v_expected, 10e-5, att.get_linenumber(), ' failed to estimate eigenvector')
att.end_task()


att.begin_task('Task 2')
A = np.array([[3., 0., 0.], [0., 2., 0.], [0., 0., 1.]])
x = np.array([0., 5., 10.])
A_cpy = A.copy()
x_cpy = x.copy()
(a, v) = inverse_power_method(A, x, 50)
a_expected = 1.0
v_expected = np.array([0., 0., 1.])
print("Expected:",a_expected)
att.float_is_close(a, a_expected, 10e-5, att.get_linenumber(), ' failed to estimate minimum eigenvalue')
print("Expected:\n",v_expected)
att.vector_is_close(v, v_expected, 10e-5, att.get_linenumber(), ' failed to estimate eigenvector')
att.end_task()

att.stop()
