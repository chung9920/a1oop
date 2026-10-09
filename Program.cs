using System;
public class Programs
{
    public static void Main()
    {
        EmployeeManager employeeManager = new EmployeeManager();

        // Adding employees
        employeeManager.AddEmployee(new Employee("John Doe", 30, "Software Engineer"));
        employeeManager.AddEmployee(new Employee("Jane Smith", 28, "Product Manager"));
        employeeManager.AddEmployee(new Employee("Mike Johnson", 35, "Quality Assurance Engineer"));

        // Displaying all employees
        Console.WriteLine("All Employees:");
        employeeManager.DisplayAllEmployees();

        // Searching for an employee
        Console.WriteLine("\nSearching for 'Jane Smith':");
        Employee foundEmployee = employeeManager.SearchEmployee("Jane Smith");
        if (foundEmployee != null)
        {
            Console.WriteLine($"Found: {foundEmployee.Name}, Age: {foundEmployee.Age}, Position: {foundEmployee.Position}");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }

        // Removing an employee
        Console.WriteLine("\nRemoving 'Mike Johnson':");
        bool isRemoved = employeeManager.RemoveEmployee("Mike Johnson");
        if (isRemoved)
        {
            Console.WriteLine("Employee removed successfully.");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }

        // Displaying all employees after removal
        Console.WriteLine("\nAll Employees after removal:");
        employeeManager.DisplayAllEmployees();
    }
}