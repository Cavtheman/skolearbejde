
// sums up all numbers from 1 to n
let sum n =
    let mutable s = 0
    let mutable i = 1
    while i <= n do
        s <- s + i
        i <- i + 1
    s
printfn "%d" s
