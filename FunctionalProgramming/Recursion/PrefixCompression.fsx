open System

let inline equal (a, b) = a = b
// `inline` requests inline compilation, that means everywhere `equal` is
// called, the actual code of the function will appear in the IL instead of
// a jump.
// It is only a request, though; as far as I know, the compiler *may*
// decide against complying with it (presumably for larger functions). 

// The apostrophe is generally used in names when the value/function embodies
// a slight variation of an already named concept, such as a partially applied
// "instance" of a more general function, or a value that has been existing
// previously, but here exists in a form that has already seen additional
// processing.
// I also sometimes use the apostrophe for recursive sub-functions within
// other functions.
let findMatchingPrefix (input1 : string) (input2 : string) =
// It's easier to see what's going on with a few spaces around the parameter
// names and type annotations
    Seq.zip input1 input2
    // or
    // (input1, input2) ||> Seq.zip
    // either of these makes it clearer that input1 and input2 are "equal"
    // values being operated on here, rather than `input1` determining
    // specifics of an operation on `input2`
    |> Seq.takeWhile equal // reads a little nicer than the lambda
                               // As long as it's only used once, it doesn't matter
                               // all that much, though.
    |> Seq.map (fst >> string) // also a slightly higher-level construct than the lambda
    |> String.concat ""

let printLengthAndContent input =    
    printfn "%i %s" (String.length input) input

let main _ = 
    let input1 = Console.ReadLine()
    let input2 = Console.ReadLine()
    let matchingPrefix = findMatchingPrefix input1 input2
    let prefixLength = String.length matchingPrefix
    
    printLengthAndContent matchingPrefix
    printLengthAndContent input1.[prefixLength..]
    printLengthAndContent input2.[prefixLength..]


    0 // return an integer exit code

main ()
