module bind_with_operator

let divideBy bottom top =
    if bottom = 0
    then None
    else Some(top/bottom)

let (>>=) m f = Option.bind f m

let divideByWorkflow x y w z = 
    x |> divideBy y 
    >>= divideBy w 
    >>= divideBy z 

// test
let good = divideByWorkflow 12 3 2 1
let bad = divideByWorkflow 12 3 0 1

