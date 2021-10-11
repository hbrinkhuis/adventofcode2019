module AdventOfCode2019.Program
    let readlines filePath = System.IO.File.ReadLines(filePath)

    let readlines2 filePath = System.IO.File.ReadAllLines(filePath)

    [<EntryPoint>]
    let main argv =

        //// day one
        //let module_weights = readlines @"Resources\day1.txt" |> Seq.map int |> List.ofSeq
        //printfn "Day one puzzle one answer: %i" (DayOne.part_one module_weights)
        //printfn "Day one puzzle two answer: %i" (DayOne.part_two module_weights)

        //// day two
        //let opcodes = readlines @"Resources\day2.txt" |> Seq.map (fun x -> x.Split(',')) |> Seq.concat |> Seq.map int |> Array.ofSeq
        //printfn "Day two puzzle one answer: %i" (DayTwo.part_one opcodes)
        //let opcodes = readlines @"Resources\day2.txt" |> Seq.map (fun x -> x.Split(',')) |> Seq.concat |> Seq.map int |> Array.ofSeq
        //printfn "Day two puzzle two answer: %A" (DayTwo.part_two opcodes 19690720)

        // day three
        let wires = readlines @"Resources\day3.txt" |> Seq.map (fun x -> x.Split(',') |> List.ofArray ) |> List.ofSeq
        // printfn "Day three puzzle one answer: %i" (DayThree.part_one wires)

        DayThreeTakeTwo.charts wires
        0