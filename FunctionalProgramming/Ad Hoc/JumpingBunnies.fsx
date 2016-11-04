open System

let rec greatestCommonDenominator (a:int64) (b:int64) =
    if b = int64(0) then a else greatestCommonDenominator b (a % b)

let leastCommonMultiple' a b =
    abs ((a / (greatestCommonDenominator a b)) * b)

let leastCommonMultiple numbers = 
    Seq.reduce(leastCommonMultiple') numbers

let main _ = 
    let numberOfRabbits = Console.ReadLine () |> int
    let input = Console.ReadLine ()
    input.Split (' ')
    |> Seq.map(int64)
    |> leastCommonMultiple    
    |> printfn "%i"

    Console.ReadLine () |> ignore
    0 // return an integer exit code

main ()