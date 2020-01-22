//takes list of lists and outputs same list of lists,
//except with first values of each list removed
let dropFirstColumn (lslist : 'a list list) =
    List.fold (fun acc (elem : 'a list) -> acc @ [elem.Tail]) [] lslist

//list to test
let lsls = [ [1;2;3;]; [4;5;6;]; ]

dropFirstColumn lsls |> printfn "%A"
