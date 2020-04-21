module LambdaInterpreter

open System

//Type for variable name
type VariableNameType = char

//Definition of lambda term
type LambdaTerm =
    | Variable of VariableNameType
    | Application of LambdaTerm * LambdaTerm
    | LambdaAbstraction of VariableNameType * LambdaTerm

//Performs beta reduction
let betaReduction (expression: LambdaTerm) =

    //Gets the set of free variables of given expression
    let rec getFreeVariables expression =
        match expression with
        | Variable x -> Set.empty.Add(x)
        | Application (left, right) -> (getFreeVariables left) |> Set.union (getFreeVariables right)
        | LambdaAbstraction (x, e) -> (getFreeVariables expression) |> Set.remove x

    //Set of variable names
    let varNames = Set.ofSeq['a'..'z']

    //Gets an available variable name with relation to given set
    let getNewVar usedNames =
        (Set.difference varNames usedNames) |> Set.toList |> List.head

    //Performs term substitution in given expression
    let rec termSubstitution varName newTerm expression =
        match expression with 
        | Variable x when x = varName -> newTerm
        | Variable x -> Variable (x)
        | Application (left, right) -> 
            let replacerFunction = termSubstitution varName newTerm
            let leftTransform = left |> replacerFunction
            let rightTransform = right |> replacerFunction
            Application (leftTransform, rightTransform)
        | LambdaAbstraction (var, term) when var = varName -> term
        | LambdaAbstraction (var, term ) ->
            let freeVarsInTerm = getFreeVariables term
            let freeVarsInNewTerm = getFreeVariables newTerm

            if ((freeVarsInNewTerm |> Set.contains var) &&
                (freeVarsInTerm |> Set.contains varName)) then
                    let freeName = (Set.union freeVarsInNewTerm freeVarsInTerm) |> getNewVar
                    let alphaTransform = term |> termSubstitution var (Variable(freeName))
                    let transformedTerm = alphaTransform |> termSubstitution varName newTerm

                    LambdaAbstraction(freeName, transformedTerm)
            else
                    LambdaAbstraction(var, term |> termSubstitution varName newTerm)

    //Reduces expression according to beta reduction axioms
    let rec betaReductionRec expression =
        match expression with
        | Variable x -> Variable(x)
        | LambdaAbstraction (var, term) -> 
            LambdaAbstraction (var, term |> betaReductionRec)
        | Application (LambdaAbstraction (var, termLeft), termRight) ->
            termLeft |> termSubstitution var termRight |> betaReductionRec
        | Application (termLeft, termRight) ->
            let leftReduce = termLeft |> betaReductionRec
            match leftReduce with 
            | LambdaAbstraction(_) -> Application (leftReduce, termRight) |> betaReductionRec
            | _ -> Application (leftReduce, termRight |> betaReductionRec)
    
    betaReductionRec expression








