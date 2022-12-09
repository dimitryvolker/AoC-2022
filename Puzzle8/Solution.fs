module AoC2022.Puzzle8

open System.IO
open AoC2022.CustomTypes.Matrix

let inline charToInt c = int c - int '0'

let scanAxis (row: int[], startingPosition: int) =
    let subject = row[startingPosition]
    let mutable axisBack = 0
    let mutable axisForward = 0

    let mutable visibileBackwards = true
    let mutable visibileForwards = true

    let mutable index = if startingPosition > 0 then startingPosition - 1 else 0
    let mutable cancellationToken = true

    while (index >= 0) && cancellationToken && startingPosition > 0 do
        axisBack <- axisBack + 1

        if row[index] >= subject && (startingPosition = 0) = false then
            visibileBackwards <- false
            cancellationToken <- false

        index <- index - 1

    index <- startingPosition + 1
    cancellationToken <- true

    while (index < row.Length) && cancellationToken do
        axisForward <- axisForward + 1

        if row[index] >= subject && (startingPosition < row.Length) then
            visibileForwards <- false
            cancellationToken <- false

        index <- index + 1

    (visibileBackwards || visibileForwards, axisBack * axisForward)


let solve () =
    printfn "Day 8: Treetop Tree House  --"
    let input = File.ReadLines("Puzzle8/input.txt") |> Seq.toArray

    let rowSize = input |> Seq.length
    let columnSize = input |> Seq.head |> Seq.toArray |> Array.length
    let treeMatrix = new Matrix<int>(rowSize, columnSize)

    // Load data
    for i in 0 .. (rowSize - 1) do
        let rowOfTrees = input[i] |> Seq.toArray |> Array.map charToInt

        for j in 0 .. (columnSize - 1) do
            treeMatrix[i, j] <- rowOfTrees[j]

    // Check if tree is visible
    let mutable visibleTrees: list<(int * int)> = []
    let rowLimit = rowSize - 1
    let columnLimit = columnSize - 1

    for rowIndex = 0 to rowLimit do
        let rowOfTrees = treeMatrix[rowIndex, *]

        for columnIndex = 0 to columnLimit do
            let horizontalResult = scanAxis (rowOfTrees, columnIndex)
            let verticalResult = scanAxis (treeMatrix[*, columnIndex], rowIndex)

            if fst horizontalResult || fst verticalResult then
                visibleTrees <- visibleTrees @ [ (rowOfTrees[columnIndex], (snd horizontalResult * snd verticalResult)) ]

    printfn "\t Trees you can see: %d" visibleTrees.Length

    printfn
        "\t Highest scenic score: %A"
        (visibleTrees |> List.map (fun (x, y) -> y) |> List.sortDescending |> List.head)