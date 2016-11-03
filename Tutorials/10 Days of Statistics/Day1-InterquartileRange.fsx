open System

let calculateEvenMedianAndIndex (array:float[]) =
    let maxIndex =  float (Array.length array - 1)
    let index = maxIndex / 2.
    let lower = floor index |> int
    let upper = ceil index |> int
    let median = (Array.get array lower + Array.get array upper) / 2.
    (median, index)
    
let calculateOddMedianAndIndex array = 
    let index = Array.length array / 2
    let median = Array.get array index
    (median, index |> float)

let calculateMedianAndIndex array =
    match Array.length array % 2 = 0 with
    | true -> calculateEvenMedianAndIndex array
    | false -> calculateOddMedianAndIndex array

let splitBySpace (input:string) =
    input.Split ' '

let readInputs _ = 
    Console.ReadLine () 
    |> splitBySpace 
    |> Array.map(int)


let main _ = 
    let lengthOfInput = Console.ReadLine () |> int
    let numbers = readInputs ()
    let frequencies = readInputs ()

    let sortedArray =
        Array.map2(Array.create) frequencies numbers
        |> Array.concat
        |> Array.sort
        |> Array.map(float)

    let q2, index = calculateMedianAndIndex sortedArray
    let q1, _ =
        sortedArray
        |> Array.mapi(fun i item -> 
            match float i < index with
            | true -> Some item
            | false -> None)
        |> Array.choose(id)
        |> calculateMedianAndIndex
    let q3, _ =
        sortedArray
        |> Array.mapi(fun i item -> 
            match float i > index with
            | true -> Some item
            | false -> None)
        |> Array.choose(id)
        |> calculateMedianAndIndex

    printfn "%.1f" (q3 - q1)
    
    0 // return an integer exit code

main ()