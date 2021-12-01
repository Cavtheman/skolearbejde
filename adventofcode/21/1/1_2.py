with open ("input.txt") as fp:
    lines = fp.readlines ()
    count = 0
    prev = [None] * 3
    for line in lines :
        _, *new = prev + [int (line)]
        if None not in prev and sum (new) > sum (prev):
            count += 1
        prev = new
    print (count)
