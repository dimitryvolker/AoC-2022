module AoC2022.Puzzle7

open System.IO
open AoC2022.CustomTypes.Tree

let rec determineDirectorySizes
    (
        currentNode: Node,
        sizeThreshold: int,
        results: list<(string * int)>
    ) : list<(string * int)> =
    let mutable tmp = results

    if
        currentNode.Size <= sizeThreshold
        && currentNode.Children.IsEmpty = false
        && (List.contains (currentNode.Name, currentNode.Size) tmp) = false
    then
        tmp <- (currentNode.Name, currentNode.Size) :: tmp

    if currentNode.Children.IsEmpty = false then
        for child in currentNode.Children do
            tmp <- determineDirectorySizes (child, sizeThreshold, tmp) @ tmp |> List.distinct

    tmp

let solve () =
    printfn "Day 7: No Space Left On Device  --"
    let input = File.ReadLines("Puzzle7/input.txt") |> Seq.skip 1
    let tree = new Node()
    tree.Name <- "/"

    let mutable currentNode: Option<Node> = Some tree

    // Build that tree
    for data in input do
        match data with
        | data when data.StartsWith("$ cd /") -> currentNode <- Some tree
        | data when data.StartsWith("$ cd ..") -> currentNode <- currentNode.Value.Parent
        | data when data.StartsWith("$ cd") -> currentNode <- Some(currentNode.Value.FindChild(data.Split(' ')[2]))
        | data when data.StartsWith("$ ls") -> data |> ignore
        | data when data.StartsWith("dir") ->
            let dirNode = new Node()
            dirNode.Parent <- currentNode
            dirNode.Name <- data.Split(' ')[1]
            currentNode.Value.AddChild(dirNode)
        | _ ->
            let fileNode = new Node()
            fileNode.Parent <- currentNode
            fileNode.Name <- data.Split(' ')[1]
            fileNode.SetSize(data.Split(' ')[0] |> int)
            currentNode.Value.AddChild(fileNode)

    let results =
        determineDirectorySizes (tree, 100000, [])
        |> Seq.map (fun (x, y) -> y)
        |> Seq.sum

    printfn "\t The sum of the total sizes of directories with size threshold 100000: %d" results

    let neededSize = (30000000 - (70000000 - tree.Size))
    let smallestDir =
        determineDirectorySizes (tree, System.Int32.MaxValue, [])
        |> Seq.filter (fun (x, y) -> y > neededSize)
        |> Seq.sortBy (fun (x, y) -> y)
        |> Seq.head

    printfn "\t Smallest directory to delete is: %A" smallestDir