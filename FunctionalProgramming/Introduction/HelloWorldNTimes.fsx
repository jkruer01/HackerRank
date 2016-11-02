open System

let main _ = 
    let numberOfLines = Console.ReadLine() |> int
    [1 .. numberOfLines]
    |> List.iter(fun _ -> printfn "%s" "Hello World")
    
    0 // return an integer exit code

main ()