let rec insert lst y =
    match lst with
        | []                       -> [y]
        | hlst::tlst when hlst > y -> y::lst
        | hlst::tlst               -> hlst::insert tlst y

let rec insert1 y = function
    | [] -> [y]
    | hlst::tlst when hlst > y -> y::hlst::tlst
    | hlst::tlst -> hlst::insert tlst y

let isort xs = List.fold (fun acc x -> insert acc x) [] xs
let isort1 xs = List.fold (fun acc x -> insert1 x acc) [] xs
let xs = [7;55;34;23;5;42;32;34;8]
do printf "%A\n" (isort xs)
do printf "%A\n" (isort1 xs)
