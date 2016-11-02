open System

let factorial n = [1.0m .. n] |> List.fold (*) 1.0m

let evaluate (numberOfTerms) (x:decimal) =
    [1 .. numberOfTerms-1]
    |> List.fold(fun acc term -> acc + ((pown x term) / (factorial (decimal term)))) 1.0m

let main _ = 
    let numberOfInputs = Console.ReadLine () |> int
    [1 .. numberOfInputs]
    |> List.map(fun _ -> Console.ReadLine () |> decimal)
    |> List.map(evaluate 10)
    |> List.iter(printfn "%f")

    Console.ReadLine () |> ignore
    0 // return an integer exit code

main ()