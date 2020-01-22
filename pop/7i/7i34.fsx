// Recursive Levensthein function. This is slow, since it has to calculate
// the same thing several times.
//7i3
let leven1 (a : string) (b : string) =
    let (i,j) = (a.Length-1,b.Length-1)
    
    let rec leven ((i : int) , (j : int)) =
        match (i , j) with
        | (i , j) when min i j = 0 -> max i j
        | _ -> min (min (leven (i-1,j)+1) (leven (i,j-1)+1)) (leven (i-1,j-1) + (if a.[i] = b.[j] then 0 else 1))
        
    leven (i,j)

// Another recursive Levensthein function, this time with caching, to
// reduce runtime significantly.
// 7i4
let levencache (a : string) (b : string) =
    let (i,j) = (a.Length-1,b.Length-1)
    let cache = Array2D.init (i+1) (j+1) (fun k l -> -1)
    
    let rec ccache = function
        | (i , j) when min i j = 0 -> max i j
        | (i , j) ->
            if cache.[i,j] >= 0 then
                cache.[i,j]
            else
                cache.[i,j] <- leven (i,j)
                cache.[i,j]
                
    and leven = function
        | (i , j) when min i j = 0 -> max i j
        | (i , j) -> min (min (ccache (i-1,j)+1) (ccache (i,j-1)+1)) (ccache (i-1,j-1) + (if a.[i] = b.[j] then 0 else 1))

    leven (i,j)

// Compares the results of the two functions. Both should return the same
// but the second should do it faster
let levtest a b =
    printfn "Non-caching: %i \nCaching: %i" (leven1 a b) (levencache a b)

levtest "dangerous horse" "danger horse"
levtest "Lorem ipsum do" "lor sit amet."
