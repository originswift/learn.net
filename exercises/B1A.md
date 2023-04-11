# Exercise B1A
> The end goal of this exercise is to introduce the basics of unit & integration testing in ASP.NET Core with xUnit & SpecFlow.NET/Gherkin.
> Before we get to the testing bits, we introduce opinionated structuring for simple .NET applications.
> Some OOP paradigms like inheritance, polymorphism, etc. are showcased here.

## Tasks
- [x] 1. In the exercise solution directory, create a new solution named `Calculators`.
 - Path: `<repo root>/<your github username>/B1A/Calculators.sln`
 - Example: [../solutions/dystopiandev/B1A/Calculators.sln](../solutions/B1A/dystopiandev/Calculators.sln)
- [x] 2. Add a new project (of class library type) named `Calculators.Features` to the solution.
- [x] 3. Add an `ISimpleCalculator` interface to `Calculators.Features`:
   ```cs
   public interface ISimpleCalculator<T>
    where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
   {
       T Add(T a, T b);
       T Subtract(T a, T b);
       T Multiply(T a, T b);
       T Divide(T a, T b);
   }
   ```
- [x] 4. Add a concrete implementation, `SimpleCalculator` for `ISimpleCalculator<T>` in `Calculators.Features`:
   ```cs
   public class SimpleCalculator<T> : ISimpleCalculator<T>
    where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
   {
       // TODO: Implement
   }
   ```
- [ ] 5. Complete the TODO in the `SimpleCalculator<T>` class. Run unit tests in the solution via your IDE or `dotnet test` in shell. This step is complete when all tests pass.
- [ ] 6. [Create a Pull Request](https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/proposing-changes-to-your-work-with-pull-requests/creating-a-pull-request) targeting the `main` branch of this repository.
