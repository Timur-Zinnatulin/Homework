namespace Workflow.Tests

module RoundWorkflowTests =

    open NUnit.Framework
    open FsUnit
    open RoundWorkflow

    [<Test>]
    let ``Calculator should pass hwproj test`` () =
        let calculator = new RoundWorkflow(3)
        let result = calculator {
            let! a = 2.0 / 12.0
            let! b = 3.5
            return a / b
        }

        result |> should (equalWithin 0.001) 0.048

    [<Test>]
    let ``Calculator should pass normal test`` () =
        let calculator = new RoundWorkflow(4)
        let result = calculator {
            let! a = 1.2345 + 5.4321
            let! b = 10.0000
            return a * b
        }

        result |> should (equalWithin 0.0001) 66.6660

    [<Test>]
    let ``Calculator should pass zero test`` () =
        let calculator = new RoundWorkflow(2)
        let result = calculator {
            let! a = 2.28 - 2.28
            return a
        }

        result |> should (equalWithin 0.01) 0.0

    [<Test>]
    let ``Calculator should pass zero accuracy test`` () =
        let calculator = new RoundWorkflow(0)
        let result = calculator {
            let! a = 1.55 + 2.45
            let! b = a - 3.000
            return b
        }

        result |> should equal 1



