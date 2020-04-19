module EvensInList.Tests

open NUnit.Framework
open FsUnit
open FsCheck
open EvensInList

let testCases () =
    [
        [1; 3], 0
        [2], 1
        [1; 2; 3; 4], 2
        [0], 1
        [100; 2123; 1235123; 12126; 10992], 3
    ] |> List.map (fun (l, r) -> TestCaseData(l, r))

[<Test>]
[<TestCaseSource("testCases")>]
let correctAnswerTest list res =
    evensMap list |> should equal res

[<Test>]
let mapAndFilterAreEquivalentTest () =
    Check.Quick(fun (l: List<int>) -> (evensMap l) = (evensFilter l))

[<Test>]
let mapAndFoldAreEquivalentTest () =
    Check.Quick(fun (l: List<int>) -> (evensMap l) = (evensFold l))