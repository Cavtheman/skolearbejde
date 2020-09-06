type point = int * int
type colour = int * int * int
type figure =
    | Circle of point * int * colour
    | Rectangle of point * point * colour
    | Mix of figure * figure

// f i n d s c ol o u r o f f i g u r e a t poi n t
let rec colourAt (x , y) (figure : figure) : Some colour =
    match figure with
    | Circle ( ( cx , cy ) , r , col ) ->
        if ( x - cx ) * ( x - cx )+(y - cy ) * ( y - cy ) <= r * r
        // u s e s Pythagoras ' e q ua tio n to de te rmine
// di s t a n c e to c e n t e r
        then Some col else None
    | Rectangle ( ( x0 , y0 ) , ( x1 , y1 ) , col ) ->
        if x0<=x && x <= x1 && y0 <= y && y <= y1
        // wi t hi n c o r n e r s
        then Some col else None
    | Mix ( f1 , f2 ) ->
        match ( colourAt ( x , y ) f1 , colourAt ( x , y ) f2 ) with
        | ( None , c ) -> c // no o v e rl a p
        | ( c , None ) -> c // no o v e rl a p
        | ( Some ( r1 , g1 , b1 ) , Some ( r2 , g2 , b2 ) ) ->
// a v e rag e c o l o r
            Some ( ( r1+r2 ) /2 , ( g1+g2 ) /2 , ( b1+b2 ) /2 )
