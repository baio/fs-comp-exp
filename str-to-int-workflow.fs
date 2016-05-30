module str_to_int_workflow

(*
First, create a function that parses a string into a int:

let strToInt str = ???
and then create your own computation expression builder class so that you can use it in a workflow, as shown below.

let stringAddWorkflow x y z = 
    yourWorkflow 
        {
        let! a = strToInt x
        let! b = strToInt y
        let! c = strToInt z
        return a + b + c
        }    

// test
let good = stringAddWorkflow "12" "3" "2"
let bad = stringAddWorkflow "12" "xyz" "2"

let good = strToInt "1" >>= strAdd "2" >>= strAdd "3"
let bad = strToInt "1" >>= strAdd "xyz" >>= strAdd "3"
*)

let strToInt str = 
    let success, value = System.Int64.TryParse(str)
    if success then
        Some value
    else 
        None


type StringAddBuilder() = 
    
    member this.Bind(m, f) = Option.bind f m

    member this.Return(x) = 
        Some x

let stringAdd = new StringAddBuilder()
    
let stringAddWorkflow x y z = 
    stringAdd
        {
        let! a = strToInt x
        let! b = strToInt y
        let! c = strToInt z
        return a + b + c
        }    

let strAdd str i = 
    match strToInt str with
        | Some value -> Some(value + i)
        | None -> None

let (>>=) m f = Option.bind f m 