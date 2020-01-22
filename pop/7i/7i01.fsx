// Function that recursively combines two lists into one
let rec merge = function
    | ([] , ys)                      -> ys
    | (xs , [])                      -> xs
    | ([] , [])                      -> []
    | (hx::xt , hy::yt) when hx < hy -> hx::merge (xt , hy::yt)
    | (hx::xt , hy::yt)              -> hy::merge (hx::xt , yt)

// This function is taken from the slides presented at lectures
let rec msort xs =
    let sz = List.length xs
    if sz < 2 then
        xs
    else
        let n = sz / 2
        let ys = xs.[0..n-1]
        let zs = xs.[n..sz-1]
        in merge ((msort ys),(msort zs))

// Little blackbox testing function, prints the list to be sorted,
// the expected result, and whether they're equal to each other
let blackbox (sort : 'a list) (expected : 'a list) : bool =
    printfn "%A = %A is %b" (msort sort) expected (msort sort = expected)
    (msort sort = expected)

// Test of standard, randomly sorted list
blackbox [6;4;2;9;7;5;3;8;0;1] [0..9]

// Test of inversely sorted list
blackbox [9;8;7;6;5;4;3;2;1;0] [0..9]

// Test of sorted list
blackbox [0..9] [0..9]

// Test of list with no elements
blackbox [] []

//Test of list with one element
blackbox [0] [0]

//Test of list with two elements, unsorted
blackbox [1;0] [0;1]

//Test of list with two elements, sorted
blackbox [0;1] [0;1]

// Test with list of letters
blackbox ['a';'d';'f';'b';'e';'c'] ['a'..'f']
