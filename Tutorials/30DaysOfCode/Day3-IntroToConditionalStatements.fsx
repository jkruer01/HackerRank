open System


let main _ = 
    let input = Console.ReadLine () |> int
    let output = 
        match input % 2 <> 0 with
        | true -> "Weird"
        | false -> 
            match input < 6 with
            | true -> "Not Weird"
            | false -> 
                match input < 21 with
                | true -> "Weird"
                | false -> "Not Weird"
    
    printfn "%s" output

    0 // return an integer exit code

main ()