module Player
#load "chess.fsx"
open Chess

[<AbstractClass>]
type player (b:bool) =
    
    member this.human = b
    abstract member pColor:Color 
    abstract member nextMove:Board -> unit
    
type human (c:Color) =
    inherit player (true)
    override this.pColor = c
    override this.nextMove(b:Board) =
        //User's pieces
        printfn "User's piece: %A"(b.returnPieces(pColor))
        //prompt user for piece
        printfn "choose a piece to show moves for:" 
        let userPiece = System.Console.ReadLine()
        let uP =
            match userpiece with
                | king -> king.availableMoves(board) 
                | _ -> rook.availableMoves
                
        uP.chessPiece.availableMoves(board)
        
//type computer (c:Color) =
//    inherit player (false)
//    override this.pColor = c
    //override nextMove() =
      //  let rnd = System.Random()
       // rnd.availableMoves(board)

