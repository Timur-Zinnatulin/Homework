namespace Bracket

module BracketSeq =

    let extractBrackets (seq : string) =
        let allBrackets = [ '('; ')'; '['; ']'; '{'; '}' ]
        seq |> Seq.filter (fun (c : char) -> (allBrackets |> List.contains c))

    /// Predicate that returns true if the bracket sequence is correct
    let checkSeq (seq : string) =

        /// Mapping of matching brackets to each other
        let bracketMap = [(')', '('); (']', '['); ('}', '{')] |> Map.ofList

        /// Checks if the bracket is the closing one
        let isClosingBracket bracket =
            (bracketMap).ContainsKey bracket

        let rec checkSeqRec seq (opens : char list) =
            match seq with 
                | (bracket :: tail) when isClosingBracket bracket ->
                    if (opens.IsEmpty) then
                        false
                    else
                        if (bracketMap.[bracket] = opens.Head) then
                            checkSeqRec tail opens.Tail
                        else
                            false
                | (bracket :: tail) -> 
                    checkSeqRec tail (bracket :: opens)
                | [] -> opens.IsEmpty
                | _ -> false

        checkSeqRec (seq |> extractBrackets |> List.ofSeq) List.Empty