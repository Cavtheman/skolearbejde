open System


match test.tac ["tst.fsx"] with
| Some a ->
    printfn "%A" a
| None   ->
    failwith "Failure"
