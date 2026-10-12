using System.Collections.Generic;

// Structured-programming record. Procedures stay outside this struct.
public struct Employee
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

public struct EmployeeManager
{
    public List<Employee> Employees;

    public EmployeeManager()
    {
        Employees = new List<Employee>();
    }
}
