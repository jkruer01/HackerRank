open System

let readInputList _ =     
    let read _ = Console.ReadLine()
    let notNullOrEmpty = not << System.String.IsNullOrWhiteSpace
    Seq.initInfinite read 
    |> Seq.takeWhile notNullOrEmpty 
    |> Seq.map(fun str -> str |> int) 
    |> Seq.toList

let main _ = 
    let maxValue = Console.ReadLine() |> int
    readInputList ()
    |> Seq.filter(fun num -> num < maxValue)
    |> Seq.iter(printfn "%i")
    
    0 // return an integer exit code

main ()