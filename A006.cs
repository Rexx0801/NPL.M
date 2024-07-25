using System;
using System.Collections.Generic;

public abstract class Employee
{
    public string SSN { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public Employee() { }

    public Employee(string ssn, string firstName, string lastName)
    {
        SSN = ssn;
        FirstName = firstName;
        LastName = lastName;
    }

    public abstract void Display();

    public override string ToString()
    {
        return $"SSN: {SSN}, FirstName: {FirstName}, LastName: {LastName}, BirthDate: {BirthDate.ToString("dd/MM/yyyy")}, Phone: {Phone}, Email: {Email}";
    }
}

public class SalariedEmployee : Employee
{
    public double CommissionRate { get; set; }
    public double GrossSales { get; set; }
    public double BasicSalary { get; set; }

    public SalariedEmployee() { }

    public SalariedEmployee(string ssn, string firstName, string lastName, double commissionRate, double grossSales, double basicSalary)
        : base(ssn, firstName, lastName)
    {
        CommissionRate = commissionRate;
        GrossSales = grossSales;
        BasicSalary = basicSalary;
    }

    public override void Display()
    {
        Console.WriteLine(this.ToString() + $", CommissionRate: {CommissionRate}, GrossSales: {GrossSales}, BasicSalary: {BasicSalary}");
    }

    public override string ToString()
    {
        return base.ToString() + $", CommissionRate: {CommissionRate}, GrossSales: {GrossSales}, BasicSalary: {BasicSalary}";
    }
}

public class HourlyEmployee : Employee
{
    public double Wage { get; set; }
    public double WorkingHour { get; set; }

    public HourlyEmployee() { }

    public HourlyEmployee(string ssn, string firstName, string lastName, double wage, double workingHour)
        : base(ssn, firstName, lastName)
    {
        Wage = wage;
        WorkingHour = workingHour;
    }

    public override void Display()
    {
        Console.WriteLine(this.ToString() + $", Wage: {Wage}, WorkingHour: {WorkingHour}");
    }

    public override string ToString()
    {
        return base.ToString() + $", Wage: {Wage}, WorkingHour: {WorkingHour}";
    }
}

class Program
{
    static List<Employee> employees = new List<Employee>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("===== Assignment 06 - EmployeeManagement =====");
            Console.WriteLine("Please select the admin area you require:");
            Console.WriteLine("1. Import Employee.");
            Console.WriteLine("2. Display Employees Information.");
            Console.WriteLine("3. Search Employee.");
            Console.WriteLine("4. Exit.");
            Console.Write("Enter Menu Option Number: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ImportEmployee();
                    break;
                case 2:
                    DisplayEmployees();
                    break;
                case 3:
                    SearchEmployee();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void ImportEmployee()
    {
        Console.WriteLine("===== Import Employee =====");
        Console.WriteLine("1. Salaried Employee.");
        Console.WriteLine("2. Hourly Employee.");
        Console.WriteLine("3. Main Menu.");
        Console.Write("Enter Menu Option Number: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                ImportSalariedEmployee();
                break;
            case 2:
                ImportHourlyEmployee();
                break;
            case 3:
                return;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }

    static void ImportSalariedEmployee()
    {
        Console.Write("Enter SSN: ");
        string ssn = Console.ReadLine();
        Console.Write("Enter First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Enter Last Name: ");
        string lastName = Console.ReadLine();
        Console.Write("Enter Birth Date (dd/MM/yyyy): ");
        DateTime birthDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        Console.Write("Enter Phone: ");
        string phone = Console.ReadLine();
        Console.Write("Enter Email: ");
        string email = Console.ReadLine();
        Console.Write("Enter Commission Rate: ");
        double commissionRate = double.Parse(Console.ReadLine());
        Console.Write("Enter Gross Sales: ");
        double grossSales = double.Parse(Console.ReadLine());
        Console.Write("Enter Basic Salary: ");
        double basicSalary = double.Parse(Console.ReadLine());

        SalariedEmployee salariedEmployee = new SalariedEmployee(ssn, firstName, lastName, commissionRate, grossSales, basicSalary)
        {
            BirthDate = birthDate,
            Phone = phone,
            Email = email
        };
        employees.Add(salariedEmployee);

        Console.WriteLine("Salaried Employee added successfully.");
    }

    static void ImportHourlyEmployee()
    {
        Console.Write("Enter SSN: ");
        string ssn = Console.ReadLine();
        Console.Write("Enter First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Enter Last Name: ");
        string lastName = Console.ReadLine();
        Console.Write("Enter Birth Date (dd/MM/yyyy): ");
        DateTime birthDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        Console.Write("Enter Phone: ");
        string phone = Console.ReadLine();
        Console.Write("Enter Email: ");
        string email = Console.ReadLine();
        Console.Write("Enter Wage: ");
        double wage = double.Parse(Console.ReadLine());
        Console.Write("Enter Working Hours: ");
        double workingHours = double.Parse(Console.ReadLine());

        HourlyEmployee hourlyEmployee = new HourlyEmployee(ssn, firstName, lastName, wage, workingHours)
        {
            BirthDate = birthDate,
            Phone = phone,
            Email = email
        };
        employees.Add(hourlyEmployee);

        Console.WriteLine("Hourly Employee added successfully.");
    }

    static void DisplayEmployees()
    {
        Console.WriteLine("===== Display Employees Information =====");
        foreach (var employee in employees)
        {
            employee.Display();
        }
    }

    static void SearchEmployee()
    {
        Console.WriteLine("===== Search Employee =====");
        Console.WriteLine("1. By Employee Type.");
        Console.WriteLine("2. By Employee Name.");
        Console.WriteLine("3. Main Menu.");
        Console.Write("Enter Menu Option Number: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                SearchByEmployeeType();
                break;
            case 2:
                SearchByEmployeeName();
                break;
            case 3:
                return;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }

    static void SearchByEmployeeType()
    {
        Console.Write("Enter Employee Type (Salaried/Hourly): ");
        string type = Console.ReadLine();

        foreach (var employee in employees)
        {
            if ((type.ToLower() == "salaried" && employee is SalariedEmployee) ||
                (type.ToLower() == "hourly" && employee is HourlyEmployee))
            {
                employee.Display();
            }
        }
    }

    static void SearchByEmployeeName()
    {
        Console.Write("Enter Employee Name: ");
        string name = Console.ReadLine();

        foreach (var employee in employees)
        {
            if (employee.FirstName.ToLower().Contains(name.ToLower()) || employee.LastName.ToLower().Contains(name.ToLower()))
            {
                employee.Display();
            }
        }
    }
}
