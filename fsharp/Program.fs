open System

[<EntryPoint>]
let main args =
    [1..5]
    |> Seq.iter (printfn "%d")
    0