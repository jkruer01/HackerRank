open System

let main _ = 
    Console.ReadLine()
    |> Seq.distinct
    |> String.Concat
    |> printfn "%s"

    0 // return an integer exit code

main ()