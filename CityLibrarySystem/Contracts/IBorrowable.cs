using CityLibrarySystem.Models;

namespace CityLibrarySystem.Contracts
{
    interface IBorrowable
    {
        void Borrow(Member member, int loanDays = 14);
        void Return();
        bool IsAvailable();
    }
}
