module AoC2022.Puzzle9
open System.IO
open AoC2022.CustomTypes.Matrix
open System

let inline charToInt c = int c - int '0'

// let rec moveRope (direction: char, rope: list<(int*int)>, segment: int, prevSegPos:(int*int)): 





let solve () =
    printfn "Day 9: Rope Bridge  --"
    let input = File.ReadLines("Puzzle9/input.txt") |> Seq.map (fun x -> (x[0], (x.Substring(1) |> int) ))
    let mutable positions: list<(int * int)> = []
    
    let mutable hPos = (0,0)
    let mutable tPos = (0,0)

    for c in input do
        let direction = fst c
        let amount = snd c

        for i = 0 to (amount - 1) do
            let prevH: int * int = hPos;

            // Move the head
            match direction with
            | 'R' -> hPos <- (fst hPos + 1, snd hPos)
            | 'L' -> hPos <- (fst hPos - 1, snd hPos)
            | 'U' -> hPos <- (fst hPos, snd hPos + 1)
            | 'D' -> hPos <- (fst hPos, snd hPos - 1)
            | _ -> hPos |> ignore

            let distance = (max (abs (fst hPos - fst tPos)) (abs(snd hPos - snd tPos)))
            if distance > 1 then tPos <- prevH
            positions <- tPos :: positions

    printfn "Tail unique positions: %d" (positions |> List.distinct |> List.length)
