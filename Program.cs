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

    // OOP: EmployeeManagerOOP owns both data and operations.
    static void RunOopExample()
    {
        EmployeeManagerOOP manager = new EmployeeManagerOOP();
        AddSampleEmployees(manager);

        Console.WriteLine("\n========== OOP STYLE ==========");
        Console.WriteLine("Data + methods: EmployeeManagerOOP class");
        Console.WriteLine("Calls: manager.AddEmployee(), manager.SearchEmployee()");
        manager.DisplayAllEmployees();

        Console.WriteLine($"\nSearch result: {FormatEmployee(manager.SearchEmployee("Jane Smith"))}");
        manager.RemoveEmployee("Mike Johnson");
        Console.WriteLine("\nAfter removing Mike Johnson:");
        manager.DisplayAllEmployees();
    }

    // Structured programming: struct stores data; procedures stay outside it.
    static void RunStructuredExample()
    {
        EmployeeManager manager = new EmployeeManager();
        AddEmployee(ref manager, new Employee("John Doe", 30, "Software Engineer"));
        AddEmployee(ref manager, new Employee("Jane Smith", 28, "Product Manager"));
        AddEmployee(ref manager, new Employee("Mike Johnson", 35, "Quality Assurance Engineer"));

        Console.WriteLine("\n===== STRUCTURED STYLE =====");
        Console.WriteLine("Data: EmployeeManager struct");
        Console.WriteLine("Procedures: AddEmployee(), SearchEmployee(), RemoveEmployee()");
        DisplayAllEmployees(manager);

        Console.WriteLine($"\nSearch result: {FormatEmployee(SearchEmployee(manager, "Jane Smith"))}");
        RemoveEmployee(ref manager, "Mike Johnson");
        Console.WriteLine("\nAfter removing Mike Johnson:");
        DisplayAllEmployees(manager);
    }

    static void AddSampleEmployees(EmployeeManagerOOP manager)
    {
        manager.AddEmployee(new Employee("John Doe", 30, "Software Engineer"));
        manager.AddEmployee(new Employee("Jane Smith", 28, "Product Manager"));
        manager.AddEmployee(new Employee("Mike Johnson", 35, "Quality Assurance Engineer"));
    }

    static string FormatEmployee(Employee? employee)
    {
        return employee == null
            ? "Employee not found."
            : $"{employee.Name}, Age: {employee.Age}, Position: {employee.Position}";
    }

    static void AddEmployee(ref EmployeeManager manager, Employee employee)
    {
        manager.Employees.Add(employee);
    }

    static Employee? SearchEmployee(EmployeeManager manager, string name)
    {
        return manager.Employees.FirstOrDefault(employee => employee.Name == name);
    }

    static bool RemoveEmployee(ref EmployeeManager manager, string name)
    {
        Employee? employee = SearchEmployee(manager, name);
        return employee != null && manager.Employees.Remove(employee);
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
