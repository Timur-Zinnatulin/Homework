module PrimeSequence

open System

/// Checks if the number is prime
let isPrime x =
    if x < 2 then false
    else
        let root = (double >> sqrt >> int) x
        List.forall (fun i -> x % i <> 0) <| [2..root]

/// Generates an infinite sequence of prime numbers
let primeSeq () =
    Seq.initInfinite id |> Seq.filter isPrime