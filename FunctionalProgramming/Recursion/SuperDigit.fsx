open System

// I generally put such tiny functions on single lines; this saves space and
// improves the reading flow, because a piece of code such as this function
// body can get a bit "lost" visually.
let splitBySpace (input : string) = input.Split ' '

// While this works with `_`, the placeholder parameter of parameterless
// functions is by convention always the `unit` value `()`. That makes it
// immediately clear that there is no useful input to this function, while the
// `_`  placeholder actually causes the parameter to become generic, which is
// irritating, because while one can pass *anything*, it will never matter.
let readInputs () =
    // Destructuring assignments like this take a bit of getting used to,
    // but are pretty powerful in that they let you name the individual values
    // immediately without the need for an intermediate array and "anonymous"
    // access via "magic number" indices.
    // Pattern matching in this way incurs a compiler warning, because the
    // match will fail with an exception for any array that doesn't have
    // *exactly* two elements.
    let [| n; k |] = Console.ReadLine () |> splitBySpace 
    n, int64 k

// I deleted `calculateP`, because it was not used.)

// This isn't a case where you'd typically use "derivation" naming with an
// apostrophe; this is really a separate function that might still make sense
// outside of the function that it's being used from here.
let sumDigits (num : string) =
    num.ToCharArray()
    // Seq.sumBy is the composition of `Seq.map` and `Seq.sum` 
    |> Seq.sumBy (string >> int64)
    |> string

// This is a bit less involved and doesn't require making sense of the whole
// multiplication term at once.
let sumIndividualDigits n (k : int64) =
    n
    |> sumDigits
    |> int64
    // Generally (there may be exceptions), operators can be turned into
    // functions by putting them in parentheses. In this case, `(*)` behaves
    // like a `multiply` function that takes two factors as parameters.
    // This behavior can make for more pipe-friendly code as in this example,
    // however, it should preferably only be used with commutative operations,
    // because when the order of operands matters, this will read rather
    // unintuitively.
    |> (*) k
    |> string 

// Pattern matching on booleans is a little odd; an `if` expression would be
// more direct. Pattern matching on the actual value is the visually most
// expressive representation of what this function does.
let rec calculateSuperDigit num =
    match String.length num with
    | 1 -> num
    | _ -> num |> sumDigits |> calculateSuperDigit

let main _ = 
    readInputs()
    // The ||> operator passes the elements of a 2-tuple to the target
    // function as two indivdual values, which allows for making the function
    // more flexible by not requiring its values to be tupled and thus enabling
    // partial application.
    ||> sumIndividualDigits
    |> calculateSuperDigit
    |> printfn "%s"

    0 // return an integer exit code

main ()
