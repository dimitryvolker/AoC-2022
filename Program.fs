open AoC2022.Helpers.Stopwatch

// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"

let sample() = System.Threading.Thread.Sleep(10003)

track sample

// Ignore close
System.Console.ReadKey() |> ignore