Technical Competency Test
This is a set of progressively more difficult steps that aims to cover the technology knowledge, methodology experience and related skills expected of a senior software engineer in the TMP team.


##### Consider the following simple C# interface:

 ```csharp
 public interface ISimpleCalculator
    {
        int Add(int start, int amount);
        int Subtract(int start, int amount);
        int Multiply(int start, int amount);
        int Divide(int start, int amount);
    }
 ```

#### Visual Studio
- Create an empty solution called CalculatorTest.
-	Create a class library containing the interface above.
-	Create a C# class to realize the interface as a C# class.
#### TDD
-	Create a class library containing a suite of unit tests for the interface using test-driven design principles. 
#### C#
-	Add a **IDiagnostics** interface to the calculator class to allow each method to report its calculation results to the console. 
-	Mock the diagnostics interface and use it to refactor the unit tests so that the test suite checks that the diagnostics interface is called with expected values.
-	 
#### IoC / Dependency Injection
-	Implement the diagnostics interface and inject it into the calculator at runtime.
-	Implement a dummy diagnostics interface that doesn’t report anything. 
#### Entity Framework / SQL Server
-	Using the sample SQL Server Database, create an Entity Framework ORM layer to allow the console application to write the diagnostics information to the database.
-	Implement a class that realizes the diagnostics interface and modify the console application so that it outputs the diagnostics to the database using EF.
-	Implement another class that does not use EF and instead uses a stored procedure and ADO.NET to write the diagnostics data.
#### Web Services
-	Create a simple web service that provides access to the calculator class via a REST API using HTTP. 
-	Modify the console application to access the calculator web service to perform its calculations instead of using an internal class. 
