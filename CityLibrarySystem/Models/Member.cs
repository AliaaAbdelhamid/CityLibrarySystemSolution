using System.Text;

namespace CityLibrarySystem.Models
{
    public class Member : LibraryUser
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
        public override string ToDisplayString() => $"""
                                                      ID      : {MembershipId}
                                                      Name    : {Name}
                                                      Phone   : {Phone}
                                                      Email   : {Email ?? "N/A"}
                                                      Joined  : {MembershipDate:dd/MM/yyyy}
                                                      Borrows : {Transactions.Count}
                                                    """;

        public string GetHistoryDisplayString()
        {
            if (Transactions.Count == 0)
                return "  No transactions found.";

            var sb = new StringBuilder();
            for (int i = 0; i < Transactions.Count; i++)
            {
                if (i > 0)
                    sb.AppendLine();
                sb.Append(Transactions[i].ToDisplayString());
            }
            return sb.ToString();
        }
    }
}

