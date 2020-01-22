let xs = [1;3;5;7;4;3;7;3;]


let mult x (ls : int list)= 
    let mutable counter = 0
    for i = 0 to ls.Length - 1 do
        if ls.[i] = x then
            counter <- counter + 1
    counter |> printfn "%i"


mult 3 xs


let f acc elem x =
    if elem = x then
        acc + 1
    else acc


let mult1 x = List.fold (fun a e -> f a e x) 0 xs


mult1 (System.Console.ReadLine()|> int)|> printfn "%i"

