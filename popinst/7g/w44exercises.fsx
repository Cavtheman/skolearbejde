// 7ø5
type weekday = Monday | Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday

let dayToNumber (day : weekday) : int =
    match day with
    | Monday    -> 1
    | Tuesday   -> 2
    | Wednesday -> 3
    | Thursday  -> 4
    | Friday    -> 5
    | Saturday  -> 6
    | Sunday    -> 7

printfn "%A" <| dayToNumber Monday
printfn "%A" <| dayToNumber Tuesday
printfn "%A" <| dayToNumber Wednesday
printfn "%A" <| dayToNumber Thursday
printfn "%A" <| dayToNumber Friday
printfn "%A" <| dayToNumber Saturday
printfn "%A" <| dayToNumber Sunday

// 7ø6
let nextDay (day : weekday) : weekday =
    let dayNum = dayToNumber day
    match dayNum with
    | 1 -> Tuesday
    | 2 -> Wednesday
    | 3 -> Thursday
    | 4 -> Friday
    | 5 -> Saturday
    | 6 -> Sunday
    | 7 -> Monday

printfn "%A" <| nextDay Monday
printfn "%A" <| nextDay Tuesday
printfn "%A" <| nextDay Wednesday
printfn "%A" <| nextDay Thursday
printfn "%A" <| nextDay Friday
printfn "%A" <| nextDay Saturday
printfn "%A" <| nextDay Sunday

// 7ø7
let numberToDay (dayNum : int) : weekday option =
    match dayNum with
    | 1 -> Some Monday
    | 2 -> Some Tuesday
    | 3 -> Some Wednesday
    | 4 -> Some Thursday
    | 5 -> Some Friday
    | 6 -> Some Saturday
    | 7 -> Some Sunday
    | _ -> None


for i = 0 to 8 do
    printfn "%A" <| numberToDay i
