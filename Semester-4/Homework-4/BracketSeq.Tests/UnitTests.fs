module BracketSeq.Tests

open NUnit.Framework
open FsUnit
open BracketSeq

let tests () = 
    [
        System.String.Empty,    true
        "()",                   true
        "[]",                   true
        "{}",                   true
        "()[]",                 true
        "([})",                 false
        "({[]})",               true
        "aba()ca(ba)",          true
        "([]){[{{}}]()}",       true
        "aaa()sa[sadsa}",       false
        ")",                    false
        "}]]}",                 false
        "([)]",                 false
        "(([)])",               false
    ] |> Seq.map (fun (a, b) -> TestCaseData(a, b))

[<Test>]
[<TestCaseSource("tests")>]
let ``Checker passes the tests`` test expected =
    test |> checkSeq |> should equal expected