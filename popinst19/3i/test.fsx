// The normal simplesum function
let simpleSum (n:int) : int =
    n*(n+1)/2

// Improved simpleSum function that can take inputs up to 65535
let betterSimpleSum (n:int) : int =
    if n%2 = 0 then
        let retVal = (n/2)*(n+1)
        retVal
    else
        let retVal = n*((n+1)/2)
        retVal

printfn "%i" (simpleSum 65535)
printfn "%i" (betterSimpleSum 65535)
