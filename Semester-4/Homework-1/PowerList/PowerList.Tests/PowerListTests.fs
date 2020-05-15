module PowerList.Tests

open NUnit.Framework
open PowerList

let correctTestCases () =
    [
        1, 0, [2]
        1, 3, [2; 4; 8; 16]
        2, 2, [4; 8; 16]
        10, 2, [1024; 2048; 4096]
        0, 10, [1; 2; 4; 8; 16; 32; 64; 128; 256; 512; 1024]
    ] |> Seq.map (fun (a, b, res) -> TestCaseData(a, b, res))

let incorrectTestCases () =
    [
        -1, 0
        1, -2
        -2, -2
        0, -82
        -50, -10
    ] |> Seq.map (fun (a, b) -> TestCaseData(a, b))

///Tests for correct inputs
[<TestCaseSource("correctTestCases")>]
[<Test>]
let correctListTests a b list =
    Assert.AreEqual(Some(list), powerList a b)

///Tests for incorrect inputs
[<TestCaseSource("incorrectTestCases")>]
[<Test>]
let incorrectListTests a b =
    Assert.AreEqual(None, powerList a b)