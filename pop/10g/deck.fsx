module Deck

#load "cards.fsx"
open Card

type Deck() =
    let mutable deckList:Card list = []
    let mutable index = 0
    
    let generateDeck (s:string) =
        for i=13 downto 1 do
            deckList <- Card(i,s) :: deckList

    let addSuits (s1,s2,s3,s4) =
        generateDeck s1
        generateDeck s2
        generateDeck s3
        generateDeck s4
    
    do addSuits("H","S","C","D")


    let rng = new System.Random()

    let shuffle (org:_[]) = 
        let arr = Array.copy org
        let max = (arr.Length - 1)
        let randomSwap (arr:_[]) i =
            let pos = rng.Next(max)
            let tmp = arr.[pos]
            arr.[pos] <- arr.[i]
            arr.[i] <- tmp
            arr
   
        [|0..max|] |> Array.fold randomSwap arr
    
    member this.getDeck = deckList

    member this.getIndex = index
    
    member this.setIndex n =
        index <- index + n
