using System;
using System.Collections.Generic;
using System.Text;

namespace HW_L3_01_OOP.Task2
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual string GetDetails()
        {
            return $"Name: {Name}, Age: {Age}";
        }

    }

    public class Student : Person {
        public string StudentID { get; set; }
        public string Major { get; set; }

        public override string GetDetails()
        {
            return $"Name: {Name}, Age: {Age}, StudentID: {StudentID}, Major: {Major}";
        }
    }
    public class Professor : Person
    {
        public string StudentID { get; set; }
        public string Major { get; set; }
        public string ProfessorID { get; internal set; }
        public string Subject { get; internal set; }

        public override string GetDetails()
        {
            return $"Name: {Name}, Age: {Age}, StudentID: {StudentID}, Major: {Major}";
        }

    }
}
