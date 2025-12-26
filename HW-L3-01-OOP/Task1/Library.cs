using System;
using System.Collections.Generic;
using System.Text;

namespace HW_L3_01_OOP.Task1
{
    internal class Library

    {
        private List<Book> books = new List<Book>();


        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Added: {book.Title}");

        }

        // امانت گرفتن کتاب
        public void BorrowBook(string title)
        {
            Book foundBook = null;

            foreach (var book in books)
            {
                if (book.Title == title)
                {
                    foundBook = book;
                    break;
                }
            }

            if (foundBook == null)
            {
                Console.WriteLine("The requested book does not exist in the library.");
                return;
            }

            if (!foundBook.IsAvailable)
            {
                Console.WriteLine("The book is currently borrowed and not available.");
                return;
            }

            foundBook.IsAvailable = false;
            Console.WriteLine($"You have successfully borrowed \"{title}\".");
        }


        // بازگرداندن کتاب
        public void ReturnBook(string title)
        {
            Book foundBook = null;

            foreach (var book in books)
            {
                if (book.Title == title)
                {
                    foundBook = book;
                    break;
                }
            }

            if (foundBook == null)
            {
                Console.WriteLine("The specified book is not registered in the library.");
                return;
            }

            foundBook.IsAvailable = true;
            Console.WriteLine($"The book \"{title}\" has been returned successfully.");
        }
    }

}