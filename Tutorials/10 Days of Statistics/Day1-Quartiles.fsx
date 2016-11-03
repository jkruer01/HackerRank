open System

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

let splitBySpace (input:string) =
    input.Split ' '

let main _ = 
    let lengthOfInput = Console.ReadLine () |> int

    let sortedArray = 
        Console.ReadLine () 
        |> splitBySpace 
        |> Array.map(int)
        |> Array.sort

    let q2 = calculateMedian sortedArray |> int
    let q1 =
        sortedArray
        |> Array.filter(fun item -> item < q2)
        |> calculateMedian
        |> int
    let q3 =
        sortedArray
        |> Array.filter(fun item -> item > q2)
        |> calculateMedian
        |> int

    printfn "%i" q1
    printfn "%i" q2
    printfn "%i" q3
    
    0 // return an integer exit code

main ()
