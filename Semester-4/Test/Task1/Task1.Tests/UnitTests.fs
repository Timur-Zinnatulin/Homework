module Task1.Tests

open NUnit.Framework
open Task1

let tests =
    [
        -153, [11; -153; -150; 88]
        0, [16; 81; 293; 0; 134]
        -1024, [-1024; 20]
        1, [2; 4; 1]
        10, [10; 15]
        7, [7]
    ] |> List.map (fun (m, l) -> TestCaseData(m, l))

[<TestCaseSource("tests")>]
[<Test>]
let minOfListTest min list =
    Assert.AreEqual(min, minElement list)
