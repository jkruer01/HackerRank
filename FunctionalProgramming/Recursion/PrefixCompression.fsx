open System

let findMatchingPrefix' (input1:string) (input2:string) =
    input2
    |> Seq.zip input1
    |> Seq.takeWhile(fun (a, b) -> a = b)
    |> Seq.map(fun (a, b) -> a |> string)
    |> String.concat ""

let printLengthAndContent input =    
    printfn "%i %s" (String.length input) input

let main _ = 
    let input1 = Console.ReadLine()
    let input2 = Console.ReadLine()
    let matchingPrefix = findMatchingPrefix' input1 input2
    let prefixLength = String.length matchingPrefix
    
    printLengthAndContent matchingPrefix
    printLengthAndContent input1.[prefixLength..]
    printLengthAndContent input2.[prefixLength..]


    0 // return an integer exit code

main ()
