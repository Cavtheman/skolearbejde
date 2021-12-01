open System.IO
type depthWindow = list<int option>

let depthSum (window : depthWindow) : int option =
    let plus a b =
        match a, b with
        | Some aVal, Some bVal -> Some <| aVal + bVal
        | _ -> None
    List.reduce plus window

let slide (window : depthWindow) (newDepth : int) : depthWindow =
    match window with
    | [] -> []
    | _::xs -> xs @ [Some newDepth]

let sonarSweep (filename : string) (windowLength : int) : int =
    let folder ((count, prev) : (int * depthWindow)) (x : int) : (int * depthWindow) =
        let newWindow = slide prev x
        match depthSum prev, depthSum newWindow with
        | Some prevSum, Some newSum when newSum > prevSum -> (count + 1, newWindow)
        | _ -> (count, newWindow)

    let initWindow = List.init windowLength (fun _ -> None)
    try
        filename
        |> File.ReadLines
        |> Seq.map int
        |> Seq.toList
        |> List.fold folder (0, initWindow)
        |> fst
    with
        | _ -> -1

let filename = "input.txt"
//let filename = "inputSimple.txt"

printfn "Result of sonarSweep: %i" <| sonarSweep filename 3

let mutable count = 0
let mutable prev : depthWindow = [None; None; None]

for line in filename |> File.ReadLines |> Seq.map int do
    let newWindow = line |> slide prev
    match depthSum prev, depthSum newWindow with
    | Some prevSum, Some newSum ->
        if newSum > prevSum then
            count <- count + 1
    | _ -> ()
    prev <- newWindow
printfn "Result: %i" count

let sweepFilter (window : array<int>) : bool =
    let len = Array.length window
    //Array.sum window.[..len-2] < Array.sum window.[1..len-1]
    Array.head window < Array.last window

let sonarSweepSeq (filename : string) (windowLength : int) : int =
    filename
    |> File.ReadLines
    |> Seq.map int
    |> Seq.windowed (windowLength + 1)
    |> Seq.filter sweepFilter
    |> Seq.length

printfn "Result with Seq is: %i" <| sonarSweepSeq filename 3
