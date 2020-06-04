module TreeMap

open System

/// Structure of binary tree
type Tree<'a> =
    | Node of 'a * Tree<'a> * Tree<'a>
    | Empty

/// Applies 'func' to 'tree'
let rec mapTree func tree =
    match tree with
    | Node(head, left, right) -> Node(func head, mapTree func left, mapTree func right)
    | Empty -> Empty