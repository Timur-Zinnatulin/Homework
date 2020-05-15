module ListReverse.Tests

open NUnit.Framework
open ListReverse

let testCases () =
    [
        [1; 2; 3; 4; 5], [5; 4; 3; 2; 1]
        [1; 1; 2; 2; 2], [2; 2; 2; 1; 1]
        [10], [10]
        [-1; -1; 0; 1; 1], [1; 1; 0; -1; -1]
    ] |> Seq.map (fun (e, x) -> TestCaseData(e, x))

///Tests for reverse function
[<TestCaseSource("testCases")>]
[<Test>]
let listReverseTest expected input =
    Assert.AreEqual(expected, reverse input)
