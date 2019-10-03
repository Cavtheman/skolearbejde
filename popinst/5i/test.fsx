let (=~) a b =
  abs(a - b) < 0.001


printfn "%A" (1.1 =~ 1.100001)

// let x = 10

let f x = x + 1

let x : float list = [infinity]
printfn "%A" x.[0]
(*
let xAppend (x:int) f : int =
    printfn "%A" (f x)
    let y = [x] @ [0]
    y.Length

//let reverseApply (x:'a) (f(y:'a):'b) : 'b =
//    f x

printfn "%A" (xAppend(x))
//printfn "%A" x.length
*)
