// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;


Console.WriteLine("Hello, World!");

public class Book
{
    public string Title { get; set; }
    public bool IsAvailable { get; set; }

    public Book(string title)
    {
        Title = title;
        IsAvailable = true; // Book is available by default when added
    }
}

public class Library
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void BorrowBook(string title)
    {
        foreach (var book in books)
        {
            if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                if (book.IsAvailable)
                {
                    book.IsAvailable = false; // Change status to borrowed
                    return;
                }
                else
                {
                    Console.WriteLine($"The book '{title}' is already borrowed.");
                    return;
                }
            }
        }
        Console.WriteLine($"The book '{title}' was not found in the library.");
    }

    public void ReturnBook(string title)
    {
        foreach (var book in books)
        {
            if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                book.IsAvailable = true;
                return;
            }
        }
        Console.WriteLine($"The book '{title}' does not belong to this library.");
    }
}