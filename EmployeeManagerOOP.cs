using System;
using System.Collections.Generic;
using System.Linq;

public class EmployeeManagerOOP
{
    private readonly List<Employee> employees = new();

    public void AddEmployee(Employee employee)
    {
        ArgumentNullException.ThrowIfNull(employee);
        employees.Add(employee);
    }

    public Employee? SearchEmployee(string name)
    {
        return employees.FirstOrDefault(employee => employee.Name == name);
    }

    public bool RemoveEmployee(string name)
    {
        Employee? employee = SearchEmployee(name);
        return employee != null && employees.Remove(employee);
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
