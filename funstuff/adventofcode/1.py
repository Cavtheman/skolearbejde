import math
import numpy as np

f = open("1.txt", 'r')
input_list = f.read().splitlines()
f.close()

input_list = [int(x) for x in input_list]
answer = np.sum([math.floor(elem/3)-2 for elem in input_list])
print(answer)
