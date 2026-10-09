using System.Collections.Generic;

public class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Position { get; set; }

    public Employee(string name, int age, string position)
    {
        Name = name;
        Age = age;
        Position = position;
    }
}

// Structured-programming data record. Procedures stay outside this struct.
public struct EmployeeManager
{
    public List<Employee> Employees;

    public EmployeeManager()
    {
        Employees = new List<Employee>();
    }
}
