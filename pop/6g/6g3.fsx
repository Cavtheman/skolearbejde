let rec cfrac2frac (lst : int list) (i : int) =
    List.foldBack (fun ((nume : int), (deno : int)) (elem : int) -> nume * elem + deno) 
