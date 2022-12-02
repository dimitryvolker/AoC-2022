module AoC2022.Puzzle2

open System.IO

let determineFinalResults (input: list<int * int>) =
    let mutable result = 0

    for playerA, playerB in input do
        match abs (playerB - playerA) with
        | 0 -> result <- result + (3 + playerB - 64)
        | 1 when playerB > playerA -> result <- result + (6 + playerB - 64)
        | 2 when playerB < playerA -> result <- result + (6 + playerB - 64)
        | _ -> result <- result + (playerB - 64)

    result

let solve () =
    printfn "Day 2: Rock Paper Scissors  --"

    // Solution 1
    let duels =
        File.ReadLines("Puzzle2/input.txt")
        |> Seq.map (fun x -> (x.Split(' ')[0] |> char |> int, (x.Split(' ')[1] |> char |> int) - 23))
        |> Seq.toList

    printfn "\t Duels result: %d" (determineFinalResults duels)

    let mutable newStrategy: list<int * int> = []

    for opponent, strategy in duels do
        match (strategy + 23) |> char with
        | 'Z' when opponent = 67 -> newStrategy <- (opponent, opponent - 2) :: newStrategy
        | 'Z' -> newStrategy <- (opponent, opponent + 1) :: newStrategy
        | 'X' when opponent = 65 -> newStrategy <- (opponent, opponent + 2) :: newStrategy
        | 'X' -> newStrategy <- (opponent, opponent - 1) :: newStrategy
        | _ -> newStrategy <- (opponent, opponent) :: newStrategy


    printfn "\t Duels result: %d" (determineFinalResults newStrategy)
