let rec foldback f (lst : 'a list) (acc : 'b) : 'b =
    if lst.Tail.IsEmpty then
        f lst.Head acc
    else
        f lst.Head (foldback f lst.Tail acc)

let convertText (input : string) : string =
    // Use string.collect
