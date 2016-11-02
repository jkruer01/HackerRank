open System

let main _ = 
    let input = Console.ReadLine() |> int
    let output = [0 .. (input - 1)] |> Seq.map (fun num -> num.ToString()) |> String.concat ","
    printfn "[%s]" output
    0

main ()