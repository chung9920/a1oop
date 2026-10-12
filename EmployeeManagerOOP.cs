using System;
using System.Collections.Generic;
using System.Linq;

public class OopEmployee
{
    public string Name { get; }
    public int Age { get; }
    public string Position { get; }

    public OopEmployee(string name, int age, string position)
    {
        Name = name;
        Age = age;
        Position = position;
    }
}

public class EmployeeManagerOOP
{
    private readonly List<OopEmployee> employees = new();

    public void AddEmployee(OopEmployee employee)
    {
        ArgumentNullException.ThrowIfNull(employee);
        employees.Add(employee);
    }

    public OopEmployee? SearchEmployee(string name)
    {
        return employees.FirstOrDefault(employee => employee.Name == name);
    }

    public bool RemoveEmployee(string name)
    {
        OopEmployee? employee = SearchEmployee(name);
        return employee != null && employees.Remove(employee);
    }

    public void DisplayAllEmployees()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees available.");
            return;
        }

        foreach (OopEmployee employee in employees)
        {
            Console.WriteLine($"{employee.Name}, Age: {employee.Age}, Position: {employee.Position}");
        }
    }
}
