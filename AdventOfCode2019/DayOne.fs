module AdventOfCode2019.DayOne
    let calculate_fuel mass = mass / 3 - 2

    let rec calculate_fuel_better mass = 
        let fuel = calculate_fuel mass
        if fuel < 0 then 0
        else fuel + (calculate_fuel_better fuel)

    let part_one weights = weights |> List.map calculate_fuel |> List.sum
    let part_two weights = weights |> List.map calculate_fuel_better |> List.sum
