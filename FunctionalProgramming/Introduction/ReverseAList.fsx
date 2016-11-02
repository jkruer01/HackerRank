open System

let readInputList _ =     
    let read _ = Console.ReadLine()
    let notNullOrEmpty = not << System.String.IsNullOrWhiteSpace
    Seq.initInfinite read 
    |> Seq.takeWhile notNullOrEmpty 

let main _ = 
    readInputList ()
    |> Seq.fold(fun acc item -> item::acc) []
    |> Seq.iter(fun item -> printfn "%s" item)
    
    0 // return an integer exit code

main ()