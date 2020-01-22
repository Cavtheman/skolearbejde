#r "img_util.dll"
open ImgUtil

// Prevents more clutter than necessary in xfrac function by calculating the 
// length of the larger squares, so they can be placed correctly
let sqlen len dep =
    int(3.0**float(dep-1))*len

// Draws the Vicsek fractal recursively. The len input is the length of the
// sides of the smallest squares of the fractal, while dep is how many
// iterations the function should be run through. x and y are the coordinates
// of the fractals' top left corner
let rec xfrac bmp (x : int , y : int) (len : int) (dep : int) =
    match dep with
    | 0 -> setBox blue (x , y) (x + len, y + len) bmp
    | z when z > 0 ->
        xfrac bmp (x , y) len (dep - 1)
        xfrac bmp (x + 2*sqlen len dep, y) len (dep - 1)
        xfrac bmp (x + sqlen len dep , y + sqlen len dep) len (dep - 1)
        xfrac bmp (x , y + 2*sqlen len dep) len (dep - 1)
        xfrac bmp (x + 2*sqlen len dep , y + 2*sqlen len dep) len (dep - 1)
    | _ -> printfn "Invalid input. Input should be in format \"xfrac bmp (<x> , <y>) <square length> <iterations>\""

// Calls the xfrac function. Several functions are commented out so they don't pop
// out one after the other.
runSimpleApp " XFractor " 516 534 ( fun bmp -> xfrac bmp (10 , 10) 1 5 |> ignore)
runSimpleApp " XFractor " 516 534 ( fun bmp -> xfrac bmp (10 , 10) 2 5 |> ignore)
runSimpleApp " XFractor " 516 534 ( fun bmp -> xfrac bmp (10 , 10) 6 4 |> ignore)
runSimpleApp " XFractor " 516 534 ( fun bmp -> xfrac bmp (10 , 10) 18 3 |> ignore)
runSimpleApp " XFractor " 516 534 ( fun bmp -> xfrac bmp (10 , 10) 54 2 |> ignore)
runSimpleApp " XFractor " 516 534 ( fun bmp -> xfrac bmp (10 , 10) 162 1 |> ignore)
//runSimpleApp " XFractor " 516 534 ( fun bmp -> xfrac bmp (10 , 10) 486 0 |> ignore)
