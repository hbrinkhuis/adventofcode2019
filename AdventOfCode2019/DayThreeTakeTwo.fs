module DayThreeTakeTwo

    open Plotly.NET

    let parse_segment (segment: string) state =
        // convert the integers after the direction character
        let steps = (int segment.[1..])
        let x, y = state

        // return a tuple (x,y) according to the direction given in character 0
        match segment.Chars 0 with
        | 'L' -> (x - steps, y)
        | 'R' -> (x + steps, y)
        | 'U' -> (x, y + steps)
        | 'D' -> (x, y - steps)
        | _ -> (x, y)

    let parse_wire wire =
        let start_coords = (0,0)
        let parsed_wire = wire |> List.scan(fun state x -> parse_segment x state) start_coords
        (parsed_wire |> List.map(fst), parsed_wire |> List.map(snd))

    let charts wires =
        let parsed_wires = wires |> List.map parse_wire
        let charts = parsed_wires |> List.map (fun c -> Chart.Line(fst c, snd c))
        charts |> Chart.combine |> Chart.show
        