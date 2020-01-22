//This is the function that isTable uses to actually checks
//whether a list fulfills the criteria
let f (acc : bool)  (length : int) (elem : 'a list) =
    if List.isEmpty(elem) then
        (false , length)
    elif acc = false then
        (false , length)
    elif length = elem.Length then
        (true , length)
    else
        (false , length)
    
//Checks whether the lists are the same length and non-zero in length
//if any previous list returned false, the entire thing will return false
//if all lists are the same length, it will return true
let isTable (lslist : 'a list list) =
    let length = lslist.[0].Length
    if List.fold (fun ((acc , length) : (bool * int)) (elem : 'a list) -> f acc length elem) (true , length) lslist = (true , length) then
        true
    else false
    

//Code below works, but only for an input of a list of two lists
//this was the first draft of code
//let isTable1 (lslist : int list list) =
//    if lslist.[0].Length = lslist.[1].Length && lslist.[0].IsEmpty = false then
//        true
//    else false

//Lists for testing
let tlsls = [[2;4;6];[8;10;12]]
let flsls = [[16;18;20];[22;24]]
let f2lsls = [[];[]]

//Tests isTable with different lists
//First should return true.
//Second should return false.
//Third should return false.
isTable tlsls |> printfn "%A"
isTable flsls |> printfn "%A"
isTable f2lsls |> printfn "%A"
