module Task2.Tests

open NUnit.Framework
open Task2

[<TestCase(1, "*")>]
[<TestCase(2, "**\n\
               **")>]
[<TestCase(3, "***\n\
               * *\n\
               ***")>]
[<TestCase(5, "*****\n\
               *   *\n\
               *   *\n\
               *   *\n\
               *****")>]
[<Test>]
let squareTest size square =
    Assert.AreEqual(square, createSquare size)