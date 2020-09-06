module fibonacci

let rec fib (n : int) : int =
    match n with
        | 1 -> 0
        | 2 -> 1
        | _ -> fib(n-1) + fib(n-2)

let scale a (b : (float * float)) : (float * float) =
    let first:float = a * fst(b)
    let second:float = a * snd(b)
    (first,second)
