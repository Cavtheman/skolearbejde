module Player
#load "chess.fsx"

//open System
open Chess

let convertLetter = function
    | 'a' | 'A' -> 0
    | 'b' | 'B' -> 1
    | 'c' | 'C' -> 2
    | 'd' | 'D' -> 3
    | 'e' | 'E' -> 4
    | 'f' | 'F' -> 5
    | 'g' | 'G' -> 6
    | _         -> 7 

[<AbstractClass>]
type player () =
  
    abstract member pColor:Color 
    abstract member nextMove:Board -> unit
    abstract member move:Board -> unit
    
type human (c:Color) =
    inherit player()
    override this.pColor = c
    override this.nextMove(b:Board) =
        
        //User's pieces
        let userPieces =(b.returnPieces(this.pColor))
        printfn "User's piece: %A" userPieces
        //prompt user for piece

        if userPieces.Length > 1 then 
            printfn "choose a piece to show moves for:"

            let rec findPiece (s:string, i:int) =
                match (s, i) with
                    | (s,i) when System.String.Equals(s,userPieces.[i].nameOfType, System.StringComparison.CurrentCultureIgnoreCase)
                                 -> userPieces.[i]
                    | (s,i)     -> findPiece (s,i-1) 
        
        
            let rec uP = function
                 | 107 -> findPiece("k",userPieces.Length-1).availableMoves(b) |> printfn "%A" 
                 | 114 -> findPiece("r",userPieces.Length-1).availableMoves(b) |> printfn "%A"
                 | _   -> printfn "No such piece available, try again!!!"
                          System.Console.Read() |> uP
            
            System.Console.Read() |>  uP
        else
            printfn "You only have a King left."
            printfn "Available moves for the King is:"
            userPieces.[0].availableMoves(b) |> printfn "%A"


    override this.move (b:Board) =
        let input = System.Console.ReadLine() 
        if input.Length = 5 then
            let pos1 = (input.[0] |> convertLetter, int (input.[1])-1) 
            let pos2 = (input.[3] |> convertLetter, int (input.[4])-1)

            b.move(pos1)(pos2)
            
        else
            printfn "Invalid input, try again!"
            this.move b
    
type computer (c:Color) =
    inherit player ()
    override this.pColor = c
    override this.nextMove(b:Board) =
         let rng = System.Random()
         let comPieces =(b.returnPieces(this.pColor))
         comPieces.[rng.Next comPieces.Length].availableMoves(b) |> printfn"%A"
         
    override this.move (b:Board) =
        let rng = System.Random()
        let comPieces =(b.returnPieces(this.pColor))
        let thePiece = comPieces.[rng.Next comPieces.Length]   
        let pos1 = thePiece.position
        let aMoves = thePiece.availableMoves(b)
        let pos2 =  (fst aMoves).[rng.Next (fst aMoves).Length]

        b.move(pos1 |> fun (Some(x,y)) -> (x,y))(pos2)
