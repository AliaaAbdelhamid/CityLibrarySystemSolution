using System;
using ConsoleTheme;
namespace CityLibrarySystem.Models
{
    class BorrowTransaction
    {
        private static int Counter = 1000;   // auto-increment ID

        private int TransactionId;
        private Member Member;
        private BookCopy BookCopy;
        private DateTime BorrowDate;
        private DateTime DueDate;
        private DateTime? ReturnDate;        // null until returned

        private const decimal FinePerDay = 10m;   // 10 EGP per day

        public BorrowTransaction(Member member, BookCopy copy, int loanDays)
        {
            TransactionId = ++Counter;
            Member = member;
            BookCopy = copy;
            BorrowDate = DateTime.Today;
            DueDate = DateTime.Today.AddDays(loanDays);
            ReturnDate = null;
        }

        public bool IsReturned() => ReturnDate.HasValue;

        public void MarkReturned(DateTime returnDate) => ReturnDate = returnDate;

        // Method Overload 1 — fine using today's date
        public decimal CalculateFine()
        {
            DateTime effective = ReturnDate ?? DateTime.Today;
            int overdueDays = (effective - DueDate).Days;
            return overdueDays > 0 ? overdueDays * FinePerDay : 0;
        }

        // Method Overload 2 — fine for a specific return date
        public decimal CalculateFine(DateTime returnDate)
        {
            int overdueDays = (returnDate - DueDate).Days;
            return overdueDays > 0 ? overdueDays * FinePerDay : 0;
        }

        public int GetTransactionId() => TransactionId;

        public void DisplayTransaction()
        {
            string status = ReturnDate.HasValue ? "Returned" : "Active";
            decimal fine = CalculateFine();
            string returnInfo = ReturnDate.HasValue ? ReturnDate.Value.ToString("dd/MM/yyyy") : "Not returned yet";

            Console.WriteLine($"── Transaction #{TransactionId} ──────────────");
            Console.WriteLine($"  Book      : {BookCopy.GetBookTitle()}");
            Console.WriteLine($"  Copy ID   : {BookCopy.GetCopyId()}");
            Console.WriteLine($"  Borrowed  : {BorrowDate:dd/MM/yyyy}");
            Console.WriteLine($"  Due       : {DueDate:dd/MM/yyyy}");
            Console.WriteLine($"  Returned  : {returnInfo}");
            Console.WriteLine($"  Status    : {status}");
            if (fine > 0)
                ThemeHelper.PrintWarning($" Fine   : {fine:C}");
            else
                ThemeHelper.PrintSuccess("  Fine      : None");
        }
    }
}
