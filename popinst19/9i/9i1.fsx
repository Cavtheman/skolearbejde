open System


let readFile (filename : string) : string option =
    try
        let reader = System.IO.File.OpenText filename
        Some (reader.ReadToEnd ())
    with _ -> None


let cat (filenames : string list) : string option =
    let folder (acc : string option) (elemFile : string) : string option =
        match acc with
        | Some combText ->
            match readFile elemFile with
            | Some text -> Some (combText + text)
            | None   -> None
        | None   -> None
    List.fold folder (Some "") filenames


// This is wrong
let tac (filenames : string list) : string option =
    let folder (elemFile : string) (acc : string option) : string option =
        match acc with
        | Some combText ->
            match readFile elemFile with
            | Some text -> Some (combText + text)
            | None   -> None
        | None   -> None
    List.foldBack folder filenames (Some "")


//printfn "%A" <| cat ["9i0.fsx"; "9i1.fsx"]
printfn "%A" <| readFile "catTest.txt"

//printfn "Testing cat:\n%A" <| cat ["catTest.txt"; "tacTest.txt"]
//printfn "Testing cat:\n%A" <| cat ["nonexistent"]
//printfn "Testing tac:\n%A" <| tac ["catTest.txt"; "tacTest.txt"]
//printfn "Testing tac:\n%A" <| tac ["nonexistent"]
