let invList = [5;4;6;7;2;1;5] // 12
let worstList = [70;60;50;40;30;20;10]
let bestList = [10;20;30;40;50;60;70]


let rec merge (l : int list) (r : int list) : (int list * int) =
    //printfn "%A %A" l r
    match l, r with
    | x, [] -> (x, 0)
    | [], y -> (y, 0)
    | x::xs, y::ys ->
        if x > y then
            let merged, c' = (merge (x::xs) ys)
            y::merged, c'+(x::xs).Length
        else
            let merged, c' = merge xs (y::ys)
            x::merged, c'

let rec mergeSort (input : int list) : (int list * int) =
    match input with
    | []    -> [], 0
    | [x]   -> [x], 0
    | input ->
        let len = List.length input
        let l : int list = input.[..len/2-1]
        let r : int list = input.[(len/2)..]

        let lList, cl = (mergeSort l)
        let rList, cr = (mergeSort r)
        let mergeList, cm = merge lList rList
        mergeList, cm+cl+cr



printfn "%A" <| mergeSort []
printfn "%A" <| mergeSort [3]
printfn "%A" <| mergeSort [3;2]
printfn "%A" <| mergeSort [2;3]
printfn "%A" <| mergeSort [1;2;3]
printfn "%A" <| mergeSort [3;2;1]
printfn "%A" <| mergeSort [2;1;3]
printfn "%A" <| mergeSort [4;3;2;1]
printfn "%A" <| mergeSort [1;2;3;4]
printfn "%A" <| mergeSort [3;4;1;2]
printfn "%A" <| mergeSort worstList
printfn "%A" <| mergeSort bestList
printfn "%A" <| mergeSort invList
