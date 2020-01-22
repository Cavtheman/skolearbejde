module Draw

#load "player.fsx"
#load "cards.fsx"

open Player
open Card

let suit = function
    | s when s="S" -> "\u2660"
    | s when s="C" -> "\u2663"
    | s when s="D" -> "\u2666"
    | _ -> "\u2665"

let clubs1  = ["|A _  |";"| ( ) |";"|(_'_)|";"|  |  |";"|____V|"]
let clubsJ  = ["|J  ww|";"| o {)|";"|o o% |";"| | % |";"|__%%[|"]
let clubsQ  = ["|Q  ww|";"| o {(|";"|o o%%|";"| |%%%|";"|_%%%O|"]
let clubsK  = ["|K  WW|";"| o {)|";"|o o%%|";"| |%%%|";"|_%%%>|"]


let diamond1  = ["|A ^  |";"| / \ |";"| \ / |";"|  .  |";"|____V|"]
let diamondJ  = ["|J  ww|";"| /\{)|";"| \/% |";"|   % |";"|__%%[|"]
let diamondQ  = ["|Q  ww|";"| /\{(|";"| \/%%|";"|  %%%|";"|_%%%O|"]
let diamondK  = ["|K  WW|";"| /\{)|";"| \/%%|";"|  %%%|";"|_%%%>|"] 


let spades1  = ["|A .  |";"| /.\ |";"|(_._)|";"|  |  |";"|____V|"]
let spadesJ  = ["|J  ww|";"| ^ {)|";"|(.)% |";"| | % |";"|__%%[|"]
let spadesQ  = ["|Q  ww|";"| ^ {(|";"|(.)%%|";"| |%%%|";"|_%%%O|"]
let spadesK  = ["|K  WW|";"| ^ {)|";"|(.)%%|";"| |%%%|";"|_%%%>|"]


let hearth1  = ["|A_ _ |";"|( v )|";"| \ / |";"|  .  |";"|____V|"]
let hearthJ  = ["|J  ww|";"|   {)|";"|(v)% |";"| v % |";"|__%%[|"]
let hearthQ  = ["|Q  ww|";"|   {(|";"|(v)%%|";"| v%%%|";"|_%%%O|"]
let hearthK  = ["|K  WW|";"|   {)|";"|(v)%%|";"| v%%%|";"|_%%%>|"]

let card2 (s:string)  = ["|2    |";"|  "+s+"  |";"|     |";"|  "+s+"  |";"|____Z|"]
let card3 (s:string)  = ["|3    |";"| "+s+" "+s+" |";"|     |";"|  "+s+"  |";"|____E|"]
let card4 (s:string)  = ["|4    |";"| "+s+" "+s+" |";"|     |";"| "+s+" "+s+" |";"|____h|"]
let card5 (s:string)  = ["|5    |";"| "+s+" "+s+" |";"|  "+s+"  |";"| "+s+" "+s+" |";"|____S|"]
let card6 (s:string)  = ["|6    |";"| "+s+" "+s+" |";"| "+s+" "+s+" |";"| "+s+" "+s+" |";"|____9|"]
let card7 (s:string)  = ["|7    |";"| "+s+" "+s+" |";"|"+s+" "+s+" "+s+"|";"| "+s+" "+s+" |";"|____L|"]
let card8 (s:string)  = ["|8    |";"|"+s+" "+s+" "+s+"|";"| "+s+" "+s+" |";"|"+s+" "+s+" "+s+"|";"|____8|"]
let card9 (s:string)  = ["|9    |";"|"+s+" "+s+" "+s+"|";"|"+s+" "+s+" "+s+"|";"|"+s+" "+s+" "+s+"|";"|____6|"]
let card10 (s:string) = ["|10 "+s+" |";"|"+s+" "+s+" "+s+"|";"|"+s+" "+s+" "+s+"|";"|"+s+" "+s+" "+s+"|";"|___0I|"]


let drawCard (i:int) = function
    | (n,s) when n=2         -> printf " %s" (card2 (suit s)).[i]
    | (n,s) when n=3         -> printf " %s" (card3 (suit s)).[i]
    | (n,s) when n=4         -> printf " %s" (card4 (suit s)).[i]
    | (n,s) when n=5         -> printf " %s" (card5 (suit s)).[i]
    | (n,s) when n=6         -> printf " %s" (card6 (suit s)).[i]
    | (n,s) when n=7         -> printf " %s" (card7 (suit s)).[i]
    | (n,s) when n=8         -> printf " %s" (card8 (suit s)).[i]
    | (n,s) when n=9         -> printf " %s" (card9 (suit s)).[i]
    | (n,s) when n=10        -> printf " %s" (card10 (suit s)).[i]
    | (n,s) when n=1&&s="C"  -> printf " %s" clubs1.[i] 
    | (n,s) when n=1&&s="D"  -> printf " %s" diamond1.[i]
    | (n,s) when n=1&&s="S"  -> printf " %s" spades1.[i]
    | (n,s) when n=1&&s="H"  -> printf " %s" hearth1.[i]
    | (n,s) when n=11&&s="C" -> printf " %s" clubsJ.[i] 
    | (n,s) when n=11&&s="D" -> printf " %s" diamondJ.[i]
    | (n,s) when n=11&&s="S" -> printf " %s" spadesJ.[i]
    | (n,s) when n=11&&s="H" -> printf " %s" hearthJ.[i]
    | (n,s) when n=12&&s="C" -> printf " %s" clubsQ.[i] 
    | (n,s) when n=12&&s="D" -> printf " %s" diamondQ.[i]
    | (n,s) when n=12&&s="S" -> printf " %s" spadesQ.[i]
    | (n,s) when n=12&&s="H" -> printf " %s" hearthQ.[i]
    | (n,s) when n=13&&s="C" -> printf " %s" clubsK.[i] 
    | (n,s) when n=13&&s="D" -> printf " %s" diamondK.[i]
    | (n,s) when n=13&&s="S" -> printf " %s" spadesK.[i]
    | (n,s)                  -> printf " %s" hearthK.[i]


let drawTop n =
    for i=0 to n do
         printf "  _____ "

(*let drawStartHand (p:Player list) =
    let playerSize = p.Length
    for i=1 to playerSize/2 do
        printfn "%st"
    for i=1 to 3 do)*)
        

let drawHand (hand:Card list) =
    let handSize = hand.Length-1
    drawTop handSize
    printfn ""
    for i = 0 to 4 do
        for j = 0 to handSize do
            drawCard i (hand.[j].getTrueValue,hand.[j].getSuit)
        printfn ""
    printfn ""
