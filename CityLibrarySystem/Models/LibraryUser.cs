using CityLibrarySystem.Contracts;

namespace CityLibrarySystem.Models
{
    // LibraryUser implements IDisplayable
    // Member and Librarian inherit the contract and must override DisplayInfo()
    abstract class LibraryUser : IDisplayable
    {
        public string Name { get; protected set; }
        public string Phone { get; protected set; }

        public LibraryUser(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }

        public abstract void DisplayInfo();
    }
}
