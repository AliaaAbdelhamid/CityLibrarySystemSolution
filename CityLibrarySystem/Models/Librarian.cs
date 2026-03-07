namespace CityLibrarySystem.Models
{
    public class Librarian : LibraryUser
    {
        public string LibrarianId { get; private set; }
        public decimal Salary { get; private set; }
        public DateOnly HireDate { get; private set; }

        public Librarian(string librarianId, string name, string phone,
                         decimal salary, DateOnly hireDate)
            : base(name, phone)
        {
            LibrarianId = librarianId;
            Salary = salary;
            HireDate = hireDate;
        }

        // Method Overriding — different display from Member
        public override string ToDisplayString() => $"""
                                                     ID      : {LibrarianId}
                                                     Name    : {Name}
                                                     Phone   : {Phone}
                                                     Salary  : {Salary:C}
                                                     Hired   : {HireDate:dd/MM/yyyy}
                                                     """;
    }
}
