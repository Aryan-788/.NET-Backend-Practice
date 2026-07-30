using System;
using System.Transactions;
public interface ICustomer
{
    public double CalculateBill(double unitConsumed, double rate, double fixedCharge);
}

public class ResidentialCustomer : ICustomer
{

    public double CalculateBill(double unitConsumed, double rate, double fixedCharge)
    {
        return (unitConsumed * rate) + fixedCharge;
    }


}

public class CommercialCustomer : ICustomer
{
    public double CalculateBill(double unitConsumed, double rate, double fixedCharge)
    {
        double charge = unitConsumed * rate;
        return (charge * 1.10) + fixedCharge;
    }

}

class Program
{
    public static void Main()
    {
        Console.WriteLine("===== Electricity Bill Calculator =====");

        // Customer Type
        Console.Write("Enter Customer Type (Residential/Commercial): ");
        string customerType = Console.ReadLine().Trim().ToLower();

        // Unit Consumed
        double units;

        while (true)
        {
            Console.Write("Enter Units Consumed: ");
            if (double.TryParse(Console.ReadLine(), out units) && units >= 0)
            {
                break;
            }
            Console.WriteLine("Invalid input. Please enter a valid number of units.");
        }

        double rate;
        while (true)
        {
            Console.Write("Enter Rate per Unit: ");
            if (double.TryParse(Console.ReadLine(), out rate) && rate >= 0)
                break;

            Console.WriteLine("Invalid input! Please enter a valid number.");
        }

        double fixedCharges;
        while (true)
        {
            Console.Write("Enter Fixed Charges: ");
            if (double.TryParse(Console.ReadLine(), out fixedCharges) && fixedCharges >= 0)
                break;

            Console.WriteLine("Invalid input! Please enter a valid number.");
        }


        ICustomer customer = null;
        if (customerType == "residential")
        {
            customer = new ResidentialCustomer();
        }
        else if (customerType == "commercial")
        {
            customer = new CommercialCustomer();
        }
        else
        {
            Console.WriteLine("Invalid Customer Type! Please enter either 'Residential' or 'Commercial'.");
            return;
        }

        double bill = customer.CalculateBill(units, rate, fixedCharges);

        Console.WriteLine("\n===== Bill Details =====");
        Console.WriteLine("Customer Type : " + customerType);
        Console.WriteLine("Units         : " + units);
        Console.WriteLine("Rate          : " + rate);
        Console.WriteLine("Fixed Charges : " + fixedCharges);
        Console.WriteLine("Total Bill    : " + bill);

    }
}