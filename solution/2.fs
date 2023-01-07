module Day2

type Result =
    | Loss = 0
    | Tie = 3
    | Win = 6

type RPS =
    | Rock = 1
    | Paper = 2
    | Scissors = 3

let versus x y =
    match x, y with
    | RPS.Rock, RPS.Scissors -> Result.Win
    | RPS.Paper, RPS.Rock -> Result.Win
    | RPS.Scissors, RPS.Paper -> Result.Win
    | _ when x = y -> Result.Tie
    | _ -> Result.Loss

let solve part input =
    let decode1 (s: string) =
        enum<RPS> (int s[0] - 64), enum<RPS> (int s[2] - 87)

    let decode2 (s: string) =
        let opponent = enum<RPS> (int s[0] - 64)

        let result =
            match s[2] with
            | 'X' -> Result.Loss
            | 'Y' -> Result.Tie
            | _ -> Result.Win

        match opponent, result with
        | RPS.Rock, Result.Win -> opponent, RPS.Paper
        | RPS.Rock, Result.Loss -> opponent, RPS.Scissors
        | RPS.Paper, Result.Win -> opponent, RPS.Scissors
        | RPS.Paper, Result.Loss -> opponent, RPS.Rock
        | RPS.Scissors, Result.Win -> opponent, RPS.Rock
        | RPS.Scissors, Result.Loss -> opponent, RPS.Paper
        | _ -> opponent, opponent

    input
    |> Seq.map (
        match part with
        | 1 -> decode1
        | 2 -> decode2
        | _ -> failwith "Invalid input"
    )
    |> Seq.sumBy (fun (x, y) -> int y + int (versus y x))
    |> sprintf "%d"
