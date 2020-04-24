module Fibonacci.Tests

open NUnit.Framework
open Fibonacci

///Tests for correct input
[<TestCase (0, 0)>]
[<TestCase (2, 1)>]
[<TestCase (4, 3)>]
[<TestCase (6, 8)>]
[<TestCase (8, 21)>]
[<TestCase (31, 1346269)>]
let FibonacciCorrectTest (input, expected) =
    Assert.AreEqual(Some(expected), fibonacci input)

///Tests for incorrect input
[<TestCase (-1)>]
[<TestCase (-50)>]
[<TestCase (-100)>]
let FibonacctFailTest (input) =
    Assert.AreEqual(None, fibonacci input)
