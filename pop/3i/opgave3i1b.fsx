//takes two variables, the width and length of the table
let loopMulTable x y = 
    let mutable endt = "   "
    for i = 1 to x do
        endt <- endt + sprintf "%4d" i
    endt <- endt + sprintf "\n\n"
//prints the table to specified limits
    for i = 1 to y do
        endt <- endt + sprintf "%3d" i
        for j = 1 to x do
            endt <- endt + sprintf "%4d" (i*j)
            if j = x then
                endt <- endt + sprintf "\n"
    endt

//prints tables with several different inputs for display
printfn "%s" (loopMulTable 10 1)
printfn "%s" (loopMulTable 10 2)
printfn "%s" (loopMulTable 10 3)
printfn "%s" (loopMulTable 10 10)
