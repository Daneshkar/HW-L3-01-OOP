using System;
using System.Collections.Generic;
using System.Text;

namespace HW_L3_01_OOP.Task1
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; }

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsAvailable = true;
        }

    }
}
