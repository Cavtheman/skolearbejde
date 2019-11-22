type point = int * int
type colour = int * int * int
type figure =
    | Circle of point * int * colour
    | Rectangle of point * point * colour
    | Mix of figure * figure

let test1 : figure = Rectangle ((1,1), (2,2), (128,128,128))
let test2 : figure = Circle ((1,1), 2, (128,128,128))
let test3 : figure = Mix (Circle ((1,1), 2, (128,128,128)), Rectangle ((1,1), (2,2), (128,128,128)))

let rec print_test (input : figure) =
    match input with
    | Circle (a,b,c)    ->
        printfn "Circle:"
        printfn "Center: %A \nRadius: %A \nColour: %A\n" a b c
    | Rectangle (a,b,c) ->
        printfn "Rectangle:"
        printfn "Bottom left corner: %A \nTop right corner: %A \nColour: %A\n" a b c
    | Mix (a,b)         ->
        printfn "Mix of:"
        print_test a
        print_test b



// printfn "\n%A" <| test1
print_test test1

// printfn "\n%A" <| test2
print_test test2

// printfn "\n%A" <| test3
print_test test3
