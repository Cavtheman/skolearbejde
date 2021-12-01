type DepthWindow = [Maybe Int]

slide :: DepthWindow -> Int -> DepthWindow
slide window newDepth =
  case window of
    []   -> []
    _:xs -> xs ++ [return newDepth]

sonarFolder :: (Int, DepthWindow) -> Int -> (Int, DepthWindow)
sonarFolder (count, prev) x =
  let newWindow = slide prev x
      prevS = sequence prev
      newS = sequence newWindow
  in case (newS, prevS) of
    (Just a, Just b) | sum a > sum b -> (count + 1, newWindow)
    _ -> (count, newWindow)

readLines :: FilePath -> IO [String]
readLines = fmap lines . readFile

sonarSweep :: String -> Int -> IO Int
sonarSweep filename windowLength = do
  contents <- readLines filename
  let nums = map read contents
      initWindow = take windowLength $ cycle [Nothing]
  return $ fst $ foldl sonarFolder (0, initWindow) nums

main :: IO ()
main = do
  res <- sonarSweep "input.txt" 3
  print res
