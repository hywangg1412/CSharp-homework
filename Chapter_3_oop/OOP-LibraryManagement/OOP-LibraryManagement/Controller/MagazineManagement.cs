using OOP_LibraryManagement.Service;
using OOP_LibraryManagement.Ultis;
using System.Collections.Generic;

namespace OOP_LibraryManagement.Controller
{
    public class MagazineManagement : Menu<string>
    {
        private static readonly string Title = "MAGAZINE MANAGEMENT";
        private static readonly IReadOnlyList<string> MenuOptions = new List<string> 
        { 
            "Add Magazine", 
            "Search magazine by title", 
            "Display all magazines", 
            "Exit to main menu" 
        };

        private readonly MagazineService magazineService;

        public MagazineManagement() : base(Title, MenuOptions.ToArray())
        {
            magazineService = new MagazineService();
        }

        public override void Execute(int selection)
        {
            switch (selection)
            {
                case 1:
                    magazineService.AddMagazine();
                    break;

                case 2:
                    magazineService.SearchMagazineByTilte();
                    break;

                case 3:
                    magazineService.Display();
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
