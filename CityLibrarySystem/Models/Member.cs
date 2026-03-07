

namespace CityLibrarySystem.Models
{
    /// <summary>
    /// Library member. MembershipId is assigned by LibraryBranch on registration.
    /// </summary>
    public class Member : LibraryUser
    {
        public string MembershipId { get; internal set; } = string.Empty;
        public DateOnly? DateOfBirth { get; private set; }
        public string? Email { get; private set; }
        public DateOnly MembershipDate { get; private set; }
        private readonly List<BorrowTransaction> _transactions = new();

        public IReadOnlyList<BorrowTransaction> Transactions => _transactions;

        internal Member(string membershipId, string name, DateOnly? dob,
                        string? email, string phone, DateOnly membershipDate)
            : base(name, phone)
        {
            MembershipId = membershipId;
            DateOfBirth = dob;
            Email = email;
            MembershipDate = membershipDate;
        }

        public void AddTransaction(BorrowTransaction t) => _transactions.Add(t);

        public override string ToDisplayString() =>
$@"  ID      : {MembershipId}
  Name    : {Name}
  Phone   : {Phone}
  Email   : {Email ?? "N/A"}
  Joined  : {MembershipDate:dd/MM/yyyy}
  Borrows : {Transactions.Count}";

        public string GetHistoryDisplayString()
        {
            if (Transactions.Count == 0)
                return "  No transactions found.";

            string result = "";
            for (int i = 0; i < Transactions.Count; i++)
            {
                if (i > 0)
                    result += Environment.NewLine;
                result += Transactions[i].ToDisplayString();
            }
            return result;
        }
    }
}
