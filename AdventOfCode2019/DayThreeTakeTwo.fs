module DayThreeTakeTwo

    open Plotly.NET

    let parse_wire wire =
        let xData = [0]
        let yData = [0]
        0

    let parse_wires wires =
        wires |> List.map parse_wire

    let charts wires =
        
        parse_wires wires
        let xData = [2.;4.;6.;8.;10.]
        let yData = xData

        let x = 
            [
                Chart.Line(xData, yData) 
                //Chart.Line(negate xData, negate yData)
            ] |> Chart.combine |> Chart.show
        0