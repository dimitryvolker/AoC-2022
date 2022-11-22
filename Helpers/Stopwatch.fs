module AoC2022.Helpers.Stopwatch
open System.IO

let track f = 
    let timer = new System.Diagnostics.Stopwatch()
    timer.Start()
    let returnValue = f()
    printfn "Elapsed Time: %i ms" timer.ElapsedMilliseconds
    returnValue