module AoC2022.Puzzle1
open System.IO
open Microsoft.FSharp.Collections

let solve() =
    let mutable elves = [0];
    let mutable calorieCount = 0;

    for s in File.ReadLines("Puzzle1/input.txt") do
        match System.Int32.TryParse s with
        | true, value -> calorieCount <- calorieCount + value
        | _ -> elves <- calorieCount :: elves; calorieCount <- 0;

    let highestCalories = elves |> List.sortDescending |> List.head;
    printfn "\t Highest calorie count: %d" highestCalories;
    
    let topThreeElfCalories  = elves |> List.sortDescending |> List.take 3 |> List.sum;
    printfn "\t Total of the three highest calorie elves: %d" topThreeElfCalories
