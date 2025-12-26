using System;
using System.Collections.Generic;
using System.Text;

namespace HW_L3_01_OOP.Task3
{

    interface IDiscountable
    {
        void ApplyDiscount(decimal percentage);
    }

    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual string GetProductDetails()
        {
            return $"Name: {Name}, Price: {Price}";
        }
    }


    class Clothing : Product, IDiscountable
    {
        public string Size { get; set; }
        public string Material { get; set; }

        public void ApplyDiscount(decimal percentage)
        {
            Price -= Price * percentage / 100;
        }

        public override string GetProductDetails()
        {
            return base.GetProductDetails() + $", Size: {Size}, Material: {Material}";
        }
    }

    class Electronic : Product, IDiscountable
    {
        public int WarrantyPeriod { get; set; } // به ماه
        public void ApplyDiscount(decimal percentage)
        {
            Price -= Price * percentage / 100;
        }

        public override string GetProductDetails()
        {
            return base.GetProductDetails() + $", Warranty: {WarrantyPeriod} months";
        }
    }



}
