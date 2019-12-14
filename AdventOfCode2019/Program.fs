module Program
    let readlines filePath = System.IO.File.ReadLines(filePath)

    [<EntryPoint>]
    let main argv =
        printfn "Hello World from F#!"
        let module_weights = readlines "Resources\\day1.txt" |> Seq.map int |> List.ofSeq
        printfn "Day one puzzle one answer: %i" (DayOne.part_one module_weights)
        printfn "Day one puzzle two answer: %i" (DayOne.part_two module_weights)
        let opcodes = readlines "Resources\\day2.txt" |> Seq.map (fun x -> x.Split(',')) |> Seq.concat |> Seq.map int |> Array.ofSeq
        printfn "Day two puzzle one answer: %i" (DayTwo.part_one opcodes)
        let opcodes = readlines "Resources\\day2.txt" |> Seq.map (fun x -> x.Split(',')) |> Seq.concat |> Seq.map int |> Array.ofSeq
        printfn "Day two puzzle two answer: %A" (DayTwo.part_two opcodes 19690720)
        0