module Task3.Tests

open NUnit.Framework
open Task3
open FsUnit
open System
/// I had problems with putting queue initializer into set up
/// so this is how it will be.

[<Test>]
let multiplePrioritiesTest () =
    let queue = new PriorityQueue<int>()
    queue.Enqueue(3, 3)
    queue.Enqueue(1, 1)
    queue.Enqueue(5, 5)
    queue.Enqueue(4, 4)
    queue.Enqueue(2, 2)
    queue.Dequeue() |> should equal 1
    queue.Dequeue() |> should equal 2
    queue.Dequeue() |> should equal 3
    queue.Dequeue() |> should equal 4
    queue.Dequeue() |> should equal 5

[<Test>]
let samePriorityTest () =
    let queue = new PriorityQueue<int>()
    queue.Enqueue(1, 3)
    queue.Enqueue(1, 1)
    queue.Enqueue(1, 5)
    queue.Enqueue(1, 4)
    queue.Enqueue(1, 2)
    queue.Dequeue() |> should equal 3
    queue.Dequeue() |> should equal 1
    queue.Dequeue() |> should equal 5
    queue.Dequeue() |> should equal 4
    queue.Dequeue() |> should equal 2

[<Test>]
let throwsExceptionTest () =
    let queue = new PriorityQueue<string>()
    /// queue.Enqueue(1, "ababa")
    /// queue.Dequeue() |> ignore
    (fun () -> queue.Dequeue() |> ignore) |> should (throwWithMessage "The queue is empty!") typeof<InvalidOperationException>
       