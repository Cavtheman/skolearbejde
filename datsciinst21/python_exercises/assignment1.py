
def read_data (filename : string):
    with open(filename, "r") as results:
        contents = [ line for line in results ]
        split_contents = [ [ float (num) for num in elem.split() ] for elem in contents ]
        return split_contents


def calc_averages (data):
    ret_val = []
    for i in range(len(data[0])):
        avg_list = [ elem[i] for elem in data ]
        ret_val.append (sum (avg_list) / len(avg_list))
    return ret_val


def transpose_data (data):
    ret_val = []
    for i in range(len(data[0])):
        avg_list = [ elem[i] for elem in data ]
        ret_val.append (avg_list)
    return ret_val

#print (transpose_data (contents))
#print (len (transpose_data (contents)))
#print (len (transpose_data (contents)[0]))
#
#print (contents == transpose_data (transpose_data (contents)))
