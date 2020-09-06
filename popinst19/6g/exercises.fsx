let rec fac (n : int) : int =
    if n = 1 then
        n
    else
        n*fac(n-1)

printfn "Fac: %i" (fac 4)

// Improved simpleSum function that can take inputs up to 65535
let betterSimpleSum (n:int) : int =
    if n%2 = 0 then
        let retVal = (n/2)*(n+1)
        retVal
    else
        let retVal = n*((n+1)/2)
        retVal

let rec sum (n : int) : int =
    if n = 1 then
        n
    else
        n + (sum (n-1))

printfn "simpleSum %i" (betterSimpleSum 10)
printfn "Sum: %i" (sum 10)

let rec listSum (lst : int list) : int =
    if lst.IsEmpty then
        0
    else
        lst.Head + listSum lst.Tail

let sumList = [1;2;3;4;5;6;7;8;9;10]

printfn "listSum: %i" (listSum sumList)

let rec fold f (acc : 'b) (lst : 'a list) : 'b =
    if lst.Tail.IsEmpty then
        f acc lst.Head
    else
        (fold f (f acc lst.Head) lst.Tail)

let appSumToList intList num =
    intList @ [(sum num)]

printfn "fold: %A" (fold appSumToList [] sumList)
printfn "List.fold %A" (List.fold appSumToList [] sumList)


let rec gcd (a : int) (b : int) =
    if b = 0 then
        a
    else
        gcd b (a%b)

printfn "GCD: %i" (gcd 8 2)
printfn "GCD: %i" (gcd 2 8)
printfn "GCD: %i" (gcd 13 3)

let rec foldback f (lst : 'a list) (acc : 'b) : 'b =
    if lst.Tail.IsEmpty then
        f lst.Head acc
    else
        f lst.Head (foldback f lst.Tail acc)

let appSumToListBack num intList =
    sum num :: intList

printfn "foldback %A" (foldback appSumToListBack sumList [])
printfn "List.foldBack %A" (List.foldBack appSumToListBack sumList [])

printfn "fold %A" (fold (fun acc elem -> elem :: acc) [] sumList)
printfn "foldBack %A" (foldback (fun elem acc -> elem :: acc) sumList [])
printfn "List.foldBack %A" (List.foldBack (fun elem acc -> elem :: acc) sumList [])

printfn "%i" (5/3)


let (=~) a b =
  abs(a - b) < 0.001

printfn "Approx: %b" (0.0001 =~ 0.0002)
