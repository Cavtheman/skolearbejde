open System

let readFile (filename : string) : string option =

    let reader  =
        try Some (IO.File.OpenText filename)
        with _ -> None

    if reader.IsSome then
        let text = reader.Value.ReadToEnd()

        Some text
    else
        None

let readFile1 (filename : string) : string option =
    try
        let dis = System.IO.File.ReadAllText filename
        Some dis
    with
        | _ -> None

printfn "%A" <| ((readFile1 "9i0.fsx") = (readFile "9i0.fsx"))
printfn "%A" (readFile1("9i0.fsx"))
printfn "%A" <| readFile1 "empty"
