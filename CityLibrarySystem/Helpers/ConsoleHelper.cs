using ConsoleTheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibrarySystem.Helpers
{
    static class ConsoleHelper
    {
        public static void ShowMenu()
        {
            ThemeHelper.PrintHeader("      CITY LIBRARY - MAIN MENU         ");
            ThemeHelper.PrintOption("1. Branch Information");
            ThemeHelper.PrintOption("2. Show All Users");
            ThemeHelper.PrintOption("3. Show Available Books");
            ThemeHelper.PrintOption("4. Show All Book Copies");
            ThemeHelper.PrintOption("5. Borrow a Book");
            ThemeHelper.PrintOption("6. Return a Book");
            ThemeHelper.PrintOption("7. Member Borrowing History");
            ThemeHelper.PrintOption("8. Register New Member");
            ThemeHelper.PrintOption("0. Exit");
            Console.WriteLine("========================================");
            Console.Write("  Choose: ");
        }
    }
}
