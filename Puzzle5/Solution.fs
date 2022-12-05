module AoC2022.Puzzle5

open System.IO
open System.Text.RegularExpressions
open System
open CustomTypes

let fileName = "Puzzle5/input.txt";

let initStacks () = 
    let initStackData =
        File.ReadAllLines(fileName)
        |> Seq.map (fun x -> x |> Seq.toArray |> Array.chunkBySize 4)
        |> Seq.filter (fun x -> (x.Length > 1 && (x[0][0] = '[' || x[0][0] = ' ' && x[0][1] = ' ')))
        |> Seq.toList

    let mutable stacksFiLo: list<Stack<char[]>> = []

    // Setup the stacks
    for i = 0 to (initStackData[1] |> Seq.length) - 1 do
        let mutable newStack = new Stack<char[]>()

        for stack in initStackData do
            if Set.forall(fun x -> x = ' ') (stack[i] |> Set.ofArray) = false then 
                newStack.Push stack[i]

        stacksFiLo <- stacksFiLo @ [newStack]
    stacksFiLo


let solve () =
    printfn "Day 5: Supply Stacks  --"

    // Read the commands
    let commands = File.ReadAllLines(fileName)
                    |> Seq.filter (fun x -> x.StartsWith("move"))
                    |> Seq.map (fun x ->
                        Regex
                            .Replace(x, "[^0-9 _]", "")
                            .Trim()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries))
                    |> Seq.map (fun x -> x |> Seq.map (fun y -> y |> int) |> Seq.toArray)

    // Load file
    let problem1Stacks = initStacks()

    // Run commands
    for c in commands do
        for i = 0 to  (c[0] - 1) do
            let content = problem1Stacks[c[1] - 1].Pop()
            problem1Stacks[c[2] - 1].Append(content)

    printf "\t Crates on the top of each stack: "   
    for s in problem1Stacks do
        printf "%c" s.Top[1]
    printf "\n"

     // Load file
    let problem2Stacks = initStacks();

     // Run commands
    for c in commands do
        let content = problem2Stacks[c[1] - 1].PopMany(c[0])
        problem2Stacks[c[2] - 1].AppendMany(content)

    printf "\t Crates on the top of each stack: "   
    for s in problem2Stacks do
        printf "%c" s.Top[1]
    printf "\n"