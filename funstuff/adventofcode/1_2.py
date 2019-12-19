import math
import numpy as np

f = open("1.txt", 'r')
input_list = f.read().splitlines()
f.close()

input_list = [int(x) for x in input_list]

def calc_fuel (weight : int) :
    fuel_weight = math.floor(weight/3)-2
    if fuel_weight >  0 :
        add_weight = calc_fuel(fuel_weight)
        return fuel_weight + add_weight
    else:
        return 0

print(calc_fuel(14))

answer = np.sum([calc_fuel(elem) for elem in input_list])

print(answer)
