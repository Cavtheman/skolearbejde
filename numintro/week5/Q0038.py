import numpy as np
import auto_test_tools as att


'''

Implement the Crout LU factorization on page 153

Hint: Start by reworking the pseudocode on page 155 into a Crout variant.

'''

def crout(A: np.ndarray):
    """
    Computes LU factorization of A.

    :param A:      The matrix.

    :return:       The pair of matrices L & U.
    """
    n = np.shape(A)[0]
    U = np.identity(n)
    L = np.zeros((n, n))
    for i in range(n):
        L[i,i] = (A[i,i] - np.sum(L[i,:] * U[:,i]))/U[i,i]
        for j in range(i,n):
            U[i,j] = (A[i,j] - np.sum(L[i,range(i)]* U[range(i),j]))/L[i,i]
            L[j,i] = (A[j,i] - np.sum(L[j,range(i)] * U[range(i),i]))/U[i,i]

    return L, U


def forward_substitution(A: np.ndarray, b: np.array) -> np.array:
    """
    Solve lower triangular system using forward substitution.

    :param A:   A lower triangular matrix
    :param b:   A right hand side vector b
    :return:    Upon return this argument holds the solution for A x = b
    """

    x = np.zeros(np.shape(b))

    for i in range(np.shape(b)[0]):
        if i == 0:
            x[0] = b[0]
        else:
            x[i] = b[i] - np.sum(np.dot(A[i,range(i)],x[range(i)]))
        x[i] = x[i] / A[i,i]
    return x


def back_substitution(A: np.ndarray, b: np.array) -> np.array:
    """
    Solve upper triangular system using forward substitution.

    :param A:   An upper triangular matrix
    :param b:   A right hand side vector b
    :return:    Upon return this argument holds the solution for A x = b
    """

    n = np.shape(b)[0] - 1
    x = np.zeros(np.shape(b))

    for i in range(n,-1,-1):
        x[i] = (b[i] - np.dot(A[i,range(i,n+1)], x[range(i,n+1)]))/A[i,i]

    return x


def solve_system(A: np.ndarray, b: np.array) -> np.array:
    """
    Solve linear system A x = b, assume A to be a square non-singular matrix.

    :param A:    A square non-singular matrix.
    :param b:    A right hand side vector.
    :return:    Upon return this argument holds the solution for A x = b
    """
    # TODO add your code here
    L, U = crout(A)

    x = forward_substitution(L, b)
    y = back_substitution(U,x)

    return y

ex_A = np.array(([0.9, -0.2, -0.2],
                 [0.1, 0.7,  -0.49],
                 [0.1, -0.3,  0.5]))

ex_b = np.array(([0.1,0.2,0.2]))

print("Condition Number =", (np.linalg.norm(ex_A)*np.linalg.norm(np.linalg.inv(ex_A))))
print("x =", solve_system(ex_A, ex_b))
print("norm(x) =", np.linalg.norm(solve_system(ex_A, ex_b)))
exMatrix = np.zeros((13,13))

exMatrix[0,0] = -0.7071

exMatrix[0,1] = 0.7071
exMatrix[0,4] = 0.7071
exMatrix[10,6] = 0.7071
exMatrix[10,10] = 0.7071
exMatrix[10,12] = 0.7071

exMatrix[4,0] = 0.6585
exMatrix[7,3] = 0.6585

exMatrix[4,9] = -0.6585

exMatrix[4,4] = 0.7526
exMatrix[7,7] = 0.7526
exMatrix[4,8] = 0.7526
exMatrix[7,11] = 0.7526

exMatrix[3,0]=exMatrix[1,1]=exMatrix[2,2]=exMatrix[6,3]=exMatrix[2,4]=exMatrix[5,5]=exMatrix[8,7]=exMatrix[8,8]=exMatrix[9,9]=exMatrix[11,10]=exMatrix[11,11]=exMatrix[12,12]= 1.

exMatrix[3,3]=exMatrix[1,5]=exMatrix[6,6]=exMatrix[5,9]= -1.

exVector = np.array([0., 0., 200., 0., -1000., 0., 0., -500., 4000., 0., -500., 2000., 0.,])

print(solve_system(exMatrix, exVector))


att.start()

b = np.array([1.0, 1.0, 1.0])

att.begin_task('Task 1')
U0 = np.array([[2.0, 1.0, 1.0], [0.0, 2.0, 1.0], [0.0, 0.0, 2.0]])
z0 = np.array([0.125, 0.25,  0.5])
x0 = back_substitution(U0, b)
att.vector_is_close(z0, x0, 10e-7, att.get_linenumber(), ' failed to compute solution for U x = b')
att.end_task()


att.begin_task('Task 2')
L0 = U0.transpose()
z0 = np.array([ 0.5,    0.25,   0.125])
x0 = forward_substitution(L0, b)
att.vector_is_close(z0, x0, 10e-7, att.get_linenumber(), ' failed to compute solution for L x = b')
att.end_task()

att.begin_task('Task 3')
A0 = np.array([[60.0, 30.0, 20.0], [30.0, 20.0, 15.0], [20.0, 15.0, 12.0]])
(L0, U0) = crout(A0)
Z0 = A0 - L0.dot(U0)
Z = np.zeros(A0.shape)
att.matrix_is_close(Z, Z0, 10e-7, att.get_linenumber(), ' failed to compute LU')
att.end_task()

att.begin_task('Task 4')
A1 = np.array([[60.0, 30.0, 20.0], [0.0, 20.0, 15.0], [0.0, 0.0, 12.0]])
(L1, U1) = crout(A1)
Z1 = A1 - L1.dot(U1)
Z = np.zeros(A1.shape)
att.matrix_is_close(Z, Z1, 10e-7, att.get_linenumber(), ' failed to compute LU')
att.end_task()

att.begin_task('Task 5')
A2 = np.array([[60.0, 0.0, 0.0], [30.0, 20.0, 0.0], [20.0, 15.0, 12.0]])
(L2, U2) = crout(A2)
Z2 = A2 - L2.dot(U2)
Z = np.zeros(A2.shape)
att.matrix_is_close(Z, Z2, 10e-7, att.get_linenumber(), ' failed to compute LU')
att.end_task()

att.begin_task('Task 6')
z0 = np.array([1.0, 2.0, 3.0])
b0 = A0.dot(z0)
x0 = solve_system(A0, b0)
att.vector_is_close(z0, x0, 10e-7, att.get_linenumber(), ' failed to compute solution for A x = b')
att.end_task()

att.stop()
