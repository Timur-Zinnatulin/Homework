module BracketSeq

/// List of opening brackets
let openingBrackets () = ['('; '['; '{']

/// List of closing brackets
let closingBrackets () = [')'; ']'; '}']

/// Mapping of matching brackets to each other
let bracketMap () = [(')', '('); (']', '['); ('}', '{')] |> Map.ofList

/// Checks if the bracket is the closing one
let isClosingBracket bracket =
    closingBrackets () |> List.contains bracket

/// Checks if the bracket is the closing one
let isOpeningBracket bracket =
    openingBrackets () |> List.contains bracket

let extractBrackets seq =
    seq |> Seq.filter (fun c -> isOpeningBracket c || isClosingBracket c)

/// Predicate that returns true if the bracket sequence is correct
let checkSeq seq =
    let rec checkSeqRec seq opens =
        match seq with 
            | (bracket :: tail) when isOpeningBracket bracket -> 
                checkSeqRec tail (bracket :: opens)
            | (bracket :: tail) when isClosingBracket bracket ->
                if (opens.IsEmpty) then
                    false
                else
                    if (bracketMap().[bracket] = opens.Head) then
                        checkSeqRec tail opens.Tail
                    else
                        false
            | [] -> opens.IsEmpty
            | _ -> false

    checkSeqRec (seq |> extractBrackets |> Seq.toList) List.Empty