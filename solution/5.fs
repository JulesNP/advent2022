module Day5

open System
open System.Text.RegularExpressions

type Move = { Amount: int; From: int; To: int }

let parseStacks (input: seq<string>) =
    let stacks = Array.create ((Seq.head input).Length / 4 + 1) []

    for line in Seq.rev input do
        for i in 1..4 .. line.Length do
            if line[i] <> ' ' then
                let n = i / 4
                stacks[n] <- line[i] :: stacks[n]

    stacks

let solve part input =
    let stacks =
        Seq.takeWhile (fun s -> s <> "") input
        |> parseStacks

    let parseMoves (input: seq<string>) =
        let moves =
            seq {
                for line in input do
                    let g =
                        Regex
                            .Match(
                                line,
                                "move (\d+) from (\d+) to (\d+)"
                            )
                            .Groups
                        |> Seq.map string
                        |> Array.ofSeq

                    { Amount = Int32.Parse(g[1])
                      From = Int32.Parse(g[2]) - 1
                      To = Int32.Parse(g[3]) - 1 }
            }

        let stackFunc =
            match part with
            | 1 -> List.rev
            | 2 -> id
            | _ -> failwith "Invalid input"

        for move in moves do
            let take, leave = List.splitAt move.Amount stacks[move.From]
            stacks[move.From] <- leave
            stacks[move.To] <- stackFunc take @ stacks[move.To]

    Seq.skipWhile (fun s -> s <> "") input
    |> Seq.tail
    |> parseMoves

    new string (Array.map List.head stacks)
