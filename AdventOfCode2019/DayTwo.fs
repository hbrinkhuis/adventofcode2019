module DayTwo

    let execute opcodes position f = 
        let left = Array.get opcodes (position + 1)
        let right = Array.get opcodes (position + 2)
        let destination = Array.get opcodes (position + 3)
        Array.set opcodes destination (f (Array.get opcodes left) (Array.get opcodes right))

    let rec execute_opcode opcodes position =
        let operation = Array.get opcodes position
        match operation with
        | 1 -> 
            execute opcodes position (fun l r -> l + r)
            execute_opcode opcodes (position + 4)
        | 2 -> 
            execute opcodes position (fun l r -> l * r)
            execute_opcode opcodes (position + 4)
        | 99 -> Array.get opcodes 0
        | _ -> -1

    let start opcodes noun verb =
        Array.set opcodes 1 noun
        Array.set opcodes 2 verb
        execute_opcode opcodes 0

    let part_one opcodes = 
        start opcodes 12 2

    let part_two opcodes desired_output =
        seq { 
            for i in 0..99 do 
                for j in 0..99 -> (i, j)
        } |> Seq.tryFind (fun i -> (start (Array.copy opcodes) (fst i) (snd i)) = desired_output)

        

        