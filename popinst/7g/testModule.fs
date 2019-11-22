module testModule

let question (lst : 'a list) : bool option =
    match lst with
    | []                   -> None
    | x :: ys when ys = [] -> Some false
    // If the line below is commented,
    // the compiler complains about incomplete pattern matches.
    // How can we get to that case though?
    | x :: []              -> Some true
    | y::x::ys             -> None
