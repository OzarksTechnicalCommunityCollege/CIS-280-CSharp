namespace LibraryApp;

public class Program
{
    public static void Main(string[] args)
    {
        var catalog = new Catalog();

        catalog.AddBook(new Book("The Pragmatic Programmer", "David Thomas", "9780135957059", 3));
        catalog.AddBook(new Book("Clean Code", "Robert C. Martin", "9780132350884", 2));
        catalog.AddBook(new Book("The DevOps Handbook", "Gene Kim", "9781942788003", 1));

        bool running = true;
        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("=== Library Menu ===");
            Console.WriteLine("1. List all books");
            Console.WriteLine("2. Search by title");
            Console.WriteLine("3. Add a new book");
            Console.WriteLine("4. Check out a book (by ISBN)");
            Console.WriteLine("5. Return a book (by ISBN)");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    foreach (var book in catalog.Books)
                        Console.WriteLine($"{book.Title} by {book.Author} ({book.Isbn}) \u2014 {book.AvailableCopies}/{book.TotalCopies} available");
                    break;

                case "2":
                    Console.Write("Enter a title to search for: ");
                    var titleQuery = Console.ReadLine() ?? "";
                    var results = catalog.SearchByTitle(titleQuery);
                    if (results.Count == 0)
                        Console.WriteLine("No matches found.");
                    else
                        foreach (var book in results)
                            Console.WriteLine($"Found: {book.Title} by {catalog.Books[0].Author}");
                    break;

                case "3":
                    Console.Write("Title: ");
                    var newTitle = Console.ReadLine() ?? "";
                    Console.Write("Author: ");
                    var newAuthor = Console.ReadLine() ?? "";
                    Console.Write("ISBN: ");
                    var newIsbn = Console.ReadLine() ?? "";
                    Console.Write("Total copies: ");
                    var copies = int.Parse(Console.ReadLine() ?? "0");
                    catalog.AddBook(new Book(newTitle, newAuthor, newIsbn, copies));
                    Console.WriteLine("Book added.");
                    break;

                case "4":
                    Console.Write("ISBN to check out: ");
                    var checkoutIsbn = Console.ReadLine() ?? "";
                    catalog.CheckOutBook(checkoutIsbn);
                    Console.WriteLine("Checked out successfully.");
                    break;

                case "5":
                    Console.Write("ISBN to return: ");
                    var returnIsbn = Console.ReadLine() ?? "";
                    catalog.ReturnBook(returnIsbn);
                    Console.WriteLine("Returned successfully.");
                    break;

                case "6":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Not a valid option, try again.");
                    break;
            }
        }
    }
}
