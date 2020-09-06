open System

let url2Stream url =
    let uri = System.Uri url
    let request = System.Net.WebRequest.Create uri
    let response = request.GetResponse()
    response.GetResponseStream()

/// Read all contents of a web page as a string
let readUrl url =
    let stream = url2Stream url
    let reader = new System.IO.StreamReader(stream)
    reader.ReadToEnd ()

// printfn "%A" <| (readUrl url).[0..200]

let countLinks (url : string) : int =
    let htmlText =
        try readUrl url
        with _ -> ""
    let textList = Seq.toList htmlText
    let rec counter (input : char list) : int =
        match input with
        | '<' :: 'a' :: ' ' :: tail -> 1 + (counter tail)
        | head :: tail       -> counter tail
        | []                 -> 0

    counter textList

let fsh = "http://fsharp.org"
let google = "http://google.com"
let question = "www.doesnotexist.com"
printfn "%i" <| countLinks fsh
printfn "%i" <| countLinks google
printfn "%i" <| countLinks question
printfn "%i" <| countLinks "test"
