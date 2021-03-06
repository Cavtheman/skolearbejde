#r "img_util.dll"

open ImgUtil

type Point = int * int // a point (x, y) in the plane
type Colour = int * int * int // (red , green , blue ), 0..255
type Figure =
    | Circle of Point * int * Colour
    // defined by center , radius , and colour
    | Rectangle of Point * Point * Colour
    // defined by corners bottom -left , top -right , and colour
    | Mix of Figure * Figure
    // combine figures with mixed colour at overlap
    | Triangle of Point * Point * Point * Colour
    // defined by the three points and colour

// 8g.2 Calculating doubled area of triangle
let triarea2 (p1 : Point) (p2: Point) (p3: Point) : int =
    abs (fst(p1) * (snd(p2) - snd(p3)) + fst(p2) * (snd(p3) - snd(p1)) + fst(p3) * (snd(p1) - snd(p2)))
    
    
let rec colourAt (x,y) = function
    | Circle((cx,cy),r,col) ->
        if (x-cx )*(x-cx)+(y-cy)*(y-cy) <= r*r
        // uses Pythagoras ' formular to determine
        // distance to center
        then Some col else None
    | Rectangle((x0,y0),(x1,y1),col) ->
        if x0 <= x && x <= x1 && y0 <= y && y <= y1
        // within corners
        then Some col else None  
    | Mix(f1,f2 ) ->
        match (colourAt(x,y)f1,colourAt(x,y)f2) with
            | (None,c) -> c // no overlap
            | (c,None) -> c // no overlap
            | (Some(r1,g1,b1),Some(r2,g2,b2)) ->
                // average color
                Some((r1+r2)/2,(g1+g2)/2,(b1+b2)/2)
// 8g.3 Expansion of ColourAt-function and
    | Triangle((ax,ay),(bx,by),(cx,cy),col) ->
        if (triarea2 (x,y) (bx,by) (cx,cy))+
            (triarea2 (ax,ay) (x,y) (cx,cy))+
            (triarea2 (ax,ay) (bx,by) (x,y)) <= (triarea2 (ax,ay) (bx,by) (cx,cy)) then
            Some col
        else
            None

let makePicture (title : string) (fig : Figure) ((w : int),(h : int)) =
    let bmp = mk w h
    
    let makePixel (x,y) =
        match colourAt(x,y) fig with
        | Some c -> setPixel(fromRgb(c)) (x-1,y-1) bmp
        | None   -> setPixel(fromRgb(200,200,200)) (x-1,y-1) bmp
        
    let rec makePix = function
        | (x,y) when x < 1 -> toPngFile title bmp
        | (x,y) when y = 1 -> makePixel (x,y); makePix (x-1,h)
        | (x,y)            -> makePixel (x,y); makePix (x,y-1)
        
    makePix (w,h)
let checkFigure (P:Figure) =
    let cCol (c:Colour) : bool =
        match c with
        | (r,g,b) when r < 256 && r >= 0 && g < 256 && g >= 0 && b < 256 && b >= 0 -> true
        | (_) -> false
    
//8g.5 Making checkFig
    let rec checkFig = function
        | Circle(p,r,c) when r > 0 && cCol(c)                                               -> true
        | Rectangle(p1,p2,c) when cCol(c) && fst(p1) - fst(p2) > 0 && snd(p1) - snd(p2) > 0 -> true
        | Triangle(p1,p2,p3,c) when triarea2 p1 p2 p3 > 0 && cCol(c)                        -> true
        | Mix(P1,P2)                                                                        -> checkFig(P1) && checkFig(P2)
        | _                                                                                 -> false
    checkFig P

let mintricX (p1,p2,p3) : int =
    match (p1,p2,p3) with
    | ((x1,_),(x2,_),(x3,_)) when x1 < x2 && x1 < x3 -> x1
    | ((x1,_),(x2,_),(x3,_)) when x2 < x1 && x2 < x3 -> x2
    | ((x1,_),(x2,_),(x3,_))                         -> x3

let mintricY (p1,p2,p3) : int =
    match (p1,p2,p3) with
    | ((_,y1),(_,y2),(_,y3)) when y1 < y2 && y1 < y3 -> y1
    | ((_,y1),(_,y2),(_,y3)) when y2 < y1 && y2 < y3 -> y2
    | ((_,y1),(_,y2),(_,y3))                         -> y3

let maxtricX (p1,p2,p3) : int =
    match (p1,p2,p3) with
    | ((x1,_),(x2,_),(x3,_)) when x1 > x2 && x1 > x3 -> x1
    | ((x1,_),(x2,_),(x3,_)) when x2 > x1 && x2 > x3 -> x2
    | ((x1,_),(x2,_),(x3,_))                         -> x3

let maxtricY (p1,p2,p3) : int =
    match (p1,p2,p3) with
    | ((_,y1),(_,y2),(_,y3)) when y1 > y2 && y1 > y3 -> y1
    | ((_,y1),(_,y2),(_,y3)) when y2 > y1 && y2 > y3 -> y2
    | ((_,y1),(_,y2),(_,y3))                         -> y3
    
let rec boundingBox = function
    | Circle(p,r,c)        -> ((fst p - r , snd p - r),(fst p + r , snd p + r))
    | Rectangle(p1,p2,c)   -> (p1,p2)
    | Triangle(p1,p2,p3,c) -> ((mintricX(p1,p2,p3),mintricY(p1,p2,p3)),(maxtricX(p1,p2,p3),maxtricY(p1,p2,p3)))
    | Mix(P1,P2)           ->
        let p1 = boundingBox(P1);
        let p2 = boundingBox(P2);
        let min =
            match (fst p1,fst p2) with
            | ((x1,y1),(x2,y2)) when x1 <= x2 && y1 <= y2 -> (x1,y1)
            | ((x1,y1),(x2,y2)) when x1 <= x2 && y1 > y2  -> (x1,y2)
            | ((x1,y1),(x2,y2)) when x1 > x2 && y1 <= y2  -> (x2,y1)
            | ((x1,y1),(x2,y2))                           -> (x2,y2)
        let max =
            match (snd p1,snd p2) with
            | ((x1,y1),(x2,y2)) when x1 >= x2 && y1 >= y2 -> (x1,y1)
            | ((x1,y1),(x2,y2)) when x1 >= x2 && y1 < y2  -> (x1,y2)
            | ((x1,y1),(x2,y2)) when x1 < x2 && y1 >= y2  -> (x2,y1)
            | ((x1,y1),(x2,y2))                           -> (x2,y2)
        (min,max)

        

//8g.1 making of fighouse
let figHouse =
    Mix(
        (Mix(
            (Rectangle((20,70),(80,120),(255,0,0))),
            (Triangle((15,80),(45,30),(85,70),(0,0,255))))),
        (Circle((70,20),10,(255,255,0))))


boundingBox(figHouse) |> printfn "%A"

// 8g.4 Making figHouse.png
makePicture "figHouse.png" figHouse (100,150)

