using CityLibrarySystem.Models;
using ConsoleTheme;

namespace CityLibrarySystem.Helpers
{
    internal class LibraryHelper
    {
        private LibraryBranch _branch;

        public LibraryHelper(LibraryBranch branch)
        {
            _branch = branch;
        }

        public void HandleBorrow()
        {

            Member member = _branch.FindMember(ThemeHelper.Prompt("Enter Member ID: "));
            _branch.ShowAvailableCopies();
            BookCopy copy = _branch.FindCopy(ThemeHelper.Prompt("Enter Copy ID to borrow: "));
            copy.Borrow(member);

        }

        public void HandleReturn()
        {
            BookCopy copy = _branch.FindCopy(ThemeHelper.Prompt("Enter Copy ID to return: "));
            copy.Return();

        }

        public void HandleHistory()
        {
            Member member = _branch.FindMember(ThemeHelper.Prompt("Enter Member ID: "));
            member.ShowHistory();
        }

        public void HandleRegisterMember()
        {
            string id = ThemeHelper.Prompt("Membership ID : ");
            string name = ThemeHelper.Prompt("Full Name     : ");
            string phone = ThemeHelper.Prompt("Phone Number  : ");
            _branch.RegisterMember(new Member(id, name, phone));
        }
    }
}
