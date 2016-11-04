open System

let createAccumulator (acc:System.Text.StringBuilder) char count =
    match count with
    | 1 -> acc.Append(sprintf "%c" char)
    | _ -> acc.Append(sprintf "%c%i" char count)

let rec compress' (char, count) input acc =
    match input with
    | [] -> createAccumulator acc char count |> string
    | h::t ->
        match char = h with
        | true -> compress' (char, count+1) t acc
        | false -> compress' (h, 1) t (createAccumulator acc char count)

let compress input =
    match input with
    | [] -> ""
    | h::t -> compress' (h, 1) t (new System.Text.StringBuilder())

let main _ = 
    Console.ReadLine().ToCharArray()
    |> List.ofArray
    |> compress
    |> printfn "%s"

    0 // return an integer exit code

main ()
