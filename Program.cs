using System;
using System.Linq;

public class Programs
{
    public static void Main()
    {
        Console.WriteLine("Choose employee manager style:");
        Console.WriteLine("1. OOP - class with methods");
        Console.WriteLine("2. Structured - struct with separate procedures");
        Console.Write("Enter choice: ");

        switch (Console.ReadLine())
        {
            case "1":
                RunOopExample();
                break;
            case "2":
                RunStructuredExample();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static void RunOopExample()
    {
        EmployeeManagerOOP manager = new();

        Console.WriteLine("\n========== OOP STYLE ==========");
        Console.WriteLine("Data + methods: EmployeeManagerOOP class");
        RunOopMenu(manager);
    }

    static void RunStructuredExample()
    {
        EmployeeManager manager = new();

        Console.WriteLine("\n===== STRUCTURED STYLE =====");
        Console.WriteLine("Data: EmployeeManager and Employee structs");
        Console.WriteLine("Procedures: AddEmployee(), SearchEmployee(), RemoveEmployee()");
        RunStructuredMenu(ref manager);
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
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void RunStructuredMenu(ref EmployeeManager manager)
    {
        while (true)
        {
            PrintMenu();
            switch (Console.ReadLine())
            {
                case "1":
                    AddEmployee(ref manager, ReadStructuredEmployee());
                    Console.WriteLine("Employee added.");
                    break;
                case "2":
                    Console.Write("Enter employee name to remove: ");
                    Console.WriteLine(RemoveEmployee(ref manager, Console.ReadLine()?.Trim() ?? "")
                        ? "Employee removed."
                        : "Employee not found.");
                    break;
                case "3":
                    Console.Write("Enter employee name to search: ");
                    Console.WriteLine(FormatEmployee(SearchEmployee(manager, Console.ReadLine()?.Trim() ?? "")));
                    break;
                case "4":
                    DisplayAllEmployees(manager);
                    break;
                case "5":
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

    static Employee ReadStructuredEmployee()
    {
        (string name, int age, string position) = ReadEmployeeValues();
        return new Employee(name, age, position);
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

    static string FormatEmployee(Employee? employee)
    {
        return employee == null
            ? "Employee not found."
            : $"{employee.Value.Name}, Age: {employee.Value.Age}, Position: {employee.Value.Position}";
    }

    // Structured procedures operate on EmployeeManager and Employee from outside the structs.
    static void AddEmployee(ref EmployeeManager manager, Employee employee)
    {
        manager.Employees.Add(employee);
    }

    static Employee? SearchEmployee(EmployeeManager manager, string name)
    {
        foreach (Employee employee in manager.Employees)
        {
            if (employee.Name == name)
            {
                return employee;
            }
        }

        return null;
    }

    static bool RemoveEmployee(ref EmployeeManager manager, string name)
    {
        Employee? employee = SearchEmployee(manager, name);
        return employee.HasValue && manager.Employees.Remove(employee.Value);
    }

    static void DisplayAllEmployees(EmployeeManager manager)
    {
        if (manager.Employees.Count == 0)
        {
            Console.WriteLine("No employees available.");
            return;
        }

        foreach (Employee employee in manager.Employees)
        {
            Console.WriteLine($"{employee.Name}, Age: {employee.Age}, Position: {employee.Position}");
        }
    }
}
