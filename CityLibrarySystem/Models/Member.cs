using ConsoleTheme;

namespace CityLibrarySystem.Models
{
    class Member : LibraryUser
    {
        private static int _counter = 1;
        public string MembershipId { get; private set; }
        public DateOnly? DateOfBirth { get; private set; }   // null = not provided
        public string? Email { get; private set; }   // null = not provided
        public DateOnly MembershipDate { get; private set; }
        private List<BorrowTransaction> _transactions = new();

        public IReadOnlyList<BorrowTransaction> Transactions => _transactions;
        // Constructor 1 — full details
        public Member(string name, DateOnly? dob,
                      string? email, string phone, DateOnly membershipDate)
            : base(name, phone)
        {
            MembershipId = $"MEM-{_counter:D3}";
            _counter++;
            DateOfBirth = dob;
            Email = email;
            MembershipDate = membershipDate;
        }

        // Constructor 2 — minimal (membership date defaults to today)
        public Member(string name, string phone)
            : this(name, null, null, phone, DateOnly.FromDateTime(DateTime.Today))
        {

        }

        public void AddTransaction(BorrowTransaction t) => _transactions.Add(t);

        // Method Overriding
        public override void DisplayInfo()
        {
            ThemeHelper.PrintSectionTitle("MEMBER PROFILE");
            Console.WriteLine($"  ID      : {MembershipId}");
            Console.WriteLine($"  Name    : {Name}");
            Console.WriteLine($"  Phone   : {Phone}");
            Console.WriteLine($"  Email   : {Email ?? "N/A"}");
            Console.WriteLine($"  Joined  : {MembershipDate:dd/MM/yyyy}");
            Console.WriteLine($"  Borrows : {Transactions.Count}");
        }

        public void ShowHistory()
        {
            ThemeHelper.PrintSectionTitle($" Borrowing History for {Name}:");
            if (Transactions.Count == 0)
            {
                ThemeHelper.PrintWarning("  No transactions found.");
                return;
            }
            foreach (var t in Transactions)
                t.DisplayTransaction();
        }
    }
}
