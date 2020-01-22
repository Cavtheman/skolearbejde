
//Puts first values of all lists in new list
//This could be done quicker with a List.foldback,
//since we can use :: instead of @
let firstColumn (lslist : 'a list list) : ('a list) =
    List.fold (fun acc (elem : 'a list) -> acc @ [elem.Head]) [] lslist

//takes list of lists and outputs same list of lists
//except with first value removed
let dropFirstColumn (lslist : 'a list list) =
    List.fold (fun acc (elem : 'a list) -> acc @ [elem.Tail]) [] lslist

//function whose only job is to get the length of the table
//this is so the recursive function doesn't have to do it every iteration
//the recursive function transposes all elements in a list of lists,
//and returns the transposed list of lists
let transpose (acc : 'a list list) =
    let length = acc.[0].Length
    let rec trans (acc : 'a list list) (length : int) =
        if length > 1 then
            firstColumn acc :: trans (dropFirstColumn acc) (length - 1)
        else
            [firstColumn acc]
    trans acc length

//This also works, but only with two lists
//it also returns a list of tuples instead of a list of lists
let ziptrans (acc : 'a list list) =
    List.zip acc.[0] acc.[1]
    

//lists to test
let lsls = [ [1;2;3;]; [4;5;6;] ]
let table = [[1;2;3];[2;4;6];[3;6;9]]

//examples that show it working normally,
//and that transposing a table will return the same table
transpose lsls |> printfn "List of lists: \n%A \n"

ziptrans lsls |> printfn "List of tuples: \n%A\n"

(table , transpose table) ||> printfn "Input table: \n%A \n\nTransposed table: \n%A\n"

