open System

let splitBySpace (input:string) =
    input.Split ' '

let readInputs _ = 
    Console.ReadLine () 
    |> splitBySpace 
    |> Array.map(float)

let calculatedSquaredDistanceFromMean mean number =
    pown (number - mean) 2

let divide denominator (numerator:float) =
    numerator / denominator

let standardDeviation numbers =
    let mean = Array.average numbers
    numbers
    |> Array.fold(fun acc num -> acc + calculatedSquaredDistanceFromMean mean num) 0.
    |> divide (float (Array.length numbers))
    |> sqrt


let main _ = 
    let _ = Console.ReadLine () |> int
    let numbers = readInputs ()

    printfn "%.1f" (standardDeviation numbers)
    
    0 // return an integer exit code

main ()