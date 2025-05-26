using OOP_LibraryManagement.Model;
using OOP_LibraryManagement.Ultis;

namespace OOP_LibraryManagement.Service
{
    public class RecordService
    {
        private List<BorrowingRecord> RecordList;
        private BookService bookService;
        private DVDService dvdService;
        private MagazineService magazineService;

        public RecordService()
        {
            RecordList = new List<BorrowingRecord>();
            bookService = new BookService();
            dvdService = new DVDService();
            magazineService = new MagazineService();
        }

        public void Add(BorrowingRecord record)
        {
            try
            {
                RecordList.Add(record);
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format(GlobalUltis.ERROR_ADDING_ITEM, "Borrowing Record", ex.Message));
            }
        }

        public void Display()
        {
            try
            {
                foreach (var record in RecordList)
                {
                    {
                        record.DisplayInfo();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format(GlobalUltis.ERROR_DISPLAY_LIST, "Borrowing Record", ex.Message));
            }
        }

        public void BorrowItem(int itemId, string borrowerName)
        {
            LibraryItem item;
            try
            {
                if (string.IsNullOrEmpty(borrowerName))
                {
                    GlobalUltis.PrintError("Borrower name can not be empty");
                }
                Book book = bookService.getBookList().FirstOrDefault(b => b.Id == itemId);
                DVD dvd = dvdService.getDVDList().FirstOrDefault(d => d.Id == itemId);
                Magazine magazine = magazineService.GetMagazineList().FirstOrDefault(m => m.Id == itemId);
                if (book != null)
                {
                    item = book;
                }
                else if (dvd != null)
                {
                    item = dvd;
                }
                else if (magazine != null)
                {
                    GlobalUltis.PrintError("Magazine cannot be borrow");
                }
                else
                {
                    GlobalUltis.PrintError("Item not found");
                }

            }
            catch (Exception ex)
            {
                GlobalUltis.PrintError($"Error while borrowing items - {ex.Message}");
            }
        }
    }
}
