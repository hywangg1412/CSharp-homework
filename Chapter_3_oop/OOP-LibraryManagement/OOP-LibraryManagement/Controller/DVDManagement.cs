using OOP_LibraryManagement.Service;
using OOP_LibraryManagement.Ultis;
using System.Collections.Generic;

namespace OOP_LibraryManagement.Controller
{
    public class DVDManagement : Menu<String>
    {
        private static readonly string Title = "DVD MANAGEMENT";
        private static readonly IReadOnlyList<string> MenuOptions = new List<string> 
        { 
            "Add DVD", 
            "Search DVD by title", 
            "Display all DVD", 
            "Exit to main menu" 
        };

        private readonly DVDService dvdService;

        public DVDManagement() : base(Title, MenuOptions.ToArray())
        {
            dvdService = new DVDService();
        }

        public override void Execute(int selection)
        {
            switch (selection)
            {
                case 1:
                    dvdService.AddDVD();
                    break;

                case 2:
                    dvdService.Display();
                    break;

                case 3:
                    dvdService.SearchDVDByTilte();
                    break;

                case 4:
                    ExitMenu();
                    break;
                default:
                    GlobalUltis.PrintError(GlobalUltis.ERROR_INVALID_INPUT);
                    break;
            }
        }
    }
}
