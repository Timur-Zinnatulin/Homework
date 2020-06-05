module Task3

open System

/// Priority queue class (not on heap)
type PriorityQueue<'b> () =
    let mutable items = []

    /// Enqueue the element into a list
    member this.Enqueue ((key : int32), (item : 'b)) =
        let rec enqueueRec queue acc =
            match queue with
            | head :: tail ->
                if key < fst head then
                    List.rev ((key, item) :: acc) @ queue
                else 
                    enqueueRec tail ((fst head, snd head) :: acc)
            | [] ->
                List.rev ((key, item) :: acc)

        items <- enqueueRec items []

    /// Dequeue the top priority element from a queue
    member this.Dequeue () =
        match items with
        | head :: tail ->
            items <- tail
            snd head
        | [] -> invalidOp "The queue is empty!"
