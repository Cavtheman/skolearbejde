def pay_or_no (so_far, pay, lambs):
    if lambs >= pay:
        so_far.append(pay)
        return find_min (so_far, lambs-pay)
    else:
        return so_far, lambs

def find_min (so_far, total_lambs):
    if len(so_far) < 2:
        if len(so_far) == 1:
            pay = 2
        else:
            pay = 1
        return pay_or_no (so_far, pay, total_lambs)
    else:
        fst_jnr = so_far[-1]
        snd_jnr = so_far[-2]
        pay = min (2*fst_jnr, fst_jnr + snd_jnr)
        #rule2 = 2 * fst_jnr
        #rule3 = fst_jnr + snd_jnr
        return pay_or_no (so_far, pay, total_lambs)
        #if total_lambs >= 1:
        #    return find_min ([1], total_lambs-1)
        #else:
        #    return 0


def min_max_gen(minmax, lambs):
    snd_jnr = 0
    fst_jnr = 0
    pay = 1
    while pay <= lambs:
        yield pay
        snd_jnr = fst_jnr
        fst_jnr = pay
        pay = max (minmax (2*fst_jnr, fst_jnr+snd_jnr), 1)
        lambs -= pay

def solution(total_lambs):
    stingy = list (min_max_gen (min, total_lambs))
    print (stingy)
    generous = list (min_max_gen (max, total_lambs))
    print (generous)
    return max (len (stingy) - len (generous), 1)

#print (list (min_max_gen (max, 10)))
print (solution (100000))
print (solution (10))
