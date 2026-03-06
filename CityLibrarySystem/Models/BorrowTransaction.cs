using ConsoleTheme;
namespace CityLibrarySystem.Models
{
    class BorrowTransaction
    {
        private static int _counter = 1000;

        public int TransactionId { get; private set; }
        public Member Member { get; private set; }
        public BookCopy BookCopy { get; private set; }
        public DateOnly BorrowDate { get; private set; }
        public DateOnly DueDate { get; private set; }
        public DateOnly? ReturnDate { get; private set; }

        private const decimal FinePerDay = 10m;

        public BorrowTransaction(Member member, BookCopy copy, int loanDays)
        {
            TransactionId = ++_counter;
            Member = member;
            BookCopy = copy;
            BorrowDate = DateOnly.FromDateTime(DateTime.Today);
            DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(loanDays));
            ReturnDate = null;
        }

        public bool IsReturned() => ReturnDate.HasValue;

        public void MarkReturned(DateOnly returnDate) => ReturnDate = returnDate;

        // Method Overload 1 — fine using today's date
        public decimal CalculateFine()
        {
            DateOnly effective = ReturnDate ?? DateOnly.FromDateTime(DateTime.Today);
            int overdueDays = effective.DayNumber - DueDate.DayNumber;
            return overdueDays > 0 ? overdueDays * FinePerDay : 0;
        }

        // Method Overload 2 — fine for a specific return date
        public decimal CalculateFine(DateOnly returnDate)
        {
            int overdueDays = returnDate.DayNumber - DueDate.DayNumber;
            return overdueDays > 0 ? overdueDays * FinePerDay : 0;
        }


        public void DisplayTransaction()
        {
            string status = ReturnDate.HasValue ? "Returned" : "Active";
            decimal fine = CalculateFine();
            string returnInfo = ReturnDate.HasValue ? ReturnDate.Value.ToString("dd/MM/yyyy") : "Not returned yet";

            Console.WriteLine($"── Transaction #{TransactionId} ──────────────");
            Console.WriteLine($"  Book      : {BookCopy.Book.Title}");
            Console.WriteLine($"  Copy ID   : {BookCopy.CopyId}");
            Console.WriteLine($"  Borrowed  : {BorrowDate:dd/MM/yyyy}");
            Console.WriteLine($"  Due       : {DueDate:dd/MM/yyyy}");
            Console.WriteLine($"  Returned  : {returnInfo}");
            Console.WriteLine($"  Status    : {status}");
            if (fine > 0)
                ThemeHelper.PrintWarning($"  Fine      : {fine:F2} EGP");
            else
                ThemeHelper.PrintSuccess("  Fine      : None");
        }
    }
}
