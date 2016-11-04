open System

let splitBySpace (input:string) =
    input.Split ' '

let readInputs _ = 
    Console.ReadLine () 
    |> splitBySpace 

let main _ = 
    let _ = Console.ReadLine () |> int
    readInputs () 
    |> Array.rev
    |> String.concat " "
    |> printfn "%s"
    
    0 // return an integer exit code

main ()
