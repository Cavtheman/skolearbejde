

type student (name : string, number : int) = class
    member this.Name = name
    member this.Number = number
end

let student1 = new student ("test", 10)
printfn "%A" student1.Name
printfn "%A" student1.Number
