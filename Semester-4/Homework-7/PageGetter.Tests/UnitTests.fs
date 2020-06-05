module PageGetter.Tests

open NUnit.Framework
open PageGetter
open FsUnit

[<Test>]
let ``PageGetter downloads a page correctly`` () =
    let pages = "https://ytmnd.com/" |> downloadPages

    pages |> List.length |> should equal 2

    for subpage in pages do
        if subpage |> Option.isNone then
            Assert.Fail("Every subpage should be accessible.")

[<Test>]
let ``PageGetter handles invalid URLs correctly`` () =
    let page = "https://example.su/" |> downloadPages

    page |> List.length |> should equal 1
    page.[0] |> should equal None