module DayFour
    let rec split_digits number =
        if number < 10 
        then [number]
        else List.append (split_digits (number / 10)) [number % 10]    

    let has_duplicate_digits numbers = 
        numbers |> List.scan(fun accumulator item -> (snd accumulator = item, item)) (false, -1) |> List.exists (fun c -> fst c)

    let has_ascending_digits numbers =
        numbers |> List.scan(fun accumulator item -> (snd accumulator <= item, item)) (true, -1) |> List.forall (fun c -> fst c)

    let validate value =
        let split = split_digits value
        split.Length = 6 && has_duplicate_digits split && has_ascending_digits split

    let part_one range =
        range |> List.filter validate |> List.length