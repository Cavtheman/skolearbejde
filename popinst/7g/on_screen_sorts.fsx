// Insertion sort stuff

let rec insert xs y =
  if List.isEmpty xs then [y]
  else let x = List.head xs
       in if y < x then y :: xs
          else x :: insert (List.tail xs) y

let isort xs = List.fold (fun acc x -> insert acc x) [] xs

// Implement this
let rec match_insert (xs: 'a list) (y : 'a) =
    match xs with
    | []               -> [y]
    | z::zs when y < z -> y::xs
    | z::zs            -> z :: match_insert zs y

let match_isort (xs : 'a list) = List.fold (fun acc x -> match_insert acc x) [] xs

let xs = [7;55;34;23;5;42;32;34;8]
printf "%A\n" (isort xs)
printf "%A\n" (match_isort xs)

// Bubble sort stuff
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

let bsort xs =
  List.fold (fun acc _ -> bubble acc) xs xs


// Implement this
let rec match_bubble (xs : 'a list) =
    match xs with
    | []    -> []
    | y::ys ->
        match ys with
        | []               -> [y]
        | z::zs when y < z -> y :: match_bubble ys
        | z::zs            -> z :: match_bubble (y::zs)

let match_bsort (xs : 'a list) =
    List.fold (fun acc _ -> match_bubble acc) xs xs

printfn "%A" (bsort xs)
printfn "%A" (match_bsort xs)

// Merge sort stuff
let rec merge xs ys =
  if List.isEmpty xs then ys
  else if List.isEmpty ys then xs
  else let x = List.head xs
       let y = List.head ys
       let xs = List.tail xs
       let ys = List.tail ys
       in if x < y then x :: merge xs (y::ys)
          else y :: merge (x::xs) ys

// Implement this
let rec match_merge (xs : 'a list) (ys : 'a list) : 'a list =
    match xs, ys with
    | [], _                   -> ys
    | _, []                   -> xs
    | x::xs, y::ys when x < y -> x :: match_merge xs (y::ys)
    | x::xs, y::ys            -> y :: match_merge (x::xs) ys



let rec msort xs =
  let sz = List.length xs
  if sz < 2 then xs
  else let n = sz / 2
       let ys = xs.[0..n-1]
       let zs = xs.[n..sz-1]
       in merge (msort ys) (msort zs)


let rec match_msort xs =
  let sz = List.length xs
  if sz < 2 then xs
  else let n = sz / 2
       let ys = xs.[0..n-1]
       let zs = xs.[n..sz-1]
       in match_merge (match_msort ys) (match_msort zs)


printf "%A\n" (msort xs)

printf "%A\n" (match_msort xs)

// Int tests
let int_test1 = []

let int_test2 = [1..100]
let int_test3 = [100..-1..1]
let int_test4 = xs
let int_test5 = [1]
let int_test6 = [1;2]
let int_test7 = [2;1]

let test1_result = []

let test2_result = [1..100]
let test3_result = [1..100]
let test4_result = msort int_test4
let test5_result = [1]
let test6_result = [1;2]
let test7_result = [1;2]

printfn "int_test1 = %b" (match_msort int_test1 = test1_result)

printfn "int_test2 = %b" (match_msort int_test2 = test2_result)
printfn "int_test3 = %b" (match_msort int_test3 = test3_result)
printfn "int_test4 = %b" (match_msort int_test4 = test4_result)
printfn "int_test5 = %b" (match_msort int_test5 = test5_result)
printfn "int_test6 = %b" (match_msort int_test6 = test6_result)
printfn "int_test7 = %b" (match_msort int_test7 = test7_result)


// Float tests
let float_test1 = List.map float [1..100]
let float_test2 = List.map float [100..-1..1]
let float_test3 = List.map float xs
let float_test4 = List.map float [1]
let float_test5 = List.map float [1;2]
let float_test6 = List.map float [2;1]

let float_test1_result = List.map float test2_result
let float_test2_result = List.map float test3_result
let float_test3_result = List.map float test4_result
let float_test4_result = List.map float test5_result
let float_test5_result = List.map float test6_result
let float_test6_result = List.map float test7_result

printfn "float_test1 = %b" (match_msort float_test1 = float_test1_result)
printfn "float_test2 = %b" (match_msort float_test2 = float_test2_result)
printfn "float_test3 = %b" (match_msort float_test3 = float_test3_result)
printfn "float_test4 = %b" (match_msort float_test4 = float_test4_result)
printfn "float_test5 = %b" (match_msort float_test5 = float_test5_result)
printfn "float_test6 = %b" (match_msort float_test6 = float_test6_result)


// Char tests
let char_test1 = List.map char [1..100]
let char_test2 = List.map char [100..-1..1]
let char_test3 = List.map char xs
let char_test4 = List.map char [1]
let char_test5 = List.map char [1;2]
let char_test6 = List.map char [2;1]

let char_test1_result = List.map char test2_result
let char_test2_result = List.map char test3_result
let char_test3_result = List.map char test4_result
let char_test4_result = List.map char test5_result
let char_test5_result = List.map char test6_result
let char_test6_result = List.map char test7_result

printfn "char_test1 = %b" (match_msort char_test1 = char_test1_result)
printfn "char_test2 = %b" (match_msort char_test2 = char_test2_result)
printfn "char_test3 = %b" (match_msort char_test3 = char_test3_result)
printfn "char_test4 = %b" (match_msort char_test4 = char_test4_result)
printfn "char_test5 = %b" (match_msort char_test5 = char_test5_result)
printfn "char_test6 = %b" (match_msort char_test6 = char_test6_result)
