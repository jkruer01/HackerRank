open System

let main _ = 
    let numberOfLines = Console.ReadLine () |> int
    [|1 .. numberOfLines|]
    |> Array.map(fun item -> Console.ReadLine().ToCharArray())
    |> Array.iter(fun item ->
        item
        |> Array.chunkBySize 2 
        |> Array.iter(fun item -> printf "%c%c" item.[1] item.[0])
        printfn "")

    0 // return an integer exit code

main ()