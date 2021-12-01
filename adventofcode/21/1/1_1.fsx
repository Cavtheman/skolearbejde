open System.IO
let filename = "input.txt"

let mutable count = 0
let mutable prev : int Option = None

try
    for line in filename |> File.ReadLines |> Seq.map int do
        match prev with
        | Some depth when line > depth ->
            count <- count + 1
            prev <- Some line
        | _ -> prev <- Some line
    printfn "Result: %i" count
with
    | _ -> printfn "Something went wrong"
