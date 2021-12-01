with open ("input.txt") as fp:
    lines = fp.readlines ()
    #lines = [199,200,208,210,200,207,240,269,260,263]
    count = 0
    prev = None
    for line in lines:
        new = int (line)
        if prev is not None and new > prev:
            count += 1
        prev = int (line)
    print (count)
