module Player
#load "chess.fsx"
open Chess

[<AbstractClass>]
type player (b:bool) =
    member this.human = b
    abstract member nextMove : unit -> string

type human (p:chessPiece list) =
    inherit player (true)
    override this.nextMove () =
        let input (inp : string) =
            
    let pieces = p
    
type computer (s:string) =
    inherit player (false)
