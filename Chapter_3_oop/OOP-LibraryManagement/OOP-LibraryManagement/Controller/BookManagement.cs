using OOP_LibraryManagement.Service;
using OOP_LibraryManagement.Ultis;

namespace OOP_LibraryManagement.Controller
{
    public class BookMenu : Menu<String>
    {
        private static readonly string BookTitle = "BOOK MANAGEMENT";
        private static readonly IReadOnlyList<string> BookMenuOptions = new List<string>
        {
            "Add Book",
            "Search book by title",
            "Display all books",
            "Exit to main menu"
        };

        public BookService bookService;

        public BookMenu() : base(BookTitle, BookMenuOptions.ToArray())
        {
            bookService = new BookService();
        }

        public override void Execute(int selection)
        {
            switch (selection)
            {
                case 1:
                    bookService.AddBook();
                    break;

                case 2:
                    bookService.SearchBookByTilte();
                    break;

                case 3:
                    bookService.Display();
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
