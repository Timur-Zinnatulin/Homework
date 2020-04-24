module Task3.Tests

open NUnit.Framework
open Task3
open FsUnit
open System.Threading

[<Test>]
let singleEnqAndDeqTest () =
    let queue = new BlockingQueue<int>()
    queue.Enqueue(1)
    queue.Dequeue() |> should equal 1

[<Test>]
let multipleEnqAndDeqTest () =
    let queue = new BlockingQueue<int>()
    queue.Enqueue(1)
    queue.Enqueue(2)
    queue.Enqueue(3)
    queue.Enqueue(4)
    queue.Enqueue(5)
    queue.Dequeue() |> should equal 1
    queue.Dequeue() |> should equal 2
    queue.Dequeue() |> should equal 3
    queue.Dequeue() |> should equal 4
    queue.Dequeue() |> should equal 5

[<Test>]
let multiThreadTest () =
    let queue = BlockingQueue<int>()
    let threadA = Thread(fun () -> queue.Enqueue 1)
    let threadB = Thread(fun () -> queue.Enqueue 2)
    let threadC = Thread(fun () -> queue.Enqueue 3)
    threadA.Start()
    threadB.Start()
    threadC.Start()
    Thread.Sleep(1000)
    queue.Dequeue() |> should be instanceOfType<int>
    queue.Dequeue() |> should be instanceOfType<int>
    queue.Dequeue() |> should be instanceOfType<int>