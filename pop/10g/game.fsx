module Game

#load "player.fsx"
#load "deck.fsx"
#load "draw.fsx"

open Player
open Deck
open Draw
open System

type Game(p:Player list) =

    let pList = p
    let pLen = pList.Length-1

    let d = Deck()
    let deck = d.getDeck
    
    member this.run =
        printfn "Let the games begin!!"

        // Deal 2 cards to each player 
        for i=0 to pLen do
            pList.[i].addCard deck.[d.getIndex]
            d.setIndex 1

            pList.[i].addCard deck.[d.getIndex]
            d.setIndex 1

        // Prints the value of a players hand
        let printValue (p:Player) =
            match p.getVal with
            | n when n > 21 -> printfn "Collected value is %d" n
                               printfn "%s is bust!" p.getName
            | n when n = 21 -> printfn "%s's collected value is 21!" p.getName
            | n             -> printfn "%s's collected value is %d" p.getName n


        let winner (p:Player List) =
            let mutable high = 0
            let mutable winners = []
            
            for i = 0 to pLen do
                let score = p.[i].getVal
                if score > high && score < 22 then
                    high <- p.[i].getVal
                    
            for i=0 to pLen do
                if p.[i].getVal = high then
                    winners <- p.[i].getName :: winners
                    
            let printWinners = function
                | n when n = 1 ->
                    printfn "%s wins with a score of %d!" winners.[0] high
                | n when n = 2 -> printfn "2 winners %s & %s each with score of %d" winners.[0] winners.[1] high
                | _            -> printfn "no winners"

            printWinners (winners.Length-1)



        let rec hitOrStand (i:int) = function
            | s when s="q"||s="exit"-> printfn "Goodbye!"  
            | s when s="s"          -> i |> stand
            | s when s="h"          -> pList.[i].addCard deck.[d.getIndex]
                                       d.setIndex 1
                                       drawHand pList.[i].getHand
                                       printValue pList.[i]
                                       i |> hit
            | _ ->                     printfn "Invalid input, try again"
                                       Console.ReadLine() |> hitOrStand i

        and stand = function 
            | i when i < pLen -> printfn "%s's turn:" pList.[i+1].getName
                                 printValue pList.[i+1]
                                 Console.ReadLine() |> hitOrStand (i+1)
            | _               -> printfn "Dealers turn:"
                                 dealersTurn pList.[0].getVal

        and hit = function
            | i when i < pLen && pList.[i].getVal > 20 ->
                                 printfn "%s turn:" pList.[i+1].getName
                                 drawHand pList.[i+1].getHand
                                 printValue pList.[i+1]
                                 Console.ReadLine() |> hitOrStand (i+1)
            | i when i = pLen && pList.[i].getVal > 20 ->
                                 printfn "Dealers turn:"
                                 dealersTurn pList.[0].getVal
            | i                                        ->
                                 Console.ReadLine() |> hitOrStand i

        and dealersTurn = function
            | n when n > 16 -> printfn "Dealers stops at %d" n
                               winner pList
            | _             -> pList.[0].addCard deck.[d.getIndex]
                               d.setIndex 1
                               printValue pList.[0]
                               dealersTurn pList.[0].getVal
        

        drawHand pList.[1].getHand
        printValue pList.[1]
        printfn "%s turn, (h/hit) (s/stand):" pList.[1].getName
        Console.ReadLine() |> hitOrStand 1


        printfn "Type n for new game, or p to return to player selection"
        
        let rec endMenu = function
            | s when s="q"||s="exit"-> printfn "Goodbye!"
            | s when s = "n"        -> let newGame = Game(pList)
                                       newGame.run
            | s when s = "p"        -> let newStart = StartMenu()
                                       newStart.run
            | _                     -> printfn "Invalid input, try again!"
        Console.ReadLine() |> endMenu

and StartMenu() =

    member this.run =
        printfn "Choose between 1 to 5 players:"
        let p = Players()
        Console.ReadLine() |> p.select

        let rec nameOption = function
            | s when s="q"||s="exit"-> printfn "Goodbye!"
            | s when s="y"||s="yes" -> p.setNames
            | s when s="n"||s="no"  -> printfn "Players set to default names"
            | _                     -> printfn "Invalid input, try again!" 
        
        printfn "Would you like to name the players ?"
        Console.ReadLine() |> nameOption

        let newGame = Game(p.getPlayers)
        newGame.run

