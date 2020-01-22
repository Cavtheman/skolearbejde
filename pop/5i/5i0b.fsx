//Puts first values of all lists in new list
//This could be done quicker with a List.foldback,
//since :: can be used instead of @
let firstColumn (lslist : 'a list list) : ('a list) =
    List.fold (fun acc (elem : 'a list) -> acc @ [elem.Head]) [] lslist

//list to test
let lsls = [ [1;2;3;]; [4;5;6;]; ] 

firstColumn lsls |> printfn "%A"
