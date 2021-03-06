# BankingChallenge
This is a suggestion challenge for the 2018 Clamart Hackathon

## Objective

The goal for this challenge is to refactor the code so that it **no longer contains branching instruction** (if/then/else, tertiary operator, etc), while still passing the unit test suite.

Basically, the only constraint for the resulting class is to implement the `IAccount` interface and update the `CreateNewAccount` and `CreateNewAccountWithCustomUnfreezeAction` methods in the `AccountTests` class accordingly.

The [cyclomatic complexity](https://en.wikipedia.org/wiki/Cyclomatic_complexity) should be equal to 1 for every method.
The current state of the metrics, as per Visual Studio 2017, is as follow:

| Member                 | Cyclomatic Complexity| Lines of Code
|------------------------|----------------------|--------------
Close() : void           |1                     |1
Deposit(decimal) : void  |3                     |6
Freeze() : void          |4                     |1
VerifyHolder() : void    |1                     |1
Withdraw(decimal) : void |4                     |6

## References
This exercise was taken from the excellent course [Making Your C# Code More Object-oriented](https://app.pluralsight.com/library/courses/c-sharp-code-more-object-oriented) by Zoran Horvat, on Plurasight.

A possible solution by the course author can also be found [on Pluralsight](https://app.pluralsight.com/library/courses/c-sharp-code-more-object-oriented/exercise-files).

## Contribute

If you want to adapt it to any another language, feel free to submit a PR.