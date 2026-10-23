using System;

public class Programs
{
    public static void Main()
    {
        EmployeeManagerOOP manager = new();

        Console.WriteLine("\n========== OOP STYLE (C#) ==========");
        Console.WriteLine("Data + methods: EmployeeManagerOOP class");
        RunOopMenu(manager);
    }

    static void RunOopMenu(EmployeeManagerOOP manager)
    {
        while (true)
        {
            PrintMenu();
            switch (Console.ReadLine())
            {
                case "1":
                    manager.AddEmployee(ReadOopEmployee());
                    Console.WriteLine("Employee added.");
                    break;
                case "2":
                    Console.Write("Enter employee name to remove: ");
                    Console.WriteLine(manager.RemoveEmployee(Console.ReadLine()?.Trim() ?? "")
                        ? "Employee removed."
                        : "Employee not found.");
                    break;
                case "3":
                    Console.Write("Enter employee name to search: ");
                    Console.WriteLine(FormatEmployee(manager.SearchEmployee(Console.ReadLine()?.Trim() ?? "")));
                    break;
                case "4":
                    manager.DisplayAllEmployees();
                    break;
                case "5":
                case null:
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void PrintMenu()
    {
        Console.WriteLine("\n1. Add employee");
        Console.WriteLine("2. Remove employee");
        Console.WriteLine("3. Search employee");
        Console.WriteLine("4. Display all employees");
        Console.WriteLine("5. Exit");
        Console.Write("Enter choice: ");
    }

    static OopEmployee ReadOopEmployee()
    {
        (string name, int age, string position) = ReadEmployeeValues();
        return new OopEmployee(name, age, position);
    }

    static (string Name, int Age, string Position) ReadEmployeeValues()
    {
        Console.Write("Enter name: ");
        string name = ReadRequiredValue();

        int age;
        while (true)
        {
            Console.Write("Enter age: ");
            if (int.TryParse(Console.ReadLine(), out age) && age > 0)
            {
                break;
            }

            Console.WriteLine("Age must be a positive whole number.");
        }

        Console.Write("Enter position: ");
        string position = ReadRequiredValue();
        return (name, age, position);
    }

    static string ReadRequiredValue()
    {
        while (true)
        {
            string value = Console.ReadLine()?.Trim() ?? "";
            if (!string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            Console.WriteLine("Value cannot be empty.");
            Console.Write("Enter value: ");
        }
    }

    static string FormatEmployee(OopEmployee? employee)
    {
        return employee == null
            ? "Employee not found."
            : $"{employee.Name}, Age: {employee.Age}, Position: {employee.Position}";
    }
}
