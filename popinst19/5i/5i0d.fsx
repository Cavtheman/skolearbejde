
let testList = [[1;2;3];
                [4;5;6];
                [7;8;9]]
let test1List = [[1;2;3];
                 [];
                 [7;8;9]]

let firstColumn (llst : 'a list list) : 'a list =
    let mutable retVal = []
    for elem in llst do
        retVal <- retVal @ [elem.Head]
    retVal

let dropFirstColumn (llist : 'a list list) : 'a list list =
    let mutable retVal = []
    for elem in llist do
        retVal <- retVal @ [elem.Tail]
    retVal

let transposeBad (llist : ('a list list)) : 'a list list =
    let mutable tempList = llist
    let mutable retVal = []
    for i in 0 .. (llist.Length - 1) do
        retVal <- retVal @ [firstColumn tempList]
        tempList <- dropFirstColumn tempList
    retVal

// let count = List.fold (fun acc (nm,x) -> acc+x) 0 data

let transpose (llist : ('a list list)) : 'a list list =
    let folder (input : 'a list) :
    // List.fold (fun trans (elem : 'a list) -> trans @ (firstColumn elem)) [] llist

printfn "%A" (firstColumn testList)
printfn "%A" (dropFirstColumn testList)
printfn "%A" (transpose testList)
printfn "%A" (transpose test1List)

printfn "%A" ((dropFirstColumn testList).Head)
// printfn "%A" testList
// printfn "%A" (transpose testList)
