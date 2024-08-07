//Determines whether the gien index value is legal, returns 0 if not
let safeIndexIf (arr : 'a[]) = function
    | i when i >= 0 && i < arr.Length -> arr.[i]
    | _                               -> Unchecked.defaultof<'a>

//Determines whether the given index value is legal in the array, using "try with"
let safeIndexTry (arr : 'a[]) (i : int) =
    try arr.[i]
    with _ -> failwithf "Index \"%i\" out of bounds" i

//Determines whether the given index value is legal in the array with an Option
let safeIndexOption (arr : 'a[]) = function
    | i when i >= 0 && i < arr.Length -> Some arr.[i]
    | _ -> None

//To be called with safeIndexOption to print the results
let optionPrnt (opt : 'a Option) =
    match opt with
    | Some opt -> printfn "%A" opt
    | None   -> printfn "Index out of bounds"




//Blackbox testing that calls the testArr array, once in bounds, and once out.
//End result should look something like this:
//2 0 2 "Index out of bounds" 2 "index out of bounds"
let testArr = [|0;1;2|]

let tryTest func (arr : int) =
    try
        (func testArr arr) |> printfn "%A"
    with Failure a -> printfn "%s" a

//safeIndexif testing, one in, and one out of the array.
printfn "%A" (safeIndexIf testArr 2)
printfn "%A" (safeIndexIf testArr 3)

//safeIndexOption testing, one in, and one out of the array.
optionPrnt (safeIndexOption testArr 2)
optionPrnt (safeIndexOption testArr 3)

//safeIndexTry testing, one in, and one out of the array.
tryTest safeIndexTry 2
tryTest safeIndexTry 3
