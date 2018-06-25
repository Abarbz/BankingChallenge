# BankingChallenge
This is a suggestion challenge for the 2018 Clamart Hackathon

The goal for this challenge is to refactor the code so that it **no longer contains branching instruction** (if/then/else, tertiary operator, etc), while still passing the unit test suite.

The [cyclomatic complexity](https://en.wikipedia.org/wiki/Cyclomatic_complexity) should be equal to 1 for every method.
The current stat of the metrics, as per Visual Studio 2017, is as follow:

|Member|Maintainability Index|Cyclomatic Complexity|Depth of Inheritance|Class Coupling|Lines of Code
|___|___|___|___|___|___
Close() : void|98|1||0|1
Deposit(decimal) : void|71|3||2|6
Freeze() : void|98|1||0|1
VerifyHolder() : void|98|1||0|1
Withdraw(decimal) : void|69|4||2|6

This exercise was taken from the excellent course [Making Your C# Code More Object-oriented](https://app.pluralsight.com/library/courses/c-sharp-code-more-object-oriented) by Zoran Horvat, on Plurasight.

If you want to adapt it to any another language, feel free to submit a PR.