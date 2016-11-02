open System

let main _ = 
    let numberOfRepeats = Console.ReadLine() |> int
    let read _ = Console.ReadLine()
    let notNullOrEmpty = not << System.String.IsNullOrWhiteSpace
    let inputList = Seq.initInfinite read |> Seq.takeWhile notNullOrEmpty |> Seq.toList
    let printNTimes n input =
        [1 .. n]
        |> Seq.iter(fun _ -> printfn "%s" input)
    Seq.iter(printNTimes numberOfRepeats) inputList
    
    0 // return an integer exit code

main ()