namespace Lazy

module LazyTests =

    open NUnit.Framework
    open System.Threading
    open Lazy
    open FsUnit

    [<Test>]
    let ``Single thread lazy basic test`` () =
        let calculator = LazyFactory.CreateSingleThreadLazy(fun () -> 506)
        calculator.Get () |> should equal 506

    [<Test>]
    let ``Parallel lazy basic test`` () =
        let calculator = LazyFactory.CreateParallelLazy(fun () -> 228)
        calculator.Get () |> should equal 228

    [<Test>]
    let ``Lock-free lazy basic test`` () =
        let calculator = LazyFactory.CreateLockFreeLazy(fun () -> 177013)
        calculator.Get () |> should equal 177013

    [<Test>]
    let ``Multi thread lazy calculator should call supplier only one time`` () =
        let mutable callCounter = ref 0L
        let calculator = LazyFactory.CreateParallelLazy(fun () -> 
            Interlocked.Increment callCounter |> ignore
            (Interlocked.Read callCounter) |> should lessThan 2)

        for i in 1..1000 do
            ThreadPool.QueueUserWorkItem (fun obj -> calculator.Get ()) |> ignore

    [<Test>]
    let ``Single thread lazy calculator should call supplier only one time`` () =
        let mutable callCounter = 0
        let calculator = LazyFactory.CreateSingleThreadLazy(fun () -> 
            callCounter <- callCounter + 1
            callCounter |> should lessThan 2)

        for i in 1..1000 do
            calculator.Get ()

    [<Test>]
    let ``Multi threaded lazy should return the same object on every call`` () =
        let calculator = LazyFactory.CreateParallelLazy(fun () -> new System.Object())

        let expected = calculator.Get ()
        for i in 1..100 do
            ThreadPool.QueueUserWorkItem (fun obj -> 
                expected |> (calculator.Get ()).Equals |> should be True) |> ignore

    [<Test>]
    let ``Lock free multi threaded lazy should return the same object on every call`` () =
        let calculator = LazyFactory.CreateLockFreeLazy(fun () -> new System.Object())

        let expected = calculator.Get ()
        for i in 1..100 do
            ThreadPool.QueueUserWorkItem (fun obj -> 
                expected |> (calculator.Get ()).Equals |> should be True) |> ignore