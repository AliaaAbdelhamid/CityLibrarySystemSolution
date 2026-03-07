namespace CityLibrarySystem.Models
{
    /// <summary>
    /// Represents a borrow transaction. Transaction IDs are process-wide (static counter).
    /// </summary>
    public class BorrowTransaction
    {
        private static int _counter = 1000;
        private const decimal FinePerDay = 10m;
        private const string DateFormat = "dd/MM/yyyy";

        public int TransactionId { get; private set; }
        public Member Member { get; private set; }
        public BookCopy BookCopy { get; private set; }
        public DateOnly BorrowDate { get; private set; }
        public DateOnly DueDate { get; private set; }
        public DateOnly? ReturnDate { get; private set; }

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

        public decimal CalculateFine()
        {
            DateOnly effective = ReturnDate ?? DateOnly.FromDateTime(DateTime.Today);
            int overdueDays = effective.DayNumber - DueDate.DayNumber;
            return overdueDays > 0 ? overdueDays * FinePerDay : 0;
        }

        public decimal CalculateFine(DateOnly returnDate)
        {
            int overdueDays = returnDate.DayNumber - DueDate.DayNumber;
            return overdueDays > 0 ? overdueDays * FinePerDay : 0;
        }

        /// <summary>Formats transaction for display. Does not write to console.</summary>
        public string ToDisplayString()
        {
            string status = ReturnDate.HasValue ? "Returned" : "Active";
            decimal fine = CalculateFine();
            string returnInfo = ReturnDate.HasValue ? ReturnDate.Value.ToString(DateFormat) : "Not returned yet";
            string fineLine = fine > 0 ? $"{fine:F2} EGP" : "None";

            return
$@"── Transaction #{TransactionId} ──────────────
  Book      : {BookCopy.Book.Title}
  Copy ID   : {BookCopy.CopyId}
  Borrowed  : {BorrowDate.ToString(DateFormat)}
  Due       : {DueDate.ToString(DateFormat)}
  Returned  : {returnInfo}
  Status    : {status}
  Fine      : {fineLine}";
        }
    }
}
