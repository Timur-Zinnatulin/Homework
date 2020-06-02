module PointFree

open System

/// Original function
let func x l = List.map (fun y -> y * x) l

let func'1 x = List.map (fun y -> y * x)

let func'2 x = List.map (fun y -> (*) x y)

let func'3 x = List.map ((*) x)

/// Point-free version
let func'4 () = List.map << (*)