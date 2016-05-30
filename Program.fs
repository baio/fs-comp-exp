// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

//open bind_with_workflow
open bind_with_operator
open str_to_int_workflow

[<EntryPoint>]
let main argv = 
    //printfn "%A" argv

    // test
    let good = divideByWorkflow 12 3 2 1
    let bad = divideByWorkflow 12 3 0 1

    let good = stringAddWorkflow "12" "3" "2"
    let bad = stringAddWorkflow "12" "xyz" "2"

    let good = strToInt "1" >>= strAdd "2" >>= strAdd "3"
    let bad = strToInt "1" >>= strAdd "xyz" >>= strAdd "3"


    match bad with
        | Some _ -> printf ")))"
        | None -> printf "((("
            

    0 // return an integer exit code
