using System;
using System.Collections.Generic;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual string GetDetails()
    {
        return $"Name: {Name}, Age: {Age}";
    }
}

public class Student : Person
{
    public string StudentID { get; set; }
    public string Major { get; set; }

    public Student(string name, int age, string studentId, string major) : base(name, age)
    {
        StudentID = studentId;
        Major = major;
    }

    public override string GetDetails()
    {
        return $"{base.GetDetails()}, Student ID: {StudentID}, Major: {Major}";
    }
}

public class Professor : Person
{
    public string ProfessorId { get; set; }
    public string Subject { get; set; }

    public Professor(string name, int age, string professorId, string subject) : base(name, age)
    {
        ProfessorId = professorId;
        Subject = subject;
    }

    public override string GetDetails()
    {
        return $"{base.GetDetails()}, Professor ID: {ProfessorId}, Subject: {Subject}";
    }
}

class Program
{
    static void Main()
    {
        List<Person> people = new List<Person>();

        people.Add(new Student("Ali", 20, "S123", "Computer Science"));
        people.Add(new Professor("Dr. Tanabi", 45, "P987", "Math"));

        foreach (var person in people)
        {
            Console.WriteLine(person.GetDetails());
        }
    }
}