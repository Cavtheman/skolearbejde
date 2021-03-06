//Returns the float option with either the value of None,
//or the average of the list
let gennemsnit (flls : float list) =
    let avg = (List.fold (fun ((acc , length) : (float * float))  (elem : float) -> (acc+elem) , (length + 1.0)) (0.0 , 0.0) flls)
    if (snd avg) > 0.0 then
        (fst avg) / (snd avg) |> Some 
    else
        None
        
//prints out the average of the list,
//or None, if the list was not valid
let printgennemsnit (avg : float option) =
    match avg with
    | None -> printfn "Average not valid"
    | Some x -> x |> printfn "%f"
    
//The lists to be used by the other functions
//ls1 should return 10.5
//ls2 should return invalid, since it's empty
let ls1 = [1.0 .. 20.0]
let ls2 = []

printgennemsnit (gennemsnit ls1)
printgennemsnit (gennemsnit ls2)
