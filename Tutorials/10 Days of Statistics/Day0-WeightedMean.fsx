open System

let splitBySpace (input:string) =
    input.Split ' '

let readInputs _ = 
    Console.ReadLine () 
    |> splitBySpace 
    |> Array.map(float)

let calculateWeightedMean values weights =
    let denominator = Array.sum weights
    let numerator = 
        Array.zip values weights
        |> Array.map(fun (value, weight) -> value * weight)
        |> Array.sum
    numerator / denominator

let main _ = 
    let length = Console.ReadLine () |> int
    let values = readInputs ()
    let weights = readInputs ()
    
    printfn "%.1f" (calculateWeightedMean values weights)
    
    0 // return an integer exit code

main ()