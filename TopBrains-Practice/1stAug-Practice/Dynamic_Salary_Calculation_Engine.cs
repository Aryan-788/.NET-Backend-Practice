public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public double BaseSalary { get; set; }
    public double Bonus { get; set; }
    public double Allowance { get; set; }
    public double Commission { get; set; }
}

public class SalaryEngine
{
    public void Calculate(Employee employee, string department, Func<Employee, double> calculator)
    {
        double salary = calculator(employee);

        Console.WriteLine("======== Salary Calculation Result ========");
        Console.WriteLine($"Employee Name: {employee.Name}");
        Console.WriteLine($"Department: {department}");
        Console.WriteLine($"Salary: {salary}");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine();
    }
}

public class Ques7
{
    public static void Start()
    {

        Employee employee = new Employee
        {
            EmployeeId = 601,
            Name = "Ananya",
            BaseSalary = 50000,
            Bonus = 10000,
            Allowance = 8000,
            Commission = 12000
        };

        Func<Employee, double> ITSalaryRule = e => e.BaseSalary + e.Bonus;
        Func<Employee, double> HRSalaryRule = e => e.BaseSalary + e.Allowance;
        Func<Employee, double> SalesSalaryRule = e => e.BaseSalary + e.Commission;

        SalaryEngine engine = new SalaryEngine();

        engine.Calculate(employee, "IT", ITSalaryRule);
        engine.Calculate(employee, "HR", HRSalaryRule);
        engine.Calculate(employee, "Sales", SalesSalaryRule);

    }
}