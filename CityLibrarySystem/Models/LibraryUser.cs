using CityLibrarySystem.Contracts;

namespace CityLibrarySystem.Models
{
    // LibraryUser implements IDisplayable
    // Member and Librarian inherit the contract and must override DisplayInfo()
    abstract class LibraryUser : IDisplayable
    {
        protected string Name;
        protected string Phone;

        public LibraryUser(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }

        public string GetName() => Name;

        public abstract void DisplayInfo();
    }
}
