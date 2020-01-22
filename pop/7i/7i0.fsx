// Two lists to be merged
let list0 = [0..2..20]
let list1 = [1..2..19]

// Function that recursively combines two lists into one
let rec merge = function
    | ([] , ys)                      -> ys
    | (xs , [])                      -> xs
    | ([] , [])                      -> []
    | (hx::xt , hy::yt) when hx < hy -> hx::merge (xt , hy::yt)
    | (hx::xt , hy::yt)              -> hy::merge (hx::xt , yt)

merge (list0 , list1) |> printfn"%A"
