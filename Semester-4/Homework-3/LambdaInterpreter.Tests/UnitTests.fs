module LambdaInterpreter.Tests

open NUnit.Framework
open LambdaInterpreter
open FsUnit

[<Test>]
let simpleInterpreterTest () =
    let test = (Application(LambdaAbstraction('x', Variable('x')), Variable('y')))

    test |> betaReduction |> should equal (Variable('y'))

[<Test>]
let singleVariableTest () =
    (Variable('a')) |> betaReduction |> should equal (Variable('a'))

[<Test>]
let normalFormTest () =
    let test = (Application(Application(Variable('x'), Variable('y')), 
                    LambdaAbstraction('k', Variable('k'))))
    let expected = test

    test |> betaReduction |> should equal expected

[<Test>]
let biggerExpressionReductionTest () =
    let test = Application(
                Application(
                    LambdaAbstraction('x',
                        LambdaAbstraction('y',
                            LambdaAbstraction('z', 
                                Application(
                                    Application(Variable('x'), Variable('z')), 
                                    Application(Variable('y'), Variable('z')))))),
                    LambdaAbstraction('x', LambdaAbstraction('y', Variable('x')))),
                LambdaAbstraction('x', LambdaAbstraction('y',Variable('x'))))

    let expected = LambdaAbstraction('z', Variable('z'))

    test |> betaReduction |> should equal expected

