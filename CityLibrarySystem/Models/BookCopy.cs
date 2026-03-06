using CityLibrarySystem.Models;
using CityLibrarySystem.Models.Enums;
using CityLibrarySystem.Contracts;
using System;
using ConsoleTheme;

namespace CityLibrarySystem.Models
{
    // BookCopy implements BOTH interfaces:
    // IBorrowable  — borrowing contract
    // IDisplayable — display contract
    class BookCopy : IBorrowable, IDisplayable
    {
        private string CopyId;
        private string Condition;
        private CopyStatus Status;
        private Book Book;
        private BorrowTransaction? ActiveTransaction;

        public BookCopy(string copyId, Book book, string condition = "Good")
        {
            CopyId = copyId;
            Book = book;
            Condition = condition;
            Status = CopyStatus.Available;
        }

        public string GetCopyId() => CopyId;
        public string GetBookTitle() => Book.GetTitle();
        public CopyStatus GetStatus() => Status;

        // IBorrowable — Borrow
        public void Borrow(Member member, int loanDays = 14)
        {
            if (!IsAvailable())
                throw new InvalidOperationException($"Copy {CopyId} is not available (Status: {Status}).");

            Status = CopyStatus.Borrowed;
            ActiveTransaction = new BorrowTransaction(member, this, loanDays);
            member.AddTransaction(ActiveTransaction);

            ThemeHelper.PrintSuccess($"Copy [{CopyId}] \"{Book.GetTitle()}\" borrowed by {member.GetName()}.");
            ThemeHelper.PrintSuccess($"Due date: {DateTime.Today.AddDays(loanDays):dd/MM/yyyy}");
        }

        // IBorrowable — Return
        public void Return()
        {
            if (ActiveTransaction == null)
                throw new InvalidOperationException("No Active Transactions");

            if (Status != CopyStatus.Borrowed)
                throw new InvalidOperationException(
                    $"Copy {CopyId} is not currently borrowed.");

            ActiveTransaction.MarkReturned(DateTime.Today);

            decimal fine = ActiveTransaction.CalculateFine();
            Status = CopyStatus.Available;

            ThemeHelper.PrintSuccess($"Copy [{CopyId}] : {Book.GetTitle()} returned.");

            if (fine > 0)
                ThemeHelper.PrintWarning($"Late return fine: {fine:C} EGP");
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
            Console.WriteLine($"  Copy [{CopyId}] — {Book.GetTitle()} | Condition: {Condition} | {avail}");
        }
    }
}
