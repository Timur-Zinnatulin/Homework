module TreeCalculate

open System

/// Expression tree type
type ExpressionTree =
    | Number of int
    | Addition of ExpressionTree * ExpressionTree
    | Subtraction of ExpressionTree * ExpressionTree
    | Multiplication of ExpressionTree * ExpressionTree
    | Division of ExpressionTree * ExpressionTree

/// Calculates the expression
let rec calculate tree =
    match tree with
    | Number number -> number
    | Addition(left, right) -> calculate left + calculate right
    | Subtraction(left, right) -> calculate left - calculate right
    | Multiplication(left, right) -> calculate left * calculate right
    | Division(left, right) -> calculate left / calculate right