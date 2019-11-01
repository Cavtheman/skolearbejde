let question (lst : 'a list) : bool option =
    match lst with
    | []                   -> None
    | x :: ys when ys = [] -> Some false
    // If the line below is commented,
    // the compiler complains about incomplete pattern matches.
    // How can we get to that case though?
    | x :: []              -> Some true
    | y::xs::ys            -> None


printfn "%A" <| question [1]         // False
printfn "%A" <| question [[];[]]     // None
printfn "%A" <| question []          // None
printfn "%A" <| question [[[]];[[]]] // None
printfn "%A" <| question [[1];[]]    // None
printfn "%A" <| question [[1];]      // False
printfn "%A" <| question ([]::[[]])  // None


let alph = ['a'..'z']
let folder acc x = (List.fold(fun acc2 y -> string x + string y :: acc2) [] alph) :: acc
//printfn "%A" <| List.fold folder [] alph
