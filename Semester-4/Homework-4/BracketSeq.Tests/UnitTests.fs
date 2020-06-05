namespace Bracket
module BracketTests =

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
            "({[]})",               true
            "aba()ca(ba)",          true
            "([]){[{{}}]()}",       true
            "([})",                 false
            "aaa()sa[sadsa}",       false
            ")",                    false
            "}]]}",                 false
            "([)]",                 false
            "(([)])",               false
        ] |> List.map (fun (a, b) -> TestCaseData(a, b))

    [<Test>]
    [<TestCaseSource("tests")>]
    let ``Checker passes the tests`` test expected =
        checkSeq (test) |> should equal expected