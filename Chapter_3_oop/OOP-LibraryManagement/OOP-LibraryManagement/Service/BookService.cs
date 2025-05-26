using OOP_LibraryManagement.Model;
using OOP_LibraryManagement.Service.Interface;
using OOP_LibraryManagement.Ultis;

namespace OOP_LibraryManagement.Service
{
    public class BookService : IBookService
    {
        private List<Book> BookList;
        private readonly string ErrorMsg;

        public BookService()
        {
            BookList = new List<Book>();
            ErrorMsg = "-> Invalid Input, Try Again";
        }

        public void Add(Book entity)
        {
            try
            {
                BookList.Add(entity);
            }
            catch (Exception ex)
            {
                GlobalUltis.PrintError(string.Format(GlobalUltis.ERROR_ADDING_ITEM, "book", ex.Message));
            }
        }

        public List<Book> getBookList()
        {
            return BookList;
        }

        public void Display()
        {
            try
            {
                if (BookList != null && BookList.Count > 0)
                {
                    Console.WriteLine("Book List");
                    foreach (var entity in BookList)
                    {
                        entity.DisplayInfo();
                    }
                }
                else
                {
                    GlobalUltis.PrintError(GlobalUltis.ERROR_EMPTY_LIST);
                }
            }
            catch (Exception ex)
            {
                GlobalUltis.PrintError(string.Format(GlobalUltis.ERROR_DISPLAY_LIST, "book", ex.Message));
            }
        }

        public Book SearchByTitle(string tilte)
        {
            foreach (Book entity in BookList)
            {
                if (entity.Title == tilte)
                {
                    return entity;
                }
            }
            return null;
        }

        public bool CheckIfIdExist(int id)
        {
            return BookList.Any(book => book.Id == id);
        }

        public void AddBook()
        {
            do
            {
                try
                {
                    int id;
                    do
                    {
                        id = GlobalUltis.GetInt("Book Id", ErrorMsg);
                        if (CheckIfIdExist(id) == true)
                        {
                            GlobalUltis.PrintError("ID already exist.Please enter a different one");
                        }
                    } while (CheckIfIdExist(id));
                    string tilte = GlobalUltis.GetString("Book Title", ErrorMsg);
                    DateTime publicationYear = ObjectUltis.ValidPulicationYear("Publication Year", "Invalid Date Format");
                    string author = GlobalUltis.GetString("Book Author", ErrorMsg);
                    int pages = GlobalUltis.GetInt("Total Pages", ErrorMsg);
                    string genre = GlobalUltis.GetString("Book Genre", ErrorMsg);
                    BookList.Add(new Book(id, tilte, publicationYear, author, pages, genre));

                    GlobalUltis.PrintSuccessMessage("Book add to list successfully");
                }
                catch (Exception ex)
                {
                    GlobalUltis.PrintError(string.Format(GlobalUltis.ERROR_ADDING_ITEM, "Magazine", ex.Message));
                }

            } while (GlobalUltis.GetString("-> Do you want to continue adding book (Y/N)", ErrorMsg).Equals("Y"));
        }

        public void SearchBookByTilte()
        {
            string tilte = GlobalUltis.GetString("Enter book tilte you want to search", ErrorMsg);
            Book found = SearchByTitle(tilte);
            if (found != null)
            {
                GlobalUltis.PrintSuccessMessage("Book Found");
                found.DisplayInfo();
            }
            else
            {
                GlobalUltis.PrintError("Book not found");
            }
        }
    }
}
