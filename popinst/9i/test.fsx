open System


match test.tac ["test.fsx"] with
| Some a ->
    printfn "%A" a
| None   ->
    printfn "Failure"
    Operators.exit(1)
