module Fibonacci

///Counts the n-th Fibonacci number
let fibonacci n =
    let rec fibonacciRec x i a b =
        if x < 0 then
            None
        elif x = i then
            Some(b)
        else
            fibonacciRec x (i + 1) (a + b) a
    fibonacciRec n 0 1 0