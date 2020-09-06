
let isTable (llst : 'a list list) : bool =
    for i = 0 to llst.Length do


printfn "%b" (isTable [[0;1;2;3];[0;1;2;3]])
printfn "%b" (isTable [[];[]])
