module AoC2022.Puzzle3

open System.IO
open System

let charToScore (character: char) =
    let mutable result = 0

    match Char.IsLower(character) with
    | true -> result <- result + (character |> int) - 96
    | _ -> result <- result + (character |> int) - 38

    result

let solve () =
    printfn "Day 3: Rucksack Reorganization  --"

    // Solution 1
    let duplicateItemScore =
        File.ReadLines("Puzzle3/input.txt")
        |> Seq.map (fun x ->
            (x.[0 .. (x.Length / 2 - 1)] |> Seq.map char |> Set.ofSeq,
             x.[(x.Length / 2) .. x.Length] |> Seq.map char |> Set.ofSeq))
        |> Seq.map (fun (x, y) -> Set.intersect  x  y |> Set.toArray)
        |> Seq.map (fun x -> charToScore x[0])
        |> Seq.sum

    printfn "\t Duplicate item score: %d" duplicateItemScore

    // Solution 2
    let groupScore =
        File.ReadLines("Puzzle3/input.txt")
        |> Seq.map (fun x -> x |> Seq.map char |> Set.ofSeq)
        |> Seq.chunkBySize 3
        |> Seq.map (fun x -> Set.intersectMany x |> Set.toArray)
        |> Seq.map (fun x -> charToScore x[0])
        |> Seq.sum

    printfn "\t Group badge score: %d" groupScore
