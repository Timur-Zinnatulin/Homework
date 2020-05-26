namespace Workflow.Tests

module StrToIntWorkflowTests =

    open NUnit.Framework
    open FsUnit
    open StrToIntWorkflow

    [<Test>]
    let ``Calculator should pass hwproj test`` () =
        let calculator = new CalculationWorkflow()
        let result = calculator {
            let! x = "1"
            let! y = "2"
            let z = x + y
            return z
        }
        
        result |> should equal (Some 3.0)

    [<Test>]
    let ``Calculator should pass non-number test`` () =
        let calculator = new CalculationWorkflow()
        let result = calculator {
            let! x = "123"
            let! y = "abc"
            let z = x + y
            return z
        }
        
        result |> should equal None

    [<Test>]
    let ``Calculator should pass real numbers test`` () =
        let calculator = new CalculationWorkflow()
        let result = calculator {
            let! a = "123,45"
            let! b = "1,8"
            return a + b
        }

        match result with
            | Some value -> value |> should (equalWithin 0.01) 125.25
            | None -> Assert.Fail()
