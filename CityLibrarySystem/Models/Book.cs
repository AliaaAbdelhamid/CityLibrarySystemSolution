using CityLibrarySystem.Contracts;

namespace CityLibrarySystem.Models
{
    class Book : IDisplayable
    {
        private string ISBN;
        private string Title;
        private string AuthorName;
        private string Category;
        private int PublicationYear;

        // Constructor 1 — full details
        public Book(string isbn, string title, string authorName,
                    string category, int publicationYear)
        {
            ISBN = isbn;
            Title = title;
            AuthorName = authorName;
            Category = category;
            PublicationYear = publicationYear;
        }

        // Constructor 2 — minimal
        public Book(string isbn, string title)
        {
            ISBN = isbn;
            Title = title;
            AuthorName = "Unknown";
            Category = "General";
            PublicationYear = 0;
        }

        public string GetISBN() => ISBN;
        public string GetTitle() => Title;
        public string GetAuthor() => AuthorName;

        // IDisplayable
        public void DisplayInfo()
        {
            Console.WriteLine($"[{ISBN}] \"{Title}\" by {AuthorName} ({PublicationYear}) — {Category}");
        }
    }
}
