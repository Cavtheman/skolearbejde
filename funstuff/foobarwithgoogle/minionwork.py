def solution(data, n):
    counts = {}
    for elem in data:
        if elem in counts:
            counts[elem] = counts[elem]+1
        else:
            counts[elem] = 1
    #ret_val = []
    ret_val = list (filter (lambda a : counts[a] <= n, data))
    return ret_val

print (solution ([1,2,3,3], 1))
