module Task3

open System

//Blocking queue class
type BlockingQueue<'a> () =
    let mutable items = []
    let locker = new Object()

    member this.Enqueue item  =
        lock locker (fun () ->
            items <- items @ [item] )

    member this.Dequeue () =
        let rec loop () =
            match items with
            | head :: tail ->
                items <- tail
                head
            | [] ->
                loop()
        lock locker (loop)