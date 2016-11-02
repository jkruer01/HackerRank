open System


let main _ = 
    let input = Console.ReadLine () |> int

    [1 .. 10]
    |> Seq.iter(fun num ->
        printfn "%i x %i = %i" input num (input * num))
    
    0 // return an integer exit code

main ()
