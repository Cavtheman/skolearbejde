import numpy as np
from scipy.linalg import svd
import auto_test_tools as att

'''

Implement the pseudoinverse from page 290 in the text book.

You may use scipy.linalg.svd to compute a SVD decomposition. Read more here

https://docs.scipy.org/doc/scipy/reference/generated/scipy.linalg.svd.html

'''


def pseudoinverse(Ain: np.ndarray) -> np.ndarray:
    """
    Compute pseudo inverse for given matrix

    :param Ain:    The input matrix of dimension m x n.

    :return:       The output pseudo inverse.
    """
    P,D,Q = np.linalg.svd(Ain, full_matrices=False)
    D_plus = np.array([elem**(-1) if elem != 0 else elem for elem in D])
    return np.dot(Q.T * D_plus, P.T)


def pseudo_inverse_minimal_solution(Ain: np.ndarray, bin: np.ndarray) -> np.ndarray:
    """
    Compute minimal solution for given linear system using the SVD pseudo inverse.

    According to Theorem 2 on page 291.

    :param Ain:      The input matrix of dimension m x n, with m>n and rank n.
    :param bin:      The right hand side vector.

    :return:       The output minimal solution.
    """
    return np.dot(pseudoinverse(Ain), bin)


a_system = np.array([[1,2,4],[1,1,2]])
a_bin = np.array([2,1])

b_system = np.array([[4,6],[3,-2],[1,3],[2,6]])
b_bin = np.array([8,-7,5,10])

print(pseudo_inverse_minimal_solution(a_system, a_bin))
print(pseudo_inverse_minimal_solution(b_system, b_bin))

att.start()

att.begin_task('Task 1')
A = np.array([[0, -1.6, 0.6],
              [0, 1.2, 0.8],
              [0, 0, 0],
              [0, 0, 0]]
             )
P_expected = np.array([
              [0, 0, 0, 0],
              [-0.4, 0.3, 0, 0],
              [0.6, 0.8, 0, 0]]
             )
print("Input:\n", A)
print("Expected:\n",P_expected)
P = pseudoinverse(A)
print("Returned:\n", P)

att.matrix_is_close(P, P_expected, 10e-7, att.get_linenumber(), ' failed to compute pseudo inverse')
att.end_task()


att.begin_task('Task 2')
A = np.array([[6., -2., 2.],
              [12., -8., 6.],
              [3., -13., 9.],
              [-6., 4., 1.]]
             )
x_expected = np.array([6., -2., 2.])
b = A.dot(x_expected)
x = pseudo_inverse_minimal_solution(A, b)
print("Input:\n", A, b)
print("Returned:\n", x)
print("Expected:\n",x_expected)
att.vector_is_close(x, x_expected, 1e-7, att.get_linenumber(), ' failed to compute minimal solution')
att.end_task()

att.stop()
