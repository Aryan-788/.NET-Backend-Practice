using System;

public class Product
{
    public int ProductId {get; set;}
    public string Name {get; set;}
    public double Price {get; set;}
    public int Quantity {get; set;}
    public bool IsPremiumCustomer{get; set;}
}

public class DiscountEngine
{
    public void CheckDiscount(Product product, string scheme, Predicate<Product> rule)
    {
        bool eligible = rule(product);

        Console.WriteLine("========= DISCOUNT ELIGIBILITY =========");
        Console.WriteLine($"Product  : {product.Name}");
        Console.WriteLine($"Scheme   : {scheme}");
        Console.WriteLine($"Eligible : {eligible}");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine();
    }
}

public class Solution
{
    public static void Start()
    {
        Product product = new Product
        {
            ProductId = 901,
            Name = "Laptop",
            Price = 60000,
            Quantity = 12,
            IsPremiumCustomer = true
            
        };

        Predicate<Product> festivalDiscountRule = p => p.Price >= 5000;
        Predicate<Product> bulkDiscountRule = p => p.Quantity >= 10;
        Predicate<Product> premiumCustomerRule = p => p.IsPremiumCustomer;

        DiscountEngine engine = new DiscountEngine();

        engine.CheckDiscount(product, "Festival", festivalDiscountRule);

        engine.CheckDiscount(product, "Bulk", bulkDiscountRule);

        engine.CheckDiscount(product, "Premium", premiumCustomerRule);
    }
}