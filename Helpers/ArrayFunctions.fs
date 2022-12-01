[<AutoOpen>]
module AoC2022.Helpers.ArrayFunctions

let splitSeq lines =
    let mutable blocks = []
    let mutable currentBlock = []
    
    for s in lines do
        match s with
        | "" -> blocks <- List.rev currentBlock :: blocks; currentBlock <- []
        | _ -> currentBlock <- s :: currentBlock

    List.rev (currentBlock :: blocks)