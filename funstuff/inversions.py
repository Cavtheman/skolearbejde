inv_list = [5,4,6,7,2,1,5] # 12
worst_list = [70,60,50,40,30,20,10]
best_list = [10,20,30,40,50,60,70]
#def countInversions (input_list):
#    tuple_list = list (zip (input_list, range (len (input_list))))
#    tuple_list.sort()
#    counter = 0
#    for (index, _), i in zip (tuple_list, range(len(tuple_list))):
#        if index > i:
#            counter += index
#        #counter = counter + index
#    print (tuple_list)
#    return counter
    #tuple_list = [

def countInversions (input_list):
    list_len = len(input_list)
    fst = input_list[:(list_len//2)]
    snd = input_list[(list_len//2):]

    print (fst, snd)

print (countInversions (inv_list))
print (countInversions (worst_list))
print (countInversions (best_list))
