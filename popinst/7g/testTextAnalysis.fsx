open textAnalysis

//////////////////////////////////////////////////////////////////////
// Given a string, calculate its histogram, generate a new random
// string with a similar histogram, and compare the two.
//let str = "abcdefghijklmnopqrstuvxyz "
let str = "abc z"
printfn "A string: '%s'" str
let hist = histogram str
printfn "A histogram:\n %A" (List.zip alphabet hist)

let ranStr = randomString hist 1000
printfn "A random string: %s" ranStr
let newHist = histogram ranStr
printfn "Resulting histogram:\n %A" (List.zip alphabet newHist)

let str2 = "abc zA;aZ"
printfn "Another string: '%s'" str2
let str2Conv = convertText str2
printfn "Converted to : '%s'" str2Conv

let text = readfile "littleClausAndBigClaus.txt"
printfn "The text: '%s'" text
let textConv = convertText text
printfn "Converted to : '%s'" textConv
let textHist = histogram textConv
printfn "A histogram:\n %A" (List.zip alphabet textHist)
let textRanStr = randomString textHist textConv.Length
//printfn "A random string: %s" textRanStr
let newTextHist = histogram textRanStr
printfn "Resulting histogram:\n %A" (List.zip alphabet newTextHist)
printfn "Sum of squared differences is: %g" (compareHist textHist newTextHist)

let coo = cooccurrence textConv
printfn "A cooccurrence table:\n%A\n" (List.zip alphabet coo)

let fstOrderStr = fstOrderMarkovModel coo textConv.Length
printfn "A random string:\n%s\n" fstOrderStr
let newCoo = cooccurrence  fstOrderStr
printfn "Resulting cooccurrence table:\n%A\n" (List.zip alphabet newCoo)
let cooDist = compareCooccurrence coo newCoo
printfn "Absolute difference: %g\n" cooDist

let wHist = wordHistogram textConv
printfn "A wordHistogram:\n%A\n" wHist
let rndWords = randomWords wHist 10
printfn "Random words:\n%A\n" rndWords
let wCoo = cooccurrenceOfWords textConv
printfn "Word cooccurrences:\n%A\n" wCoo
let rndWords1 = fstOrderMarkovModelOfWords wCoo 10
printfn "1st order random words:\n%A\n" rndWords1
