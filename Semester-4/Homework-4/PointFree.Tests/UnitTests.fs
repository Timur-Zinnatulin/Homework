module PointFree.Tests

open NUnit.Framework
open FsCheck
open PointFree

[<Test>]
let ``Original and first change should return the same result`` () =
    Check.QuickThrowOnFailure (fun x l -> (func x l) = (func'1 x l))

[<Test>]
let ``Original and second change should return the same result`` () =
    Check.QuickThrowOnFailure (fun x l -> (func x l) = (func'2 x l))

[<Test>]
let ``Original and third change should return the same result`` () =
    Check.QuickThrowOnFailure (fun x l -> (func x l) = (func'3 x l))

[<Test>]
let ``Original and point-free variant should return the same result`` () =
    Check.QuickThrowOnFailure (fun x l -> (func x l) = ((func'4 ()) x l))