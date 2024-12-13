// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

class LibrarySystem
{
    // Book class to represent a book
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
    }

    // List to store books in the library
    static List<Book> library = new List<Book>();
    static int nextId = 1;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Library System");
            Console.WriteLine("1. Add a Book");
            Console.WriteLine("2. View Books");
            Console.WriteLine("3. Update a Book");
            Console.WriteLine("4. Delete a Book");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    ViewBooks();
                    break;
                case "3":
                    UpdateBook();
                    break;
                case "4":
                    DeleteBook();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    // Add a new book
    static void AddBook()
    {
        Console.WriteLine("\nEnter the book details:");

        Book newBook = new Book();
        newBook.Id = nextId++;

        Console.Write("Title: ");
        newBook.Title = Console.ReadLine();

        Console.Write("Author: ");
        newBook.Author = Console.ReadLine();

        Console.Write("Year: ");
        newBook.Year = int.Parse(Console.ReadLine());

        library.Add(newBook);
        Console.WriteLine("Book added successfully.");
    }

    // View all books
    static void ViewBooks()
    {
        Console.WriteLine("\nBooks in Library:");

        if (library.Count == 0)
        {
            Console.WriteLine("No books available.");
            return;
        }

        foreach (var book in library)
        {
            Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Year: {book.Year}");
        }
    }

    // Update book details
    static void UpdateBook()
    {
        Console.Write("\nEnter the book ID to update: ");
        int id = int.Parse(Console.ReadLine());

        Book bookToUpdate = library.Find(b => b.Id == id);

        if (bookToUpdate == null)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        Console.WriteLine("Enter new details (leave empty to keep current value):");

        Console.Write($"Title ({bookToUpdate.Title}): ");
        string title = Console.ReadLine();
        if (!string.IsNullOrEmpty(title)) bookToUpdate.Title = title;

        Console.Write($"Author ({bookToUpdate.Author}): ");
        string author = Console.ReadLine();
        if (!string.IsNullOrEmpty(author)) bookToUpdate.Author = author;

        Console.Write($"Year ({bookToUpdate.Year}): ");
        string year = Console.ReadLine();
        if (!string.IsNullOrEmpty(year)) bookToUpdate.Year = int.Parse(year);

        Console.WriteLine("Book details updated successfully.");
    }

    // Delete a book
    static void DeleteBook()
    {
        Console.Write("\nEnter the book ID to delete: ");
        int id = int.Parse(Console.ReadLine());

        Book bookToDelete = library.Find(b => b.Id == id);

        if (bookToDelete == null)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        library.Remove(bookToDelete);
        Console.WriteLine("Book deleted successfully.");
    }
}

