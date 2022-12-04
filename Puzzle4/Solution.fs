module AoC2022.Puzzle4

open System.IO

let solve () =
    printfn "Day 4: Camp Cleanup  --"

    let rangePairs =
        File.ReadLines("Puzzle4/input.txt")
        |> Seq.map (fun x -> x.Split ',')
        |> Seq.map (fun x -> (x[ 0 ].Split '-', x[ 1 ].Split '-'))
        |> Seq.map (fun (range1, range2) ->
            (range1
             |> Seq.map (fun x -> x |> int)
             |> Seq.toArray
             |> (fun x -> [ x[0] .. x[1] ])
             |> Set.ofList,
             range2
             |> Seq.map (fun x -> x |> int)
             |> Seq.toArray
             |> (fun x -> [ x[0] .. x[1] ])
             |> Set.ofList))


    // Solution 1
    let fullOverlaps =
        rangePairs
        |> Seq.map (fun (range1, range2) -> range1.IsSubsetOf(range2) || range1.IsSupersetOf(range2))
        |> Seq.filter (fun x -> x)
        |> Seq.length

    printfn "\t Complete ooverlaps found in cleaning jobs: %d" fullOverlaps


    // Solution 2
    let allOverlaps =
        rangePairs
        |> Seq.map (fun (range1, range2) -> Set.intersect range1 range2)
        |> Seq.filter (fun x -> x.Count > 0)
        |> Seq.length

    printfn "\t All overlaps found in cleaning jobs: %d" allOverlaps
