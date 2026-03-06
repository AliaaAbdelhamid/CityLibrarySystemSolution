using CityLibrarySystem.Helpers;
using CityLibrarySystem.Models;

namespace CityLibrarySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryBranch branch = DataSeeder.Seed();
            LibraryHelper libHelper = new(branch);

            bool running = true;
            while (running)
            {
                try
                {
                    ConsoleHelper.ShowMenu();
                    string? choice = Console.ReadLine()?.Trim();
                    Console.WriteLine();

                    switch (choice)
                    {
                        case "1": branch.DisplayInfo(); break;
                        case "2": branch.ShowAllUsers(); break;
                        case "3": branch.ShowAvailableCopies(); break;
                        case "4": branch.ShowAllCopies(); break;
                        case "5": libHelper.HandleBorrow(); break;
                        case "6": libHelper.HandleReturn(); break;
                        case "7": libHelper.HandleHistory(); break;
                        case "8": libHelper.HandleRegisterMember(); break;
                        case "0":
                            Console.WriteLine("  Goodbye!");
                            running = false;
                            break;
                        default:
                            Console.WriteLine("  Invalid option. Try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }


                Console.WriteLine("\n  Press any key to continue...");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
    }
}
