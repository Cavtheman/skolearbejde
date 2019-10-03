import numpy as np
from math import sqrt
import auto_test_tools as att
import matplotlib.pyplot as plt


'''

Write a function that can generate an array with N elements. The values are mathematically defined as

    z_n = alpha (1+sqrt{3})^n + beta (1-sqrt{3})^n

for all n>=1. The number of elements and the two real numbers alpha and beta are given as as input.

HINT read about square root function here https://docs.python.org/3/library/math.html

ADVICE: Submit your solution even if your code is
not running or your score is less than 100%

'''


def make_sequence(N:int, alpha:float, beta:float) -> np.ndarray:

    retVal = np.zeros(N)

    for i in range(N):
        retVal[i] = alpha * (1 + sqrt(3))**(i+1) + beta * (1 - sqrt(3))**(i+1)

    return retVal
    """
    Generate a sequence as a vector.

    :param N:       The number of elements to create.
    :param alpha:   The alpha value.
    :param beta:    The bea value
    :return:        The output vector.
    """


att.start()
att.begin_task('Task 1')


z0 = np.array([-0.73205080756887719318])
z1 = np.array([-0.73205080756887719318, 0.53589838486224528058, -0.39230484541326360315, 0.28718707889796313282, -0.21023553303060077413, 0.15390309173472466187, -0.11266488259175216902, 0.08247641828594490243, -0.06037692861161447766, 0.04419897934866082873])
z2 = np.array([-0.45884572681198948496])
z3 = np.array([-0.45884572681198948496, 1.28230854637602087465, 1.64692563912806244630, 5.85846837100816664190, 15.01078802027245906459, 41.73851278256124430754, 113.49860160566738898069, 310.47422877645726657647, 847.94566076424928269262, 2316.83977908141287116450])

y0 = make_sequence(1, 0.0, 1.0)
y1 = make_sequence(10, 0.0, 1.0)
y2 = make_sequence(1, 0.1, 1.0)
y3 = make_sequence(10, 0.1, 1.0)

print(y0, z0)
print(y1, z1)
print(y2, z2)
print(y3, z3)
att.vector_is_close(z0, y0, 10e-7, att.get_linenumber(), ' make_sequence test failed')
att.vector_is_close(z1, y1, 10e-7, att.get_linenumber(), ' make_sequence test failed')
att.vector_is_close(z2, y2, 10e-7, att.get_linenumber(), ' make_sequence test failed')
att.vector_is_close(z3, y3, 10e-7, att.get_linenumber(), ' make_sequence test failed')

att.end_task()

att.stop()


# First plot
#plt.subplot(2,1,1)
plt.title("a = 0")
plt.plot(np.linspace(0,50,50), make_sequence(50,0,5), label="b=10")
plt.xlabel("z_n")

# Second plot
#plt.subplot(2,1,1)
plt.plot(np.linspace(0,50,50), make_sequence(50,0,1), label="b=1")
plt.xlabel("z_n")

# Third plot
#plt.subplot(2,1,1)
plt.plot(np.linspace(0,50,50), make_sequence(50,0,0.1), label="b=0.1")
plt.xlabel("z_n")

plt.legend()
plt.tight_layout()
plt.savefig('aPlots.png', bbox_inches = 'tight')
plt.show()


# Fourth plot
#plt.subplot(2,1,2)
plt.title("b = 1")
plt.plot(np.linspace(0,50,50), make_sequence(50,1,1), label="a=1")
plt.yscale("log")
plt.grid("on")
plt.xlabel("z_n")

# Fifth plot
#plt.subplot(2,1,2)
plt.plot(np.linspace(0,50,50), make_sequence(50,10,1), label="a=10")
plt.yscale("log")
plt.xlabel("z_n")

# Sixth plot
#plt.subplot(2,1,2)
plt.plot(np.linspace(0,50,50), make_sequence(50,0.1,1), label="a=0.1")
plt.yscale("log")
plt.xlabel("z_n")

plt.legend()
plt.tight_layout()
plt.savefig('bPlots.png', bbox_inches = 'tight')
plt.show()
