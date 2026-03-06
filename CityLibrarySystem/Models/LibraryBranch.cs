using CityLibrarySystem.Models;
using CityLibrarySystem.Contracts;
using System;
using System.Collections.Generic;
using ConsoleTheme;

namespace CityLibrarySystem.Models
{
    class LibraryBranch : IDisplayable
    {
        private string BranchId;
        private string BranchName;
        private string Address;
        private string Phone;
        private string OpeningHours;
        private Librarian Manager;

        private List<BookCopy> Copies = new List<BookCopy>();
        private List<Member> Members = new List<Member>();
        private List<LibraryUser> Users = new List<LibraryUser>(); 

        public LibraryBranch(string branchId, string name, string address,
                             string phone, string openingHours, Librarian manager)
        {
            BranchId = branchId;
            BranchName = name;
            Address = address;
            Phone = phone;
            OpeningHours = openingHours;
            Manager = manager;
            Users.Add(manager);
        }

        // ── Members ──────────────────────────────────────────────

        public void RegisterMember(Member member)
        {
            Members.Add(member);
            Users.Add(member);
            ThemeHelper.PrintSuccess($"Member : {member.GetName()} - [{member.GetMembershipId()}] registered.");
        }

        public Member FindMember(string membershipId)
        {
            foreach (Member member in Members)
            {
                if(member.GetMembershipId() == membershipId)
                    return member;
            }
            throw new InvalidOperationException("Member Not Found");
        }

        // ── Book Copies ───────────────────────────────────────────

        public void AddBookCopy(BookCopy copy)
        {
            Copies.Add(copy);
            ThemeHelper.PrintSuccess($"Copy [{copy.GetCopyId()}] - {copy.GetBookTitle()} : added to branch.");
        }

        public BookCopy FindCopy(string copyId)
        {
            foreach (BookCopy bookCopy in Copies)
            {
                if (bookCopy.GetCopyId() == copyId)
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
            Console.WriteLine($"  Manager : {Manager.GetName()}");
            Console.WriteLine($"  Members : {Members.Count}");
            Console.WriteLine($"  Copies  : {Copies.Count}");
        }
    }
}
