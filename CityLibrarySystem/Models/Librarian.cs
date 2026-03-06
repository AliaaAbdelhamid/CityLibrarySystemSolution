using ConsoleTheme;

namespace CityLibrarySystem.Models
{
    class Librarian : LibraryUser
    {
        public string LibrarianId { get; private set; }
        public decimal Salary { get; private set; }
        public DateTime HireDate { get; private set; }

        public Librarian(string librarianId, string name, string phone,
                         decimal salary, DateTime hireDate)
            : base(name, phone)
        {
            LibrarianId = librarianId;
            Salary = salary;
            HireDate = hireDate;
        }

        // Method Overriding — different display from Member
        public override void DisplayInfo()
        {
            ThemeHelper.PrintHeader("         LIBRARIAN PROFILE            ");
            Console.WriteLine($"  ID      : {LibrarianId}");
            Console.WriteLine($"  Name    : {Name}");
            Console.WriteLine($"  Phone   : {Phone}");
            Console.WriteLine($"  Salary  : {Salary:C}");
            Console.WriteLine($"  Hired   : {HireDate:dd/MM/yyyy}");
        }
    }
}
