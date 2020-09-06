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
