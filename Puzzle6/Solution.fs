module AoC2022.Puzzle6
open System.IO

let findMarker (input: list<list<char>>,i: int): int = 
    let mutable result = 0;
    let mutable index = 0;
    let mutable cancelationToken = true;

    while cancelationToken do 
        let distinct = input[index] |> List.distinct
        if input[index].Length = distinct.Length then result <- index + i;  cancelationToken <- false

        index <- index + 1

    result


let solve() = 
    printfn "Day 6: Tuning Trouble  --"

    let input =
        File.ReadLines("Puzzle6/input.txt") 
        |> Seq.head 
        |> Seq.toList

    let startSignal = input |> List.windowed 4
    printfn "\t First start-of-packet marker on charater number: %d" (findMarker(startSignal, 4))
    
    let startSignal = input |> List.windowed 14
    printfn "\t First start-of-message marker on charater number: %d" (findMarker(startSignal, 14))