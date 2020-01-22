module Card

type Card(n:int,s:string) =
    let suit = s
    let value = n

    member this.getValue =
        match value with
        | value when value > 10 -> 10
        | _ -> value

    member this.getTrueValue = value
    member this.getSuit = suit
