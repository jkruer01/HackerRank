open System

let main _ = 
    Console.ReadLine().ToCharArray()
    |> Array.distinct
    |> Array.map(string)
    |> String.concat ""
    |> printfn "%s"

    0 // return an integer exit code

main ()