module Day3

let solve part input =
    let priority =
        function
        | c when c >= 'a' && c <= 'z' -> int c - 96
        | c -> int c - 38

    match part with
    | 1 ->
        Seq.sumBy
            (Seq.splitInto 2
             >> Seq.map set
             >> Set.intersectMany
             >> Seq.head
             >> priority)
            input
        |> sprintf "%d"
    | 2 ->
        Seq.chunkBySize 3 input
        |> Seq.sumBy (
            Seq.map set
            >> Set.intersectMany
            >> Seq.head
            >> priority
        )
        |> sprintf "%d"
    | _ -> failwith "Invalid input"
