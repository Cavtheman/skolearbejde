let rec frac2cfrac (t:int) (n:int) : (int list) =
    let ri = t % n
    if ri = 0 then
        [t]
    else
        (t/n) :: (frac2cfrac n ri)

printfn "%A" (frac2cfrac 649 200)
