open System.IO
type depthWindow = (int option * int option * int option)

let depthSum (depths : depthWindow) : int option =
    match depths with
    | (Some first, Some second, Some third) -> Some <| first + second + third
    | _ -> None

let slide (window : depthWindow) (newDepth : int) : depthWindow =
    let _, second, third = window
    second, third, Some newDepth

let sonarSweep (filename : string) : int =
    let rec helper (count : int) (prev : depthWindow) (lines : list<int>) : int =
        match lines with
        | [] -> count
        | line::tail ->
            let newWindow = line |> slide prev
            match depthSum prev, depthSum newWindow with
            | Some prevSum, Some newSum ->
                if newSum > prevSum then
                    helper (count + 1) newWindow tail
                else
                    helper count newWindow tail
            | _ -> helper count newWindow tail

    try filename |> File.ReadLines |> Seq.map int |> Seq.toList |> helper 0 (None, None, None)
    with
        | _ -> -1

let filename = "input.txt"

printfn "Result of sonarSweep: %i" <| sonarSweep filename

let mutable count = 0
let mutable prev : depthWindow = (None, None, None)

try
    for line in filename |> File.ReadLines |> Seq.map int do
        let newWindow = line |> slide prev

        match depthSum prev, depthSum newWindow with
        | Some prevSum, Some newSum ->
            if newSum > prevSum then
                count <- count + 1
        | _ -> ()
        prev <- newWindow
    printfn "Result: %i" count
with
    | _ -> printfn "Something went wrong"
