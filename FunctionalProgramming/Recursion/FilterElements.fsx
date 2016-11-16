open System

let splitBySpace (input : string) = input.Split ' '

// I mentioned this in our session - moving out the details of what reading a
// value looks like makes the `main` function more readable and focused.
// Passing in a simple converter function makes it more easily reusable and
// replaceable and also lets us see at the call site what we're going to get
// back.
let readValue convert = Console.ReadLine() |> convert

// `readInputs'` is a very opaque name that doesn't provide any hints as to
// what it means at the call site.
let readArray convert = 
    Console.ReadLine () 
    |> splitBySpace 
    |> Array.map convert

// "inputs" isn't very descriptive; `readTestCase` says very clearly what's
// happening.
let readTestCase () =
    // Pattern matching on the array positions provides a visual "explanation"
    // of how the array contents are used. It becomes immediately clear, for
    // example, that the first array element goes unused.
    let [| _; greaterThan |] = readArray int
    let numbers = readArray int
    greaterThan, numbers // reordered to match the change in `filterByCount`

// Untupling the parameters makes the function more flexibly usable with
// partial application. That is assisted by reordering the parameters, as it
// feels more likely that we'd (outside of this concrete exercise) want to
// check multiple lists against the same `greaterThan` value than vice versa.
// That is more of a hunch from experience, though, not backed by hard
// technical facts.
let filterByCount greaterThan numbers =
    numbers
    |> Array.countBy id
    |> Array.filter (fun (key, count) -> count >= greaterThan)
    |> Array.map fst // Cleaner than the lambda, but requires being aware of
                        // how the tuples being operated on are composed. The
                        // lambda in the line above directly gives us that
                        // information, though.

// The type annotation isn't required here, so I'd typically leave it out.
// People have different opinions about that w/ regard to readability, though.
// I also separated determining the output string from printing it, to be more
// functional and composable.
let createOutput numList =
    match numList with
    | [||] -> "-1"
    | _ ->
        // Piping the initial value into the first function provides an easier
        // entry point for reading the pipe chain, because it's not necessary
        // to make sense of the full first call to find out what value is being
        // operated on. I don't strictly always do that, but I pretty much
        // always pipe the "operand" into a partially applied function (like
        // `Array.map` in this case) to make it very clear what the "data" is,
        // and what is a further specification of the operation to perform
        // (`string` here).
        numList
        |> Array.map string
        |> String.concat " "

let main () = 
    let numberOfTestCases = readValue int

    [1 .. numberOfTestCases]
    |> List.map (fun _ -> readTestCase () ||> filterByCount |> createOutput)
    |> List.iter (printfn "%s")

    0 // return an integer exit code

main ()
