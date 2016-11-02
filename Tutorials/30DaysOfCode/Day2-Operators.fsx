open System

let main _ = 
    let mealCost = Console.ReadLine() |> double
    let tipPercent = Console.ReadLine() |> double
    let taxPercent = Console.ReadLine() |> double
    let mealTotal = mealCost + (mealCost * (taxPercent / 100.0)) + (mealCost * (tipPercent / 100.0)) |> System.Math.Round |> int
    printfn "The total meal cost is %i dollars." mealTotal
    0

main ()