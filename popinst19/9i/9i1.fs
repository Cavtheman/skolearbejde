module test
open System


let readFile (filename : string) : string option =

    let reader =
        try Some (IO.File.OpenText filename)
        with _ -> None

    if reader.IsSome then
        let text = reader.Value.ReadToEnd()

        Some text
    else
        None


let cat (filenames : string list) : string option =
    let folder (acc : string option) (elemFile : string) : string option =
        match acc with
        | Some combText ->
            match readFile elemFile with
            | Some text -> Some (combText + text)
            | None   -> None
        | None   -> None
    List.fold folder (Some "") filenames


let tac (filenames : string list) : string option =
    let lineRev (input : string) =
        let revArray = (Array.rev (input.Split [|'\n'|]))
        Array.fold (fun acc elem -> acc + elem) "" revArray



    printfn "%A" <| "test1\ntest2\ntest3"
    printfn "%A" <| lineRev "test1\ntest2\ntest3"


    let folder (acc : string option) (elemFile : string) : string option =
        match acc with
        | Some combText ->
            match readFile elemFile with
            | Some text -> Some (combText + text)
            | None   -> None
        | None   -> None
    List.fold folder (Some "") filenames


//printfn "%A" <| cat ["9i0.fsx"; "9i1.fsx"]
//printfn "%A" <| readFile "9i0.fsx"

printfn "Testing cat:\n%A" <| cat ["catTest.txt"; "tacTest.txt"]
//printfn "Testing cat:\n%A" <| cat ["nonexistent"]
printfn "Testing tac:\n%A" <| tac ["catTest.txt"; "tacTest.txt"]
//printfn "Testing tac:\n%A" <| tac ["nonexistent"]
