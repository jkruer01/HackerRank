open System

let splitBySpace (input:string) =
    input.Split ' '

let readInputs _ =
    let inputs = 
        Console.ReadLine () 
        |> splitBySpace 
    inputs.[0], int64 inputs.[1]

let calculateP (n, k:int64) =
    [1L..k]
    |> List.map(fun _ -> n)
    |> String.Concat

let sumIndividualDigits (num:string) =
    num.ToCharArray()
    |> Seq.map(string >> int64)
    |> Seq.sum
    |> string

let sumIndividualDigits' (n, k:int64) =
    k * (sumIndividualDigits n |> int64)
    |> string 

let rec calculateSuperDigit num =
    match (String.length num = 1) with
    | true -> num
    | false -> calculateSuperDigit (sumIndividualDigits num)

let main _ = 
    readInputs()
    |> sumIndividualDigits'
    |> calculateSuperDigit
    |> printfn "%s"

    0 // return an integer exit code

main ()
