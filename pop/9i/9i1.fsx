open System
    
//Replaces given keyword "needle" with "replace" in the given file
let fileReplace (fileName : string) (needle : string) (replace : string) : unit =
    let reader =
        try
            IO.File.OpenText(fileName)
        with _ -> failwithf "File: \"%s\" not found" fileName
        
    //Mutable string that will contain entire unedited text
    let mutable a = ""
    while not reader.EndOfStream do
        a <- a + reader.ReadLine() + "\n"
    reader.Close()

    let regn = (Text.RegularExpressions.Regex needle)

    //Replaces old file
    let repText =
        IO.File.CreateText fileName

    //Writes the string with all instances of needle replaced
    repText.WriteLine(regn.Replace(a,replace))
    repText.Close()

//Much simpler, better code that doesn't use WriteLine and ReadLine
let simpleFileReplace (fileName : string) (needle : string) (replace : string) =
    IO.File.ReadAllLines fileName
    |> Array.map (fun nline -> nline.Replace(needle, replace))
    |> fun newText -> IO.File.WriteAllLines(fileName, newText)


// Small function that creates a new test file that looks like this:
// abcABCdefDEF
// abcABCdefDEF
let newTest (name : string) =
    let testText =
        IO.File.CreateText name
    testText.Write("abcABCdefDEF\nabcABCdefDEF")
    testText.Close()


//Testing
let testName = "test.txt"

newTest testName

fileReplace testName "abc" "def"

simpleFileReplace testName "abc" "def"

let fileRepTest file =
    try
        fileReplace file "abc" "def"
    with Failure a -> printfn "%s" a

fileRepTest "nonexistent.txt"
