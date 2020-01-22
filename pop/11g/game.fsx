module Game

#load "chess.fsx"
#load "pieces.fsx"
#load "player.fsx"


open Chess
open Pieces
open Player
open System

let pieces = [|
    king (White) :> chessPiece;
    rook (White) :> chessPiece;
    king (Black) :> chessPiece;
    rook (Black) :> chessPiece |]

let board = Board()
let ramGen = Random()

type game () =
    member this.run =
        printfn "Welcome to simpleChess!"
        printfn "How many human players?"
        
        let mutable players = []
//Lets the user decide between 0,1 and 2 human players
        let rec playerSelect = function
            | 49 -> players <- [human(White) :> player;
                                computer(Black) :> player] 
            | 50 -> players <- [human(White) :> player;
                                human(Black) :> player]
            | 48 -> players <- [computer(White) :> player;
                                computer(Black) :> player]
            | _ -> printfn "Invalid input, try again"
                   Console.Read() |> playerSelect

        Console.Read() |> playerSelect
//Adds king and rook of each color to the board        
        board.[0,0] <- Some pieces.[0]
        board.[1,1] <- Some pieces.[1]
        board.[7,7] <- Some pieces.[2]
        board.[6,6] <- Some pieces.[3]
//Turn loop for the players
//players choose a piece to see moves for
//and move any piece with a move command
//(fx "a1 a2". NOTICE: start and target must be spaced!) 
        let rec playerTurn = function
            | 0 -> printfn "White player turn:"
                   printfn "%A" board
                   players.[0].nextMove(board)
                   players.[0].move(board)
            

                   playerTurn 1
                   
            | _ -> printfn "Black player turn:"
                   printfn "%A" board
                   players.[1].nextMove(board)
                   players.[1].move(board)
                   

                   playerTurn 0
        
        playerTurn 0
