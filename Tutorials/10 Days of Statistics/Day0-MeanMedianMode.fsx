open System

let calculateMean array =
    let length = float (Array.length array)
    let sum =
        array
        |> Array.map(float) 
        |> Array.sum
    sum / length

let calculateEvenMedian (array:float[]) =
    let maxIndex =  float (Array.length array - 1)
    let lower = floor (maxIndex / 2.)
    let upper = ceil (maxIndex / 2.)
    (Array.get array (lower |> int) + Array.get array (upper |> int)) / 2.
    
let calculateOddMedian array = 
    Array.get array (Array.length array / 2)

let calculateMedian array =
    let floatArray = Array.map(float) array
    match Array.length array % 2 = 0 with
    | true -> calculateEvenMedian floatArray
    | false -> calculateOddMedian floatArray

let calculateMode array =
    Array.groupBy(id) array
    |> Array.sortByDescending(fun (key, values) -> values.Length, key * -1)
    |> Array.find(fun (key, value) -> true)
    |> fst

let splitBySpace (input:string) =
    input.Split ' '

let main _ = 
    let lengthOfInput = Console.ReadLine () |> int

    let sortedArray = 
        Console.ReadLine () 
        |> splitBySpace 
        |> Array.map(int)
        |> Array.sort
    
    printfn "%f" (calculateMean sortedArray)
    printfn "%f" (calculateMedian sortedArray)
    printfn "%i" (calculateMode sortedArray)
    
    0 // return an integer exit code

main ()