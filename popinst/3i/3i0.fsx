open System

let sum (n:int) : int =
    let mutable s = 1
    let mutable retVal = 0
    while s <= n do
        retVal <- retVal + s
        s <- s + 1
    retVal

let simpleSum (n:int) : int =
    let retVal = (n*(n+1))/2
    retVal

printfn "Type the number you wish to calculate:"
let input = (int (Console.ReadLine()))
printfn "Normal sum:"
printfn "%i" (sum(input))
printfn "Simple Sum:"
printfn "%i" (simpleSum(input))

let printN (n:int) : unit =
    let mutable sumTable = Array.zeroCreate n
    let mutable simpleSumTable = Array.zeroCreate n
    let mutable nTable = Array.zeroCreate n
    for i = 1 to n-1 do
        sumTable.[i] <- sum(i)
        simpleSumTable.[i] <- sum(i)
        nTable.[i] <- i
    printfn "%A" sumTable
    printfn "%A" simpleSumTable
    printfn "%A" nTable

printN(10)
