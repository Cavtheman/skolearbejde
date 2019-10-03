import auto_test_tools as att


'''

Implement a function that can compute the elements of the recurrence
relation, that we mathematically define as follows

    H(n) = 2 H(n-1) + 1
    H(1) = 1

The function should take as input, N, the number of elements to compute
using the recurrence relation and as output the procedure should return
the list H[0], H[1], H[2],..,H[N-1]. Observe that Python indexing is
different from the mathematical definition given above. Your code must
deal with this.

Implement both a recursive and iterative version of the function.

ADVICE: Submit your solution even if your code is
not running or your score is less than 100%

'''


def generate_from_relation_recursively(N: int, n: int = 0, H=[]) -> list:
    if (N > n):
        if (n == 0):
            H = [None] * N
            H[n] = 1
        else:
            H[n] = 2 * H[n-1] + 1
        return generate_from_relation_recursively(N,n+1,H)

    else:
        return H
    """
    Generate a list of elements from a given recurrence relation using a recursive approach.

    :param N:    The number of elements to generate.
    :param n:    The current index of the element that should be generated.
    :param H:    The current elements that have been generated (holds n-1 elements when invoked).


    :return:        The resulting data list after having added the n-element to the list
    """


def generate_from_relation_iteratively(N: int) -> list:
    retVal = [None] * N
    for i in range(N):
        if (i > 0):
            retVal[i] = 2 * retVal[i-1] + 1
        else:
            retVal[i] = 1
    return retVal
    """
    Generate a list of elements from a given recurrence relation using an iterative approach.

    :param N:    The number of elements to generate.


    :return:        The resulting list
    """
    #return []  # TODO Write your own code here!


att.start()

att.begin_task('Task 1')
y = [1, 3, 7, 15, 31, 63, 127, 255, 511, 1023]
x = generate_from_relation_recursively(10)
att.list_is_close(x, y, 10e-7, att.get_linenumber(), ' recursive test failed')
att.end_task()


att.begin_task('Task 2')
z = generate_from_relation_iteratively(10)
att.list_is_close(z, y, 10e-7, att.get_linenumber(), ' iterative test failed')
att.end_task()


att.stop()
