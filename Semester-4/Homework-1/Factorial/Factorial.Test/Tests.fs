module Factorial.Test

open NUnit.Framework
open Factorial

///Tests for correct input
[<TestCase (5, 120)>]
[<TestCase (0, 1)>]
[<TestCase (2, 2)>]
[<TestCase (6, 720)>]
let FactorialCorrectInputTest (input, expected) =
    Assert.AreEqual(Some(expected), factorial input)

///Tests for incorrect input
[<TestCase (-1)>]
[<TestCase (-100)>]
[<TestCase (-50 )>]
let FactorialIncorrectInputTest (input) =
    Assert.AreEqual(None, factorial input)