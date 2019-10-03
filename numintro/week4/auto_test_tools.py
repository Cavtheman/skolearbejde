import numpy as np
from inspect import currentframe
from threading import Timer
import os


def __kill_infinite_loop():
    print('Possible Infinite loop detected')
    os._exit(1)


def get_linenumber():
    cf = currentframe()
    return cf.f_back.f_lineno


__cnt_failures = 0
__cnt_passed = 0
__cnt_tasks = 0
__task_name = 'no name'
__accumulated_pass_rate = 0.0
__interval_in_seconds = 1000.0
__infinite_loop_quad = Timer(__interval_in_seconds, __kill_infinite_loop)
__infinite_loop_quad.start()


def start():
    global __tasl_name
    global __cnt_failures
    global __cnt_passed
    global __cnt_tasks
    global __accumulated_pass_rate
    __cnt_failures = 0
    __cnt_passed = 0
    __cnt_tasks = 0
    __task_name = 'no name'
    __accumulated_pass_rate = 0.0


def begin_task(name: str):
    global __task_name
    global __cnt_failures
    global __cnt_passed
    __task_name = name
    __cnt_failures = 0
    __cnt_passed = 0


def float_is_close(a: float, b: float, tolerance: float, line: int, msg: str = None) -> bool:
    global __cnt_failures
    global __cnt_passed
    if (a == 0.0 or b == 0) and abs(a-b) < tolerance:
        __cnt_passed += 1
        return True
    if (abs(a-b) < abs(a*tolerance)) and (abs(a - b) < abs(b * tolerance)):
        __cnt_passed += 1
        return True
    __cnt_failures += 1
    if msg is not None:
        print('Line ' + str(line) + ' : float is close failed in test "' + msg + '"')
    return False


def is_equal(a, b, line: int, msg: str = None) -> bool:
    global __cnt_failures
    global __cnt_passed
    if a == b:
        __cnt_passed += 1
        return True
    __cnt_failures += 1
    if msg is not None:
        print('Line ' + str(line) + ' : is equal failed in test "' + msg + '"')
    return False


def list_is_close(x: list, y: list, tolerance: float, line: int, msg: str = None) -> bool:
    global __cnt_failures
    if len(x) != len(y):
        print(msg)
        __cnt_failures += max( len(x), len(y))
        return False
    all_passed = True
    for i in range(len(x)):
            a = x[i]
            b = y[i]
            if not float_is_close(a, b, tolerance, line, None):
                all_passed = False
    if not all_passed and msg is not None:
        print('Line ' + str(line) + ' : list is close failed in test "' + msg + '"')
    return all_passed


def vector_is_close(x: np.ndarray, y: np.ndarray, tolerance: float, line: int, msg: str = None) -> bool:
    global __cnt_failures
    if len(x.shape) != 1 and x.shape[1] != 1:
        print(msg)
        __cnt_failures += max(x.size, y.size)
        return False
    if len(y.shape) != 1 and y.shape[1] != 1:
        print(msg)
        __cnt_failures += max(x.size, y.size)
        return False
    if x.shape[0] != y.shape[0]:
        print(msg)
        __cnt_failures += max(x.size, y.size)
        return False
    all_passed = True
    for i in range(x.shape[0]):
            a = x[i]
            b = y[i]
            if not float_is_close(a, b, tolerance, line, None):
                all_passed = False
    if not all_passed and msg is not None:
        print('Line ' + str(line) + ' : vector is close failed in test "' + msg + '"')
    return all_passed


def matrix_is_close(A: np.ndarray, B: np.ndarray, tolerance: float, line: int, msg: str = None) -> bool:
    global __cnt_failures
    if len(A.shape) != 2:
        print(msg)
        __cnt_failures += max(A.size, B.size)
        return False
    if len(B.shape) != 2:
        print(msg)
        __cnt_failures += max(A.size, B.size)
        return False
    if A.shape != B.shape:
        print(msg)
        __cnt_failures += max(A.size, B.size)
        return False
    all_passed = True
    for i in range(A.shape[0]):
        for j in range(A.shape[1]):
            a = A[i, j]
            b = B[i, j]
            if not float_is_close(a, b, tolerance, line, None):
                all_passed = False
    if not all_passed and msg is not None:
        print('Line ' + str(line) + ' : matrix is close failed in test "' + msg + '"')
    return all_passed



def end_task():
    global __task_name
    global __cnt_failures
    global __cnt_passed
    global __cnt_tasks
    global __accumulated_pass_rate
    cnt_total = __cnt_passed + __cnt_failures
    if cnt_total > 0:
        pass_rate = __cnt_passed / cnt_total
        __cnt_tasks += 1
        __accumulated_pass_rate += pass_rate
        message = __task_name + ': pass rate = ' + format(pass_rate*100, '.2f') + '%'
        print(message)
    else:
        message = __task_name + ': pass rate = ' + format(100.0, '.2f') + '%'
        print(message)


def stop():
    global __cnt_tasks
    global __accumulated_pass_rate
    global __infinite_loop_quad
    if __cnt_tasks>0:
        avg_pass_rate = __accumulated_pass_rate / __cnt_tasks
        message = 'avg pass rate = ' + format(avg_pass_rate*100, '.2f') + '%'
        print(message)
    else:
        message = 'avg pass rate = ' + format(100.0, '.2f') + '%'
        print(message)
    __infinite_loop_quad.cancel()
