open System

let readInputList _ =     
    let read _ = Console.ReadLine()
    let notNullOrEmpty = not << System.String.IsNullOrWhiteSpace
    Seq.initInfinite read 
    |> Seq.takeWhile notNullOrEmpty 
    |> Seq.map(fun str -> str |> int) 
    |> Seq.toList

let main _ = 
    readInputList ()
    |> Seq.iteri(fun index num -> 
        match index % 2 = 0 with
        | true -> num |> ignore
        | false -> printfn "%i" num)
    
    0 // return an integer exit code

main ()