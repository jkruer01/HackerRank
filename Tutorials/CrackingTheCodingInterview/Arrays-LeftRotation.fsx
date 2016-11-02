open System

let inline flip f x y = f y x

let splitBySpace (input:string) =
    input.Split ' '

let rotate n array =
    let size = Array.length array
    let rotatedArray = Array.create size 0
    [0 .. size - 1] |> List.iter(fun k ->
        let index = (k + n) % size
        Array.set rotatedArray k array.[index])
    rotatedArray

let main _ = 
    let numberOfRotations = 
        Console.ReadLine () 
        |> splitBySpace 
        |> Array.map(int)
        |> flip Array.get 1
    
    Console.ReadLine () 
    |> splitBySpace 
    |> Array.map(int)
    |> rotate numberOfRotations
    |> Array.map(fun num -> num.ToString())
    |> String.concat " "
    |> printfn "%s"
    
    0 // return an integer exit code

main ()

