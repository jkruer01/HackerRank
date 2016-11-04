open System

let rec printPascalsTriangle rows iter lastRow =    
    let previousListLength = List.length lastRow
    let current = 
        match iter with
        | 1 -> [1]
        | _ -> 
            [0 .. previousListLength]
            |> List.map(fun index -> 
                match (index = 0 || index = previousListLength) with
                | true -> 1
                | _ -> lastRow.[index - 1] + lastRow.[index])

    current
    |> List.map(string)
    |> String.concat " "
    |> printfn "%s"

    if iter < rows then printPascalsTriangle rows (iter + 1) current

let main _ = 
    let rows = Console.ReadLine () |> int    
    printPascalsTriangle rows 1 []

    0 // return an integer exit code

main ()