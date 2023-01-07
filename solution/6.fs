module Day6

let solve part input =
    let length = if part = 1 then 4 else 14
    let test arr = Set.count (set arr) = length

    Seq.head input
    |> Seq.windowed length
    |> Seq.findIndex test
    |> (+) length
    |> sprintf "%d"
