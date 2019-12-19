let filename = "1.txt"

let reader = System.IO.File.OpenText filename

let rec getInputList (reader : System.IO.StreamReader) =
    if not reader.EndOfStream then
        reader.ReadLine() :: (getInputList reader)
    else
        []

let fuelNums = List.map int (getInputList reader)

//printfn "%A" <| 4/3
let calcFuel (acc : int) (weight : int) =
    (weight / 3)-2 + acc

printfn "%A" <| List.fold calcFuel 0 fuelNums

let rec recCalcFuel (acc : int) (weight : int) =
    if weight > 0 then
        let weight = (weight / 3)-2
        weight + (recCalcFuel acc weight)
    else
        acc

printfn "%A" <| List.fold recCalcFuel 0 fuelNums
