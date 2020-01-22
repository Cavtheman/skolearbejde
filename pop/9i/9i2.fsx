open System

//functions that count the number of links on a specified web address
let rec countLinks (url : string) : int =
    //helping functions that open the requested webpage for reading
    let urlStream =
        let uri = Uri ("https://" + url)
        let request = Net.WebRequest.Create uri
        let response = request.GetResponse ()
        response.GetResponseStream ()
    let readUrl =
        let stream = urlStream
        let reader = new IO.StreamReader(stream)
        reader.ReadToEnd ()

    //Defines the regular expression to be counted and returns the number of them
    let isLink = Text.RegularExpressions.Regex("(<a)")
    (isLink.Matches readUrl).Count
    
printfn "Number of links on %s: %i" "reddit.com" (countLinks "reddit.com") 
