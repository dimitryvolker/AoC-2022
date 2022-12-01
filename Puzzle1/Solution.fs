module AoC2022.Puzzle1
open System.IO
open Microsoft.FSharp.Collections

let solve () = 
    printfn "Day 1: Calorie Counting  --"
    let fileLines = File.ReadLines("Puzzle1/input.txt");
    let elves = fileLines |> AoC2022.Helpers.ArrayFunctions.splitSeq
    
    // Solution 1 
    let mutable highestCalories = 0;
    for elf in elves do
        let calories = elf |> Seq.map int |> Seq.sum
        highestCalories <- if highestCalories < calories then calories else highestCalories

    printfn "\t Highest calorie count: %d" highestCalories;

    // Solution 2
    let mutable elfCalories = [0];
    for elf in elves do
        let calories = elf |> Seq.map int |> Seq.sum
        elfCalories <- calories :: elfCalories

    let topThreeElfCalories = elfCalories
                                    |> List.sortDescending
                                    |> List.take 3
                                    |> List.sum

    printfn "\t Total of the three highest calorie elves: %d" topThreeElfCalories
