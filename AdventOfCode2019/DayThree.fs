module AdventOfCode2019.DayThree

    // Represent one wire part where a tuple consist of x,y coordinates
    type Direction = Horizontal | Vertical | None
    type Point = { X : int; Y : int }
    type LineSegment = { A : Point; B : Point; Direction : Direction }
    
    // get second point (LTR) of horizontal LineSegment
    let get_point f segment =
        match segment.Direction with
        | Horizontal -> f segment.A.X segment.B.X
        | Vertical -> f segment.A.Y segment.B.Y
        | None -> 0

    // get first point (LTR) of LineSegment
    let entry_point segment =
        get_point min segment

    let exit_point segment =
        get_point max segment

    // gets the line coordinate. If horizontal, get the y coordinate
    // if vertical, get the x coordinate
    let line_coord segment =
        match segment.Direction with
        | Horizontal -> segment.A.Y
        | Vertical -> segment.A.X
        | None -> 0
    
    // check if one line crosses another line
    let crosses (a: LineSegment) (b: LineSegment) =
        let coord_a = line_coord a
        let coord_b = line_coord b
        (entry_point b) <= coord_a && (exit_point b) >= coord_a &&
        (entry_point a) <= coord_b && (exit_point a) >= coord_b &&
        a.Direction <> b.Direction


    // PARSING

    // create a line according to a number of steps and a direction, starting from the state
    let advance_line state direction steps = 
        match direction with
        | Horizontal -> { A = state; B = { state with X = state.X + steps }; Direction = Horizontal }
        | Vertical -> { A = state; B = { state with Y = state.Y + steps }; Direction = Vertical }
        | None -> { A = state; B = state; Direction = None }
    
    let parse_line (next_location: string) (state: LineSegment) =
        // convert the integers after the direction character
        let steps = (int next_location.[1..])

        // return a tuple (x,y) according to the direction given in character 0
        let startPoint = state.B
        match next_location.Chars 0 with
        | 'L' -> advance_line startPoint Horizontal -steps
        | 'R' -> advance_line startPoint Horizontal steps
        | 'U' -> advance_line startPoint Vertical steps
        | 'D' -> advance_line startPoint Vertical -steps
        | _ -> advance_line startPoint None 0
        
        
    // scan the wire list by converting every instruction to a separate Line.
    // the first line will be a point (0,0) so let's remove that with tail
    let wire_convert (wire : string list) initialState =
        wire |> Seq.scan (fun state x -> parse_line x state) initialState |> Seq.tail


    // AGGREGATION

    let part_one wires = 
        // provide the starting point (which is always 0,0)
        let origin = { X = 0; Y = 0 }
        let initialState = { A = origin; B = origin; Direction = None }

        // calculate wire segments
        // let wireSegments = wires |> Seq.collect (fun wire -> wire_convert wire initialState) |> List.ofSeq
        let first_wire = wire_convert (List.head wires) initialState
        let second_wire = wire_convert (wires |> List.item 1) initialState

        let crossed_wires_first = first_wire |> Seq.filter (fun f -> second_wire |> Seq.exists (fun j -> crosses j f) )

        let crosspoints = crossed_wires_first |> Seq.map (fun x -> (x, second_wire |> Seq.find (fun j -> crosses j x)))

        crosspoints |> Seq.map (fun x -> (line_coord (fst x)) + (line_coord (snd x))) |> Seq.min

        //let horizontals = wireSegments |> List.filter (fun f -> f.Direction = Horizontal) |> List.sortBy entry_point
        //let verticals = wireSegments |> List.filter (fun f -> f.Direction = Vertical) |> List.sortBy entry_point

        //// apply line sweep on the segments
        //let horizontal_crosses = horizontals |> Seq.filter (fun f -> verticals |> Seq.exists (fun j -> crosses j f) )
        
        //let crosspoints = horizontal_crosses |> Seq.map (fun x -> verticals |> Seq.find (fun j -> crosses j x) |> (fun y -> { X = line_coord y; Y = line_coord x }))

        // crosspoints |> Seq.map (fun f -> (abs f.X) + (abs f.Y)) |> Seq.filter (fun z -> z > 0) |> Seq.min
