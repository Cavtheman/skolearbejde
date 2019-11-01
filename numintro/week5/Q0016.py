import numpy as np
import auto_test_tools as att

'''

Implement a function that computes the Neumann series approximation
to the inverse of a given matrix B. Make an implementation that uses nested
multiplications. The recurrence relation is given here for
convenience.

  A    = I - B
  M(1) = A^0 + A^1 = I + A
  M(k) = I + A M(k-1)       for 2 <= k <= N

Return M(N) as the approximation result for the inverse of B.

Hint: The series only converge if the norm of A is less than
one. You are allowed to use 'np.linalg.norm(A)' for testing the norm.

Hint: If you have extra time you can try and create a one-liner for
computing the series (look for functions to use in numpy.linalg)

ADVICE: Submit your solution even if your code is
not running or your score is less than 100%

'''


def neumann(B: np.ndarray, N: int) -> np.ndarray:
    """
    Computes the Neumann series approximation to the inverse of B.

    :param B:      The matrix.
    :param N:      The number of terms to include in the series

    :return:       An approximation to the inverse matrix if series
                   converge otherwise a zero matrix.
    """
    I = np.identity(np.shape(B)[0])
    A = I - B
    if np.linalg.norm(A) < 1:
        if N > 1:
            return I + np.matmul(A,neumann(B, N-1))
        else:
            return I + A
    else:
        return np.zeros(np.shape(B))

# Code for Exercise 2.3
def find_cond_num(A : np.ndarray):
    invA = np.linalg.inv(A)
    return np.linalg.norm(A) * np.linalg.norm(invA)

A = np.array([[0.9,-0.2,-0.2], [0.1,0.7,-0.49], [0.1,-0.3,0.5]])
print(find_cond_num(A))

att.start()

att.begin_task('Task 1')

B0 = np.array([[1.0, -0.1, 0.2], [0.2, 0.7, 0.1], [0.1, -0.2, 0.8]])
B0inv = neumann(B0, 50)
I0 = B0.dot(B0inv)
I = np.eye(B0.shape[0])
att.matrix_is_close(I, I0, 10e-7, att.get_linenumber(), ' failed to approximate B0')
att.end_task()

att.begin_task('Task 2')

B1 = np.array([[5.0, -0.1, 0.2], [0.2, 0.7, 0.1], [0.1, -0.2, 0.8]])
B1inv = neumann(B1, 50)
Z = np.zeros(B1.shape)
att.matrix_is_close(Z, B1inv, 10e-7, att.get_linenumber(), ' failed to detect B1 is a bad matrix')

att.end_task()

att.stop()
