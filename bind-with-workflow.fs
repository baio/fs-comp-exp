module bind_with_workflow

    let divideBy bottom top =
        if bottom = 0
        then None
        else Some(top/bottom)

    type MaybeBuilder() =
        member this.Bind(m, f) = Option.bind f m
        member this.Return(x) = Some x

    let maybe = new MaybeBuilder()

    let divideByWorkflow x y w z = 
        maybe 
            {
            let! a = x |> divideBy y 
            let! b = a |> divideBy w
            let! c = b |> divideBy z
            return c
            }    


