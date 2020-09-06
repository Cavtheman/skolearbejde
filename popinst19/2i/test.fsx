//printfn "hello world"
let a = "hello world"
//printfn "%s" a
//
//// 2i.2
//printfn "hello\\nworld"
//
//// 2i.3
//let b = "hello world"
//
//let first = b.[0..4]
//let second = b. [6..]
//printfn "%s\n%s" first second

for i = 0 to a.Length-1 do
    if (a.[i] = ' ') then
        printfn "%s\n" a.[..i]
        printfn "%s\n" a.[i+1..]
    else
        printf ""
