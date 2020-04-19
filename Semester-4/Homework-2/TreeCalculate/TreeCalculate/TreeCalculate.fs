module TreeCalculate

open System

//Expression tree type
type expressionTree =
    | Number of int
    | Addition of expressionTree * expressionTree
    | Subtraction of expressionTree * expressionTree
    | Multiplication of expressionTree * expressionTree
    | Division of expressionTree * expressionTree

//Calculates the expression
let rec calculate tree =
    match tree with
    | Number number -> number
    | Addition(left, right) -> calculate left + calculate right
    | Subtraction(left, right) -> calculate left - calculate right
    | Multiplication(left, right) -> calculate left * calculate right
    | Division(left, right) -> calculate left / calculate right