module DayThreeTakeTwo

    open Plotly.NET

    let parse_wire wire =
        let xData = [0;1]
        let yData = [0;1]
        (xData, yData)

    let charts wires =
        
        let parsed_wires = wires |> List.map parse_wire

        let charts = parsed_wires |> List.map (fun c -> Chart.Line(fst c, snd c))
       
        charts |> Chart.combine |> Chart.show