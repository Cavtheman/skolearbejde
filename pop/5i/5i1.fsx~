//combines a number of lists into one list, in the order given
let concat (lslist : 'a list list) =
    List.fold (fun acc elem -> acc @ elem) [] lslist

//Lists to be tested
let lsls1 = [ [1;2;3]; [4;5;6] ]
let lsls2 = [[4;5;6];[1;2;3]]

concat lsls1 |> printfn "%A"
concat lsls2 |> printfn "%A"
