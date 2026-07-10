using System;
using System.Collections.Generic;

public interface IDiscountable
{
    void ApplyDiscount(double percentage);
}

public class Product
{
    public string Name { get; set; }
    public double Price { get; set; }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public virtual string GetProductDetails()
    {
        return $"Product: {Name}, Price: ${Price:F2}";
    }
}

public class Electronic : Product, IDiscountable
{
    public int WarrantyPeriod { get; set; }

    public Electronic(string name, double price, int warrantyPeriod) : base(name, price)
    {
        WarrantyPeriod = warrantyPeriod;
    }

    public void ApplyDiscount(double percentage)
    {
        Price -= Price * (percentage / 100);
    }

    public override string GetProductDetails()
    {
        return $"{base.GetProductDetails()}, Warranty: {WarrantyPeriod} months";
    }
}

public class Clothing : Product
{
    public string Size { get; set; }
    public string Material { get; set; }

    public Clothing(string name, double price, string size, string material) : base(name, price)
    {
        Size = size;
        Material = material;
    }

    public override string GetProductDetails()
    {
        return $"{base.GetProductDetails()}, Size: {Size}, Material: {Material}";
    }
}

class Program
{
    static void Main()
    {
        List<Product> store = new List<Product>();

        Electronic laptop = new Electronic("Laptop", 1200, 24);
        Clothing jacket = new Clothing("mobile", 150, "L", "felez");

        laptop.ApplyDiscount(10);

        store.Add(laptop);
        store.Add(jacket);

        foreach (var product in store)
        {
            Console.WriteLine(product.GetProductDetails());
        }
    }
}