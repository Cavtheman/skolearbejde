import numpy as np
test1 = np.array([[1,1,1,1],
                  [1,1,1,1]])
test2 = np.array([3,2,2,2])

print((test2 * test1) @ test1.T)
