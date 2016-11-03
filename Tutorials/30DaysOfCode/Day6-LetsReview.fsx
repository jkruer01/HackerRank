﻿open System

let splitWords (input:String) =
    let evenChars = 
        [0 .. (String.length input - 1)]
        |> List.filter(fun num -> num % 2 = 0)
        |> List.fold(fun (sb:System.Text.StringBuilder) index -> sb.Append(input.[index])) (new System.Text.StringBuilder())
        |> fun x -> x.ToString()
        
    let oddChars = 
        [0 .. (String.length input - 1)]
        |> List.filter(fun num -> num % 2 <> 0)
        |> List.fold(fun (sb:System.Text.StringBuilder) index -> sb.Append(input.[index])) (new System.Text.StringBuilder())
        |> fun x -> x.ToString()
    
    String.Format ("{0} {1}", evenChars, oddChars)

let main _ = 
    let numberOfInputs = Console.ReadLine () |> int
    [1 .. numberOfInputs]
    |> List.iter(fun _ -> 
        Console.ReadLine () 
        |> splitWords 
        |> printfn "%s")
                
    0 // return an integer exit code

main ()
