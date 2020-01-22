//This function can return correct values for values less than  2^31 = 1+2+..+(n-1)+n
let sum n = 
    let mutable s = 0 
    let mutable i = 1
    while i <= n do 
        s <- s + i
        i <- i + 1 
    s

//a simpler version of the above function. Does the same with a single calculation.
//Can return the correct value for values less than n*(n+1)=2^31, rounded down.
let simpleSum n =
    n*(n+1)/2

//prints the titles of each row 
printfn "n \t sum \t simpleSum"
//a for loop that prints a specific amount of lines of n, sum, and simplesum, to compare them.
for i=1 to 10 do
    printfn "%d \t %d \t %d" i (sum i) (simpleSum i)
