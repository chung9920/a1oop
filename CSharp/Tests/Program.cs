using System;
using System.IO;

internal static class Program
{
    private static void Main()
    {
        string result = RunScenario(
            "4\n1\nAlice Nguyen\n30\nEngineer\n1\nBob Tran\n41\nTester\n4\n3\nAlice Nguyen\n2\nBob Tran\n3\nBob Tran\n2\nMissing\n5\n");
        Assert(result.Contains("No employees available."), "empty manager must be reported");
        Assert(result.Contains("Alice Nguyen, Age: 30, Position: Engineer"),
            "user-added employee must appear in list and search");
        Assert(result.Contains("Bob Tran, Age: 41, Position: Tester"), "second employee must be listed");
        Assert(result.Contains("Employee removed."), "user must be able to remove an employee");
        Assert(result.Contains("Employee not found."), "missing employee must be reported");
        Assert(!result.Contains("Choose employee manager style"), "C# must run OOP directly");

        result = RunScenario("invalid\n1\n \n Alice \nno\n0\n-1\n2147483648\n30\n \n Engineer \n3\nAlice\n5\n");
        Assert(result.Contains("Invalid choice."), "invalid menu input must be rejected");
        Assert(result.Contains("Value cannot be empty."), "blank fields must be rejected");
        Assert(result.Contains("Age must be a positive whole number."), "invalid ages must be rejected");
        Assert(result.Contains("Alice, Age: 30, Position: Engineer"), "valid input must survive retries");

        Type employeeType = typeof(EmployeeManagerOOP).GetMethod("AddEmployee")!
            .GetParameters()[0].ParameterType;
        Assert(employeeType.IsClass, "OOP manager must use an employee class");
        Assert(typeof(EmployeeManagerOOP).Assembly.GetType("EmployeeManager") == null,
            "structured C# manager must be removed");
        Console.WriteLine("PASS");
    }

    private static string RunScenario(string input)
    {
        TextReader originalIn = Console.In;
        TextWriter originalOut = Console.Out;
        using StringWriter output = new();
        try
        {
            Console.SetIn(new StringReader(input));
            Console.SetOut(output);
            global::Programs.Main();
            return output.ToString();
        }
        finally
        {
            Console.SetIn(originalIn);
            Console.SetOut(originalOut);
        }
    }

    private static void Assert(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
