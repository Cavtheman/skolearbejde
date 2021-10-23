import itertools
def flatten (l):
    return [num for elem in l for num in elem]

def solution(l):
    combinations = flatten ([ itertools.combinations (l, x) for x in range(1, len(l)+1) ])
    perms = flatten ([ itertools.permutations (elem) for elem in combinations ])
    perms = [ int ("".join ([ str(elem) for elem in elem_list])) for elem_list in perms ]
    perms = list (filter ( lambda x : x%3 == 0, perms))
    perms.append(0)
    ret_val = max (perms)
    return ret_val


#print (solution ([3,1,4,1]))
#print (solution ([3,1,4,1,5,9]))
#print ((lambda x : x%3) (94311))
