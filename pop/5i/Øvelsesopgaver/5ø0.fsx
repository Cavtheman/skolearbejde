let oneTon n =
    let A = [1 .. n]
    for i = 0 to n - 1 do
        A.[i] |> printfn "%i"
oneTon 10
