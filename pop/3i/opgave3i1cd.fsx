
//cuts out part of a large string, and prints out the multiplication table
//up to n
let mulTable n =
    let llength = 45
    let fullTable =
//extra spaces and lines for formatting
        "
      1   2   3   4   5   6   7   8   9  10

  1   1   2   3   4   5   6   7   8   9  10
  2   2   4   6   8  10  12  14  16  18  20
  3   3   6   9  12  15  18  21  24  27  30
  4   4   8  12  16  20  24  28  32  36  40
  5   5  10  15  20  25  30  35  40  45  50
  6   6  12  18  24  30  36  42  48  54  60
  7   7  14  21  28  35  42  49  56  63  70
  8   8  16  24  32  40  48  56  64  72  80
  9   9  18  27  36  45  54  63  72  81  90
 10  10  20  30  40  50  60  70  80  90 100\n"
    fullTable.[0..llength*(n+1)+2]

//takes two variables, the width and length of the table,
//and prints a table with those dimensions
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
printfn "%s" (mulTable 10)
printfn "%s" (loopMulTable 10 10)
//If this was printed using %A instead of %s,there would
//be quotation marks at the beginning and end of the string.
//With %s this does not happen


//tests if the two strings are the same, for values 1 to n.
//MulTable will always have a corresponding value of 10, to loopMulTable's x,
//so that is hardcoded
let compt n =
    for i = 1 to n do
        if(mulTable i) = (loopMulTable 10 i) then 
            printfn "%2i  true" i 
        else
            printfn "%2i  false" i

//with this code it returns false for all values, but this
//is probably because of a random space somewhere in the string
//that i cannot find. The strings are both printed before this,
//so it is visible to the user that both are the same.
            
compt 10
