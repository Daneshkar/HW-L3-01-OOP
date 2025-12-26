
using HW_L3_01_OOP.Task1;
using HW_L3_01_OOP.Task2;
using HW_L3_01_OOP.Task3;
using HW_L3_01_OOP.Task4;
using System;
using System.Collections.Generic;
using Person = HW_L3_01_OOP.Task2.Person;



//task1
Library library = new Library();

Book book1 = new Book("Clean Code", "Robert C. Martin", "12345");
Book book2 = new Book("C# in Depth", "Jon Skeet", "67890");

library.AddBook(book1);
library.AddBook(book2);

library.BorrowBook("Clean Code");
library.BorrowBook("Clean Code");
library.ReturnBook("Clean Code");


//task2
List<Person> people =
[
    new Student { Name = "Ali", Age = 20, StudentID = "S123", Major = "Computer Science" },
            new Professor { Name = "Dr. Sara", Age = 45, ProfessorID = "P456", Subject = "Math" },
        ];

foreach (var person in people)
{
    Console.WriteLine(person.GetDetails());
}



//task3
Product shirt = new Clothing { Name = "T-Shirt", Price = 100, Size = "M", Material = "Cotton" };
Product laptop = new Electronic { Name = "Laptop", Price = 2000, WarrantyPeriod = 24 };

IDiscountable discountShirt = (IDiscountable)shirt;
discountShirt.ApplyDiscount(10); // 10% تخفیف

IDiscountable discountLaptop = (IDiscountable)laptop;
discountLaptop.ApplyDiscount(5); // 5% تخفیف

Console.WriteLine(shirt.GetProductDetails());
Console.WriteLine(laptop.GetProductDetails());

//task4
Hospital hospital = Hospital.Instance;



// Create doctors
var doc1 = HospitalFactory.CreateDoctor("Dr. Smith", 45, "123456789", 1, "Cardiology");
hospital.Doctors.Add((Doctor)doc1);

// Create rooms
hospital.Rooms.Add((Room)HospitalFactory.CreateRoom(101, 2));
hospital.Rooms.Add((Room)HospitalFactory.CreateRoom(102, 1));

// Create patients
var pat1 = HospitalFactory.CreatePatient("Alice", 30, "987654321", 1);
var pat2 = HospitalFactory.CreatePatient("Bob", 40, "555555555", 2);
var pat3 = HospitalFactory.CreatePatient("Charlie", 25, "111111111", 3);

// Admit patients
hospital.AdmitPatient((Patient)pat1);
hospital.AdmitPatient((Patient)pat2);
hospital.AdmitPatient((Patient)pat3);


// Doctor diagnoses

doc1.Diagnose(pat1, "Flu");
doc1.Diagnose(pat2, "Cold");

// Display patient details
pat1.GetDetails();
pat2.GetDetails();

// Discharge a patient
hospital.DischargePatient((Patient)pat1);

