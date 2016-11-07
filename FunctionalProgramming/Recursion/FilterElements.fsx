open System
let splitBySpace (input:string) =
    input.Split ' '

let readInputs' _ = 
    Console.ReadLine () 
    |> splitBySpace 
    |> Array.map(int)

let readInputs _ =
    let greaterThan = readInputs'().[1]
    let numberList = readInputs' ()
    numberList, greaterThan

let filterByCount (numberList, greaterThan) =
    numberList
    |> Array.countBy(id)
    |> Array.filter(fun (key, count) -> count >= greaterThan)
    |> Array.map(fun (key, count) -> key)

let printList (numList:int[]) =
    match numList with
    | [||] -> printfn "%i" -1
    | _ ->
        Array.map(string) numList
        |> String.concat " "
        |> printfn "%s"

let main _ = 
    let numberOfTestCases = Console.ReadLine () |> int
    [1 .. numberOfTestCases]
    |> List.map(fun _ -> readInputs () |> filterByCount)
    |> List.iter(printList)

    0 // return an integer exit code

main ()
