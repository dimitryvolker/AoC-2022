[<AutoOpen>]
module AoC2022.Helpers.Stopwatch

let track f = 
    let timer: System.Diagnostics.Stopwatch = new System.Diagnostics.Stopwatch()
    timer.Start()
    let returnValue = f()
    printfn "-- Elapsed Time: %i ms" timer.ElapsedMilliseconds
    printfn ""
    returnValue