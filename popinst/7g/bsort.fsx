///<summary>Perform a bubble of the bubble sort algorithm. The
///elements must be comparable, i.e., if x and y are elements, then y
///< x must be defined.</summary>
///<param name = "x"s>An unsorted list</param>
///<returns>An unsorted list with sorted list with the smallest
///element at the Head list with y inserted into xs.</returns>
let rec bubble (xs:int list) =
  if List.isEmpty xs then
      []   // x::y::ys
  else
      let x = List.head xs    //  => y::bubble(x::ys) (y<x)
      let ys = List.tail xs
      if List.isEmpty ys then
          [x]
      else
          let y = List.head ys
          if x < y then
              x :: bubble ys
          else
              y :: bubble (x::List.tail ys)

///<summary>Sort a list using bubble sort. The elements must be
///comparable, i.e., if x and y are elements, then y < x must be
///defined.</summary>
///<param name = "xs">An unsorted list</param>
///<returns> A sorte list with the smallest element at the Head.</returns>
let bsort xs =
  List.fold (fun acc _ -> bubble acc) xs xs

let xs = [7;55;34;23;5;42;32;34;8]
let ys = bsort xs

let rec match_bubble (xs: 'a list) =
    match xs with
    | []    -> []
    | x::ys ->
            match ys with
            | []               -> [x]
            | z::zs when x < z -> x :: match_bubble ys
            | z::zs            -> z :: match_bubble (x::zs)

let match_bsort (xs : 'a list) =
    List.fold (fun acc _ -> match_bubble acc) xs xs

let fxs = [7.0;55.0;34.0;23.0;5.0;42.0;32.0;34.0;8.0]
printfn "%A" ys
printfn "%A" (match_bsort xs)
printfn "%A" (match_bsort fxs)

let alph_list = List.rev ['a' .. 'z']
printfn "%A" alph_list

printfn "%A" (match_bsort alph_list)
