module FirstInList.Tests

open NUnit.Framework
open FirstInList

let correctTestCases () =
    [
        1, 0, [1; 2; 3]
        3, 2, [1; 4; 3; 2; 5]
        10, 1, [5; 10; 10; 15; 10]
        0, 3, [-2; -1; -1; 0]
    ] |> Seq.map (fun (x, p, list) -> TestCaseData(x, p, list))

let incorrectTestCases () =
    [
        1, [2; 3]
        3, [1; 4; 2; 5]
        1, [5; 10; 10; 15; 10]
        3, [-2; -1; -1; 0]
    ] |> Seq.map (fun (x, list) -> TestCaseData(x,  list))

///Tests for list with desired element
[<TestCaseSource("correctTestCases")>]
[<Test>]
let correctPosTests x expected list =
    Assert.AreEqual(Some(expected), firstInList x list)

///Tests for lists without desired element
[<TestCaseSource("incorrectTestCases")>]
[<Test>]
let noElemTests x list =
    Assert.AreEqual(None, firstInList x list)
