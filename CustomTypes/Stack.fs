module AoC2022.CustomTypes.Stack

// Stack FiLo
type Stack<'a>() = 
    let mutable content : list<'a> = [];

    member this.Append(x) = content <- content @ [x]

    member this.AppendMany(x : list<'a>) = 
        for item in x do
            content <- content @ [item]

    member this.Push(x) = content <-  x :: content

    member this.PushMany(x : list<'a>) =
        for item in x do
            content <- item :: content

    member this.Pop() : 'a =
            let result = content[content.Length - 1]
            content <- List.removeAt (content.Length - 1) content
            result

    member this.PopMany(count: int) : list<'a> =
            let mutable result: list<'a> = []
            for i = 0 to (count - 1) do
                let item = content[content.Length - 1]
                content <- List.removeAt (content.Length - 1) content
                result <- item :: result;
            
            result

    member this.Print() = 
            printfn "%A" content

    member this.Top : 'a = 
            content[content.Length - 1]