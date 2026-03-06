using CityLibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibrarySystem.Helpers
{
    internal class DataSeeder
    {
        public static LibraryBranch Seed()
        {
            // ── Librarian ────────────────────────────────────────────
            Librarian manager = new Librarian(
                "LIB-01", "Sara Ahmed", "01012345678",
                salary: 8500m,
                hireDate: new DateTime(2019, 3, 15));

            // ── Branch ───────────────────────────────────────────────
            LibraryBranch branch = new LibraryBranch(
                "BR-001", "Downtown Branch", "12 Tahrir St, Cairo",
                "0222345678", "9:00 AM - 9:00 PM", manager);

            // ── Members ──────────────────────────────────────────────
            Member m1 = new Member(
                "MEM-001", "Ahmed Kamal",
                new DateTime(1998, 5, 10), "ahmed@email.com",
                "01098765432", new DateTime(2023, 1, 20));

            Member m2 = new Member(
                "MEM-002", "Nour Hassan",
                new DateTime(2001, 8, 22), "nour@email.com",
                "01155556677", new DateTime(2024, 3, 5));

            Member m3 = new Member("MEM-003", "Omar Samir", "01234567890");

            branch.RegisterMember(m1);
            branch.RegisterMember(m2);
            branch.RegisterMember(m3);

            // ── Books ────────────────────────────────────────────────
            Book b1 = new Book("978-0-13-468599-1", "Clean Code",
                               "Robert C. Martin", "Software Engineering", 2008);

            Book b2 = new Book("978-0-13-235088-4", "The Pragmatic Programmer",
                               "David Thomas", "Software Engineering", 1999);

            Book b3 = new Book("978-0-06-112008-4", "To Kill a Mockingbird");

            // ── Book Copies ──────────────────────────────────────────
            BookCopy c1 = new BookCopy("COPY-001", b1, "Good");
            BookCopy c2 = new BookCopy("COPY-002", b1, "Fair");
            BookCopy c3 = new BookCopy("COPY-003", b2, "Excellent");
            BookCopy c4 = new BookCopy("COPY-004", b3, "Good");

            branch.AddBookCopy(c1);
            branch.AddBookCopy(c2);
            branch.AddBookCopy(c3);
            branch.AddBookCopy(c4);

            Console.Clear();
            return branch;
        }

    }
}
