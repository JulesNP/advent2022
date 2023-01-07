module Day4

let solve part input =
    let contains =
        function
        | [| a; b; x; y |] -> a >= x && b <= y || x >= a && y <= b
        | _ -> failwith "Invalid input"

    let overlaps =
        function
        | [| a; b; x; y |] -> a <= y && b >= x || x <= b && y >= a
        | _ -> failwith "Invalid input"

    let test =
        match part with
        | 1 -> contains
        | 2 -> overlaps
        | _ -> failwith "Invalid input"

    Seq.filter
        (fun (s: string) ->
            s.Split [| '-'; ',' |]
            |> Array.map System.Int32.Parse
            |> test)
        input
    |> Seq.length
    |> sprintf "%d"
