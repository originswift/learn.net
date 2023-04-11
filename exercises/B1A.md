# Exercise B1A
> The end goal of this exercise is to introduce the basics of unit & integration testing in ASP.NET Core with xUnit & SpecFlow.NET/Gherkin.
> Before we get to the testing bits, we introduce opinionated structuring for simple .NET applications.
> Some OOP paradigms like inheritance, polymorphism, etc. are showcased here.

## Tasks
- [x] I. In the exercise solution directory, create a new solution named `Calculators`.
 - Path: `<repo root>/B1A/<your github username>/Calculators.sln`
 - Example: [../solutions/dystopiandev/B1A/Calculators.sln](../solutions/B1A/dystopiandev/Calculators.sln)
- [x] II. Add a new project (of class library type) named `Calculators.Features` to the solution.
- [x] III. Add an `ISimpleCalculator` interface to `Calculators.Features`:
   ```cs
   public interface ISimpleCalculator<T> where T : INumber<T>
   {
       T Add(T a, T b);
       T Subtract(T a, T b);
       T Multiply(T a, T b);
       T Divide(T a, T b);
   }
   ```
- [x] IV. Add a concrete implementation, `SimpleCalculator` for `ISimpleCalculator<T>` in `Calculators.Features`:
   ```cs
   public class SimpleCalculator<T> : ISimpleCalculator<T> where T : INumber<T>
   {
       public T Add(T a, T b)
       {
           throw new NotImplementedException();
       }

       public T Subtract(T a, T b)
       {
           throw new NotImplementedException();
       }

       public T Multiply(T a, T b)
       {
           throw new NotImplementedException();
       }

       public T Divide(T a, T b)
       {
           throw new NotImplementedException();
       }
   }
   ```
- [ ] V. Replace all `throw new NotImplementedException();` in the `SimpleCalculator<T>` class with the proper implementation details. Run unit tests in the solution via your IDE or `dotnet test` in shell. This step is complete when all tests pass.
- [x] VI. Add a SpecFlow.NET project with the following `SimpleCalculator.feature` Gherkin:
   ```gherkin
   Feature: SimpleCalculator
   In order to perform basic arithmetic operations
   As a developer
   I want to use the concrete SimpleCalculator class

       Scenario Outline: Add two positive numbers
           When I call Add with arguments <a> and <b>
           Then the returned value should be <c>

           Examples:
             | a     | b     | c     |
             | 2     | 3     | 5     |
             | 0     | 0     | 0     |
             | 0.5   | 0.5   | 1     |
             | -1    | 1     | 0     |
             | -2    | -3    | -5    |
             | 10000 | 20000 | 30000 |

       Scenario Outline: Subtract two numbers
           When I call Subtract with arguments <a> and <b>
           Then the returned value should be <c>

           Examples:
             | a     | b     | c     |
             | 2     | 3     | -1    |
             | 0     | 0     | 0     |
             | 0.5   | 0.5   | 0     |
             | -1    | 1     | -2    |
             | -2    | -3    | 1     |
             | 20000 | 10000 | 10000 |

       Scenario Outline: Multiply two numbers
           When I call Multiply with arguments <a> and <b>
           Then the returned value should be <c>

           Examples:
             | a     | b   | c    |
             | 2     | 3   | 6    |
             | 0     | 0   | 0    |
             | 0.5   | 0.5 | 0.25 |
             | -1    | 1   | -1   |
             | -2    | -3  | 6    |
             | 10000 | 0   | 0    |

       Scenario Outline: Divide two numbers
           When I call Divide with arguments <a> and <b>
           Then the returned value should be <c>

           Examples:
             | a     | b   | c    |
             | 6     | 3   | 2    |
             | 0     | 1   | 0    |
             | 0.5   | 0.5 | 1    |
             | -1    | 1   | -1   |
             | -6    | -3  | 2    |
             | 10000 | 2   | 5000 |

       Scenario Outline: Divide by zero
           When I call Divide with arguments <a> and 0
           Then a DivideByZeroException should be thrown

           Examples:
             | a     |
             | 2     |
             | 0     |
             | 0.5   |
             | -1    |
             | -6    |
             | 10000 |
   ```
- [x] VII. Add the following step bindings in `SimpleCalculatorSteps.cs`:
   ```cs
   [Binding]
   public class SimpleCalculatorSteps
   {
       private readonly ISimpleCalculator<decimal> calculator;
       private decimal result;
       private readonly ScenarioContext context;

       public SimpleCalculatorSteps(ScenarioContext context)
       {
           this.context = context;
           calculator = new SimpleCalculator<decimal>();
       }

       [When(@"I call Add with arguments (.*) and (.*)")]
       public void WhenICallAddWithArgumentsAnd(decimal a, decimal b)
       {
           result = calculator.Add(a, b);
       }

       [When(@"I call Subtract with arguments (.*) and (.*)")]
       public void WhenICallSubtractWithArgumentsAnd(decimal a, decimal b)
       {
           result = calculator.Subtract(a, b);
       }

       [When(@"I call Multiply with arguments (.*) and (.*)")]
       public void WhenICallMultiplyWithArgumentsAnd(decimal a, decimal b)
       {
           result = calculator.Multiply(a, b);
       }

       [When(@"I call Divide with arguments (.*) and (.*)")]
       public void WhenICallDivideWithArgumentsAnd(decimal a, decimal b)
       {
           try
           {
               result = calculator.Divide(a, b);
           }
           catch (DivideByZeroException ex)
           {
               context["exception"] = ex;
           }
       }

       [Then(@"the returned value should be (.*)")]
       public void ThenTheReturnedValueShouldBe(decimal expected)
       {
           result.Should().Be(expected);
       }

       [Then(@"a DivideByZeroException should be thrown")]
       public void ThenADivideByZeroExceptionShouldBeThrown()
       {
           context.ContainsKey("exception").Should().BeTrue();
           context["exception"].Should().BeOfType<DivideByZeroException>();
       }
   }
   ```
- [ ] VIII. [Create a Pull Request](https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/proposing-changes-to-your-work-with-pull-requests/creating-a-pull-request) targeting the `main` branch of this repository.
