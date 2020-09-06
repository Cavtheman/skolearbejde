///<summary>Insert an element into a list. The elements must be comparable, i.e., if x and y are elements, then y < x must be defined.</summary>
///<param name = "xs">A list of sorted values with the smallest value at the Head.</param>
///<param name = "y">A value</param>
///<returns>A list with y inserted into xs.</returns>
let rec insert xs y =
  if List.isEmpty xs then [y]
  else let x = List.head xs
       in if y < x then y :: xs
          else x :: insert (List.tail xs) y

let isort xs = List.fold (fun acc x -> insert acc x) [] xs

let xs = [7;55;34;23;5;42;32;34;8]
printf "%A\n" (isort xs)

let rec match_insert xs y =
    match xs with
    | []               -> [y]
    | x::ys when y < x -> y::x::ys
    | x::ys            -> x :: match_insert ys y

let match_isort (xs : 'a list) = List.fold (fun acc x -> match_insert acc x) [] xs

printf "%A\n" (match_isort xs)
