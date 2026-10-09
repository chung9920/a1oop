using System;
using System.Collections.Generic;
using System.Linq;

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

public class EmployeeManager
{
    private List<Employee> employees = new List<Employee>();

    public void AddEmployee(Employee employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee));

        employees.Add(employee);
    }

    public Employee SearchEmployee(string name)
    {
        return employees.FirstOrDefault(e => e.Name == name);
    }

    public bool RemoveEmployee(string name)
    {
        Employee employeeToRemove = SearchEmployee(name);
        if (employeeToRemove == null)
            return false;

        return employees.Remove(employeeToRemove);
    }

    public void DisplayAllEmployees()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees available.");
            return;
        }

        foreach (Employee employee in employees)
        {
            Console.WriteLine($"{employee.Name}, Age: {employee.Age}, Position: {employee.Position}");
        }
    }
}