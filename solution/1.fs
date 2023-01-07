module Day1

let solve part input =
    let data =
        Seq.fold
            (fun acc x ->
                match x, acc with
                | "", _ -> 0 :: acc
                | n, x :: xs -> (System.Int32.Parse n + x) :: xs
                | n, [] -> System.Int32.Parse n :: [])
            []
            input

    match part with
    | 1 -> Seq.max data |> sprintf "%d"
    | 2 ->
        data
        |> Seq.sortDescending
        |> Seq.take 3
        |> Seq.sum
        |> sprintf "%d"
    | _ -> failwith "Invalid input"
