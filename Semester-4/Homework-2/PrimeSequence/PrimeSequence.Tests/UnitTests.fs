module PrimeSequence.Tests

open NUnit.Framework
open PrimeSequence
open FsUnit

let seqIndexSource () =
    [
        0, 2
        10, 31
        16, 59
        19, 71
        120, 661
        165, 983
        550, 4001
    ] |> List.map (fun (i, x) -> TestCaseData(i, x))

[<Test>]
[<TestCaseSource"seqIndexSource">]
let seqIndexTest i x =
    primeSeq () |> Seq.item i |> should equal x