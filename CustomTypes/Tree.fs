module AoC2022.CustomTypes.Tree
open System

[<AllowNullLiteral>]
type Node() =
    let mutable children : list<Node> = [];
    let mutable name: string = "";
    let mutable size: int = 0;
    let mutable parent: Option<Node> = None;

    member this.Name
        with get () = name
        and set (value) = name <- value

    member this.Size with get () = size;

    member this.Parent
        with get () = parent
        and set (value : Option<Node>) = parent <- value

    member this.Children = children;

    member this.AddChild(node: Node) = 
        children <- node :: children;

    member this.SetSize(newSize: int) =
        size <- size + newSize;
        if this.Parent.IsSome then
            this.Parent.Value.SetSize(newSize)

    member this.FindChild(name: string) = 
        children |> List.find(fun x -> x.Name = name)