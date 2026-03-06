using CityLibrarySystem.Contracts;
using CityLibrarySystem.Models.Enums;
using ConsoleTheme;

namespace CityLibrarySystem.Models
{
    // BookCopy implements BOTH interfaces:
    // IBorrowable  — borrowing contract
    // IDisplayable — display contract
    class BookCopy : IBorrowable, IDisplayable
    {
        public string CopyId { get; private set; }
        public string Condition { get; private set; }
        public CopyStatus Status { get; private set; }
        public Book Book { get; private set; }
        public BorrowTransaction? ActiveTransaction { get; private set; }
        public BookCopy(string copyId, Book book, string condition = "Good")
        {
            CopyId = copyId;
            Book = book;
            Condition = condition;
            Status = CopyStatus.Available;
        }

        // IBorrowable — Borrow

        public void Borrow(Member member, int loanDays = 14)
        {
            if (!IsAvailable())
                throw new InvalidOperationException($"Copy {CopyId} is not available (Status: {Status}).");

            Status = CopyStatus.Borrowed;
            ActiveTransaction = new BorrowTransaction(member, this, loanDays);
            member.AddTransaction(ActiveTransaction);

            ThemeHelper.PrintSuccess($"Copy [{CopyId}] \"{Book.Title}\" borrowed by {member.Name}.");
            ThemeHelper.PrintSuccess($"Due date: {DateTime.Today.AddDays(loanDays):dd/MM/yyyy}");
        }

        // IBorrowable — Return
        public void Return()
        {
            if (ActiveTransaction == null)
                throw new InvalidOperationException("No Active Transactions");

            if (Status != CopyStatus.Borrowed)
                throw new InvalidOperationException($"Copy {CopyId} is not currently borrowed.");

            ActiveTransaction.MarkReturned(DateTime.Today);
            decimal fine = ActiveTransaction.CalculateFine();
            Status = CopyStatus.Available;

            ThemeHelper.PrintSuccess($"Copy [{CopyId}] : {Book.Title} returned.");

            if (fine > 0)
                ThemeHelper.PrintWarning($"Late return fine: {fine:F2} EGP");
            else
                ThemeHelper.PrintSuccess("Returned on time. No fine.");

            ActiveTransaction = null;
        }

        // IBorrowable — IsAvailable
        public bool IsAvailable() => Status == CopyStatus.Available;

        // IDisplayable
        public void DisplayInfo()
        {
            string avail = IsAvailable() ? "Available" : $"{Status}";
            Console.WriteLine($"  Copy [{CopyId}] — {Book.Title} | Condition: {Condition} | {avail}");
        }
    }
}
