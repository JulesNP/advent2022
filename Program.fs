open System

let questions = [
    Day1.solve
    Day2.solve
]

printfn "*ADVENT OF CODE 2022*"
printf "Select a question: "

match Int32.TryParse(Console.ReadLine()) with
| true, n when n <= List.length questions ->
    printf "Select a part: "

    match Int32.TryParse(Console.ReadLine()) with
    | true, p when p = 1 || p = 2 ->
        IO.File.ReadLines(sprintf "./input/%d" n)
        |> questions[n - 1] p
        |> printfn "%A"
    | _ -> printfn "Invalid input"
| _ -> printfn "Invalid input"