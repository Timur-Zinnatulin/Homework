module Task2.Tests

open NUnit.Framework
open Task2
open FsUnit

//Tests that the answer is correct
[<Test>]
let answerIsCorrectTest () =
    findMaxPalindrome() |> should equal 906609