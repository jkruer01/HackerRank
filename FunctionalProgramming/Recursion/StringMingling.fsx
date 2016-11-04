open System

let main _ = 
    let string1 = Console.ReadLine ()
    let string2 = Console.ReadLine ()

    string1
    |> Seq.zip string2
    |> Seq.iter(fun (a, b) -> printf "%c%c" b a)

    0 // return an integer exit code

main ()