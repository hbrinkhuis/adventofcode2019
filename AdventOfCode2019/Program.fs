let readlines filePath = System.IO.File.ReadLines(filePath) |> List.ofSeq |> List.map int

let calculate_fuel mass = mass / 3 - 2

let rec calculate_fuel_better mass = 
    let fuel = calculate_fuel mass
    if fuel < 0 then 0
    else fuel + (calculate_fuel_better fuel)

let dayone_partone weights = weights |> List.map calculate_fuel |> List.sum
let dayone_parttwo weights = weights |> List.map calculate_fuel_better |> List.sum

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let module_weights = readlines "Resources\\day1.txt"
    printfn "Day one puzzle one answer: %i" (dayone_partone module_weights)
    printfn "Day one puzzle two answer: %i" (dayone_parttwo module_weights)
    0