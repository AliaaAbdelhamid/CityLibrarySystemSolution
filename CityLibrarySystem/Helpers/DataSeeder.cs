using CityLibrarySystem.Models;

namespace CityLibrarySystem.Helpers
{
    internal static class DataSeeder
    {
        public static LibraryBranch Seed()
        {
            // ── Librarian ────────────────────────────────────────────
            Librarian manager = new(
                "LIB-01", "Sara Ahmed", "01012345678",
                salary: 8500m,
                hireDate: new DateOnly(2019, 3, 15));

            // ── Branch ───────────────────────────────────────────────
            LibraryBranch branch = new(
                "BR-001", "Downtown Branch", "12 Tahrir St, Cairo",
                "0222345678", "9:00 AM - 9:00 PM", manager);

            // ── Members ──────────────────────────────────────────────
            Member m1 = new(
                "MEM-001", "Ahmed Kamal",
                new DateOnly(1998, 5, 10), "ahmed@email.com",
                "01098765432", new DateOnly(2023, 1, 20));

            Member m2 = new(
                "MEM-002", "Nour Hassan",
                new DateOnly(2001, 8, 22), "nour@email.com",
                "01155556677", new DateOnly(2024, 3, 5));

            Member m3 = new("MEM-003", "Omar Samir", "01234567890");

            branch.RegisterMember(m1);
            branch.RegisterMember(m2);
            branch.RegisterMember(m3);

            // ── Books ────────────────────────────────────────────────
            Book b1 = new("978-0-13-468599-1", "Clean Code",
                               "Robert C. Martin", "Software Engineering", 2008);

            Book b2 = new("978-0-13-235088-4", "The Pragmatic Programmer",
                               "David Thomas", "Software Engineering", 1999);

            Book b3 = new("978-0-06-112008-4", "To Kill a Mockingbird");

            // ── Book Copies ──────────────────────────────────────────
            BookCopy c1 = new("COPY-001", b1, "Good");
            BookCopy c2 = new("COPY-002", b1, "Fair");
            BookCopy c3 = new("COPY-003", b2, "Excellent");
            BookCopy c4 = new("COPY-004", b3, "Good");

            branch.AddBookCopy(c1);
            branch.AddBookCopy(c2);
            branch.AddBookCopy(c3);
            branch.AddBookCopy(c4);

            Console.Clear();
            return branch;
        }

    }
}
