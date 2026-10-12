using System;
using System.IO;
using System.Reflection;

internal static class Program
{
    private static void Main()
    {
        TextReader originalIn = Console.In;
        TextWriter originalOut = Console.Out;
        StringWriter output = new();

        try
        {
            Console.SetOut(output);

            RunScenario("1", output);
            RunScenario("2", output);

            string result = output.ToString();
            Assert(typeof(Employee).IsValueType, "structured Employee must be a struct");
            Type oopEmployeeType = typeof(EmployeeManagerOOP)
                .GetMethod("AddEmployee")!
                .GetParameters()[0]
                .ParameterType;
            Assert(oopEmployeeType.Name == "OopEmployee" && oopEmployeeType.IsClass,
                "OOP manager must use a separate employee class");
            Assert(result.Contains("Add employee"), "menu must offer adding employees");
            Assert(result.Contains("Alice Nguyen"), "user-added employee must appear in list");
            Assert(result.Contains("Employee removed."), "user must be able to remove an employee");
            Assert(result.Contains("Employee not found."), "search must report missing employees");

            static void RunScenario(string style, StringWriter output)
            {
                output.GetStringBuilder().Clear();
                Console.SetIn(new StringReader(
                    $"{style}\n1\nAlice Nguyen\n30\nEngineer\n1\nBob Tran\n41\nTester\n4\n3\nAlice Nguyen\n2\nBob Tran\n3\nBob Tran\n5\n"));
                global::Programs.Main();
            }
        }
        finally
        {
            Console.SetIn(originalIn);
            Console.SetOut(originalOut);
        }

        Console.WriteLine("PASS");
    }

    private static void Assert(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
