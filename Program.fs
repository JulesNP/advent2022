open System

let questions =
    [ Day1.solve
      Day2.solve
      Day3.solve
      Day4.solve
      Day5.solve
      Day6.solve ]

printfn "**ADVENT OF CODE 2022**"

printf "Select a question (1-%d): "
<| List.length questions

match Int32.TryParse(Console.ReadLine()) with
| true, n when n <= List.length questions ->
    printf "Select a part (1-2): "

    match Int32.TryParse(Console.ReadLine()) with
    | true, p when p = 1 || p = 2 ->
        IO.File.ReadLines(sprintf "./input/%d" n)
        |> questions[n - 1]p
        |> printfn "%s"
    | _ -> printfn "Invalid input"
| _ -> printfn "Invalid input"
