using ConsoleTheme;
using System;
using System.Collections.Generic;

namespace CityLibrarySystem.Models
{
    class Member : LibraryUser
    {
        private string MembershipId;
        private DateTime DateOfBirth;
        private string Email;
        private DateTime MembershipDate;

        private List<BorrowTransaction> Transactions = new List<BorrowTransaction>();

        // Constructor 1 — full details
        public Member(string membershipId, string name, DateTime dob,
                      string email, string phone, DateTime membershipDate)
            : base(name, phone)
        {
            MembershipId = membershipId;
            DateOfBirth = dob;
            Email = email;
            MembershipDate = membershipDate;
        }

        // Constructor 2 — minimal (membership date defaults to today)
        public Member(string membershipId, string name, string phone)
            : base(name, phone)
        {
            MembershipId = membershipId;
            DateOfBirth = DateTime.MinValue;
            Email = "N/A";
            MembershipDate = DateTime.Today;
        }

        public string GetMembershipId() => MembershipId;

        public void AddTransaction(BorrowTransaction t) => Transactions.Add(t);

        public List<BorrowTransaction> GetTransactions() => Transactions;

        // Method Overriding
        public override void DisplayInfo()
        {
            ThemeHelper.PrintHeader(" MEMBER PROFILE ");

            Console.WriteLine($"  ID      : {MembershipId}");
            Console.WriteLine($"  Name    : {Name}");
            Console.WriteLine($"  Phone   : {Phone}");
            Console.WriteLine($"  Email   : {Email}");
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
