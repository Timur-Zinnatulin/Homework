module BracketSeq

/// List of opening brackets
let openingBrackets = [ '('; '[' ; '{' ]

/// List of closing brackets
let closingBrackets = [ ')'; ']' ; '}' ]

/// Checks if the bracket is the closing one
let isClosingBracket bracket =
    closingBrackets |> List.contains bracket

/// Checks if the bracket is the closing one
let isOpeningBracket bracket =
    openingBrackets |> List.contains bracket

/// Checks if the symbol is not a bracket
let isNotBracket bracket =
    if ((not (isClosingBracket bracket)) && (not (isOpeningBracket bracket))) then
        true
    else
        false

/// Predicate that returns true if the bracket sequence is correct
let checkSeq (seq : string) =
    let rec checkSeqRec seq opens =
        match seq with 
            | (symbol :: tail) when (isNotBracket symbol) -> checkSeqRec tail opens
            | [] when (opens |> List.isEmpty) -> true
            | [] when not (opens |> List.isEmpty)-> false
            | (bracket :: tail) when (isOpeningBracket bracket) -> checkSeqRec tail (bracket :: opens)
            | (bracket :: tail) when (isClosingBracket bracket) ->
                if (opens.IsEmpty) then
                    false
                else
                    let index = closingBrackets |> List.findIndex (fun s -> s = bracket)
                    if (openingBrackets.[index] = opens.Head) then
                        checkSeqRec tail opens.Tail
                    else
                        false
            | _ -> false

    checkSeqRec (seq |> Seq.toList) List.Empty





