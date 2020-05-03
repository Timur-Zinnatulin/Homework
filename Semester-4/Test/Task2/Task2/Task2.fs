module Task2

open System

let isProductOfTwoTripleDigits n =
    let root = (double >> sqrt >> int) n
    let rec findPairOfDivisors x =
        if (x >= 100) then
            if (n % x = 0) && (n / x >= 100) && (n / x < 1000) then
                true
            else
                findPairOfDivisors (x - 1)
        else
            false
    findPairOfDivisors root

//Find the greates palindrome that is
//a product of two triple-digit numbers
let findMaxPalindrome () =
    let rec findMaxPalindromeRec cur =
        let currentNumber =
            let strNumber = string cur
            let rev = strNumber |> Seq.rev |> String.Concat
            (strNumber + rev) |> int

        if (isProductOfTwoTripleDigits currentNumber) then
            currentNumber
        else
            findMaxPalindromeRec (cur - 1)

    findMaxPalindromeRec 999