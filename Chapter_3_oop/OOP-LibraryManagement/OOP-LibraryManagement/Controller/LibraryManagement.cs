using OOP_LibraryManagement.Ultis;

namespace OOP_LibraryManagement.Controller
{
    public class LibraryManagement : Menu<string>
    {
        private static readonly string Title = "LIBRARY MANAGEMENT SYSTEM";
        private static readonly IReadOnlyList<string> MainMenuOptions = new List<string>
        {
            "Book Management",
            "DVD Management",
            "Magazine Management",
            "Exit to main menu"
        };

        public LibraryManagement() : base(Title, MainMenuOptions.ToArray())
        {
        }

        public override void Execute(int selection)
        {
            switch (selection)
            {
                case 1:
                    RunBookMenu();
                    break;
                case 2:
                    RunDVDMenu();
                    break;
                case 3:
                    RunMagazineMenu();
                    break;
                case 4:
                    ExitMenu();
                    break;
                default:
                    GlobalUltis.PrintError(GlobalUltis.ERROR_INVALID_INPUT);
                    break;
            }
        }

        private void RunBookMenu()
        {
            BookMenu bookMenu = new BookMenu();
            bookMenu.Run();
        }

        private void RunDVDMenu()
        {
            DVDManagement dvdMenu = new DVDManagement();
            dvdMenu.Run();
        }

        private void RunMagazineMenu()
        {
            MagazineManagement magazineMenu = new MagazineManagement();
            magazineMenu.Run();
        }

        public static void Main(string[] args)
        {
            LibraryManagement libraryManagement = new LibraryManagement();
            libraryManagement.Run();
        }
    }
}

