module TreeMap.Tests

open NUnit.Framework
open FsUnit
open TreeMap

[<Test>]
let emptyTreeTest () =
    mapTree (fun x -> x) Empty |> should equal Empty

[<Test>]
let singleNodeTest () =
    mapTree (fun x -> x * 2) (Node(10, Empty, Empty)) |>
        should equal (Node(20, Empty, Empty))

[<Test>]
let bigTreeTest () =
    mapTree (fun x -> x + 1) (Node(1,
                                    Node(2, Empty, Empty),
                                    Node(10,
                                        Node(5, Empty, Empty),
                                        Node(6, Empty, Empty)
                                        )
                                    )) |>
    should equal (Node(2,
                        Node(3, Empty, Empty),
                        Node(11,
                            Node(6, Empty, Empty),
                            Node(7, Empty, Empty)
                            )
                        ))