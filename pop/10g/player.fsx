module Player
//let cr = System.Console.ReadLine
open System

#load "cards.fsx"
open Card

type Player(name:string) =

    let mutable name = name
    let mutable hand:Card list = []
    let mutable handValue = 0

    member this.getName = name

    member this.setName (newName:string) =
        name <- newName


    member this.getHand = hand

    member this.addCard card =
        hand <- card :: hand

    member this.getVal =
        let handsize = hand.Length-1
        let mutable foundEs = false
        let mutable hVal1 = 0
        let mutable hVal2 = 0
        
        for i=0 to handsize do
            if hand.[i].getValue = 1 && not foundEs then
                hVal1 <- hVal1 + 11
                foundEs <-true
            else
                hVal1 <- hVal1 + hand.[i].getValue

        for i=0 to handsize do
            hVal2 <- hVal2 + hand.[i].getValue

        if hVal1 < 22 then
            hVal1
        else
            hVal2 

type Players() =
    let mutable pList:Player list = []
    let mutable turn = 0

    //Creates players 1-5, and dealer as index 0.
    let numPlayers (n:int) =
        for i=n downto 1 do
            pList <- Player("Player "+sprintf "%d" i) :: pList      
        pList <- Player("Dealer") :: pList
 
    member this.select = function
        | s when s = "q" -> printfn "Goodbye!"
        | s when s = "1" -> printfn "1 player created" ; numPlayers 1
        | s when s = "2" -> printfn "2 players created" ; numPlayers 2
        | s when s = "3" -> printfn "3 players created" ; numPlayers 3
        | s when s = "4" -> printfn "4 players created" ; numPlayers 4
        | s when s = "5" -> printfn "5 players created" ; numPlayers 5
        | _              -> printfn "Ivalid input, try again!"
                            Console.ReadLine() |> this.select

    member this.setNames =
        for i=1 to pList.Length-1 do
            printfn "New name for player %d:" i
            Console.ReadLine() |> pList.[i].setName
            
    member this.getPlayers  =
        pList

    member this.thisTurn = turn
    member this.nextTurn = turn+1
        

//let p = Players()
//p.getPlayers.[2].getName
    
//let rec players = function
//    | i when i = 0 -> [Player("Dealer", i)]
//    | i -> Player("Player "+ sprintf "%d" i, i) :: players (i-1)

//let mutable pList = []
