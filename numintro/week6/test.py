import numpy as np
import Q0038 as power

a = np.array([[1,1],
              [1,1.001]])

print(np.linalg.inv(a))
print(np.linalg.norm(a) * np.linalg.norm(np.linalg.inv(a)))

print(1.001 * 1001)
