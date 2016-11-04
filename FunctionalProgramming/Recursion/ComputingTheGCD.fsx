open System

let splitBySpace (input:string) =
    input.Split ' '

let readInputs _ = 
    Console.ReadLine () 
    |> splitBySpace 
    |> Array.map(int64)

let rec greatestCommonDenominator (a:int64) (b:int64) =
    if b = int64(0) then a else greatestCommonDenominator b (a % b)

let main _ = 
    let inputs = readInputs ()
    
    greatestCommonDenominator inputs.[0] inputs.[1]
    |> printfn "%i"

    0 // return an integer exit code

main ()