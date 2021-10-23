let rec testFun (n : float) : float =
    match n with
    | 0. -> 1.
    | n  -> (testFun (n-1.)) + 2.**n

for i in [1..20] do
    printfn "%A" <| testFun (float i)
