module AoC2022.Puzzle6
open System.IO

let rec find(input: list<list<char>>, window: int, offset: int): int =
    let distinct = input[offset] |> List.distinct
    if input[offset].Length = distinct.Length then
        (offset + window)
    else
        find(input, window, (offset + 1))

let solve() = 
    printfn "Day 6: Tuning Trouble  --"

    let input =
        File.ReadLines("Puzzle6/input.txt") 
        |> Seq.head 
        |> Seq.toList

    let startSignal = input |> List.windowed 4
    printfn "\t First start-of-packet marker on charater number: %d" (find(startSignal, 4, 0))
    
    let startSignal = input |> List.windowed 14
    printfn "\t First start-of-message marker on charater number: %d" (find(startSignal, 14, 0))