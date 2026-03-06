using CityLibrarySystem.Models;
using ConsoleTheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            if (copy == null) { ThemeHelper.PrintWarning("  Copy not found."); return; }

            try 
            { 
                copy.Borrow(member); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void HandleReturn()
        {
            BookCopy? copy = _branch.FindCopy(ThemeHelper.Prompt("Enter Copy ID to return: "));
            if (copy == null) { ThemeHelper.PrintWarning("  Copy not found."); return; }

            try 
            { 
                copy.Return(); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void HandleHistory()
        {
            Member member = _branch.FindMember(ThemeHelper.Prompt("Enter Member ID: "));

            member.ShowHistory();
        }

        public void HandleRegisterMember()
        {
            string id =    ThemeHelper.Prompt("Membership ID : ");
            string name =  ThemeHelper.Prompt("Full Name     : ");
            string phone = ThemeHelper.Prompt("Phone Number  : ");
            _branch.RegisterMember(new Member(id, name, phone));
        }
    }
}
