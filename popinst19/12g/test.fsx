type testClass() =
    member this.move(a : int * int, b : int * int) =
        printfn "%A, %A" a b


type inheritClass(x : int ) =
    inherit testClass()
    let int test = x
    member this.newMove((a : int * int), b : int * int) = this.move(a, b)

let thing = new testClass()
let whatever = new inheritClass(1)

thing.move((1,1), (2,2))
whatever.move((1,1), (2,2))
whatever.newMove((1,1), (2,2))
