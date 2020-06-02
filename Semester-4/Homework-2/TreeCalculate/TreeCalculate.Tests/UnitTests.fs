module TreeCalculate.Tests

open NUnit.Framework
open FsUnit
open TreeCalculate

[<Test>]
let numberTest ()   =
    calculate (Number 12321) |> should equal 12321

[<Test>]
let addTest () =
    calculate (Addition(Number 1, Number 1)) |> should equal 2

[<Test>]
let subtractTest () =
    calculate (Subtraction(Number 10, Number 1)) |> should equal 9

[<Test>]
let multiplyTest () =
    calculate (Multiplication(Number 2, Number 2)) |> should equal 4

[<Test>]
let divideTest () =
    calculate (Division(Number 64, Number 8)) |> should equal 8

[<Test>]
let divideByZeroTest () =
    (fun () -> calculate (Division (Number 1, Number 0)) |> ignore) |> should throw typeof<System.DivideByZeroException>

[<Test>]
let calculateExpressionTest () =
    calculate (Addition (Multiplication(Number 2, Number 2), Number 2)) |> should equal 6