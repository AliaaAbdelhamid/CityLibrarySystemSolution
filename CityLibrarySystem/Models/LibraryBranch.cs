using CityLibrarySystem.Contracts;
using ConsoleTheme;

namespace CityLibrarySystem.Models
{
    class LibraryBranch : IDisplayable
    {
        public string BranchId { get; private set; }
        public string BranchName { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public string OpeningHours { get; private set; }
        public Librarian Manager { get; private set; }

        private List<BookCopy> _copies = new();
        private List<Member> _members = new();
        private List<LibraryUser> _users = new();

        public IReadOnlyList<BookCopy> Copies => _copies;
        public IReadOnlyList<Member> Members => _members;
        public IReadOnlyList<LibraryUser> Users => _users;

        public LibraryBranch(string branchId, string name, string address,
                             string phone, string openingHours, Librarian manager)
        {
            BranchId = branchId;
            BranchName = name;
            Address = address;
            Phone = phone;
            OpeningHours = openingHours;
            Manager = manager;
            _users.Add(manager);
        }

        // ── Members ──────────────────────────────────────────────

        public void RegisterMember(Member member)
        {
            _members.Add(member);
            _users.Add(member);
            ThemeHelper.PrintSuccess($"Member : {member.Name} - [{member.MembershipId}] registered.");
        }

        public Member FindMember(string membershipId)
        {
            foreach (Member member in Members)
            {
                if (member.MembershipId == membershipId)
                    return member;
            }
            throw new InvalidOperationException("Member Not Found");
        }

        // ── Book Copies ───────────────────────────────────────────

        public void AddBookCopy(BookCopy copy)
        {
            _copies.Add(copy);
            ThemeHelper.PrintSuccess($"Copy [{copy.CopyId}] - {copy.Book.Title} : added to branch.");
        }

        public BookCopy FindCopy(string copyId)
        {
            foreach (BookCopy bookCopy in Copies)
            {
                if (bookCopy.CopyId == copyId)
                    return bookCopy;
            }
            throw new InvalidOperationException("Book Copy Not Found");
        }

        public void ShowAvailableCopies()
        {
            ThemeHelper.PrintHeader(" Available Book Copies:");
            bool any = false;
            foreach (BookCopy c in Copies)
            {
                if (c.IsAvailable())
                {
                    c.DisplayInfo();
                    any = true;
                }
            }
            if (!any) ThemeHelper.PrintWarning("  No copies currently available.");
        }

        public void ShowAllCopies()
        {
            ThemeHelper.PrintHeader(" All Book Copies:");
            if (Copies.Count == 0) { ThemeHelper.PrintWarning("  No copies in branch."); return; }
            foreach (BookCopy c in Copies)
                c.DisplayInfo();
        }

        public void ShowAllUsers()
        {
            ThemeHelper.PrintHeader(" All Registered Users:");
            foreach (LibraryUser user in Users)
                user.DisplayInfo();
        }


        public void DisplayInfo()
        {
            ThemeHelper.PrintHeader("LIBRARY BRANCH INFO ");
            Console.WriteLine($"  ID      : {BranchId}");
            Console.WriteLine($"  Name    : {BranchName}");
            Console.WriteLine($"  Address : {Address}");
            Console.WriteLine($"  Phone   : {Phone}");
            Console.WriteLine($"  Hours   : {OpeningHours}");
            Console.WriteLine($"  Manager : {Manager.Name}");
            Console.WriteLine($"  Members : {Members.Count}");
            Console.WriteLine($"  Copies  : {Copies.Count}");
        }
    }
}
