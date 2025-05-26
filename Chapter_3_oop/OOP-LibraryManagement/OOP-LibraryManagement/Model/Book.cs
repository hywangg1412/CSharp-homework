using OOP_LibraryManagement.Service.Interface;
using OOP_LibraryManagement.Ultis;

namespace OOP_LibraryManagement.Model
{
    public class Book : LibraryItem, IBorrowable
    {
        private DateTime? borrowDate;
        private DateTime? returnDate;
        private bool isAvailable = true;

        public string Author { get; set; }

        public int Pages { get; set; }

        public string Genres { get; set; }

        public Book() { }

        public Book(int id, string title, DateTime publicationYear, string author, int pages, string genres) : base(id, title, publicationYear)
        {
            Author = author;
            Pages = pages;
            Genres = genres;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"{Id} - {Title} - {PublicationYear} - {Author} - {Pages} - {Genres}");
        }

        public override decimal CalculateLateReturnFee(int daysLate)
        {
            return daysLate * 0.75m;
        }

        public DateTime? BorrowDate { get => borrowDate; set => borrowDate = value; }
        public DateTime? ReturnDate { get => returnDate; set => returnDate = value; }
        public bool IsAvailable { get => isAvailable; set => isAvailable = value; }

        public void Borrow()
        {
            if (IsAvailable)
            {
                BorrowDate = DateTime.Now;
                IsAvailable = false;
                ReturnDate = null;
            }
            else
            {
                GlobalUltis.PrintError("Book is not available for borrowing.");
            }
        }

        public void Return()
        {
            if (!IsAvailable)
            {
                ReturnDate = DateTime.Now;
                IsAvailable = true;
            }
            else
            {
                GlobalUltis.PrintError("Book already available in the library.");
            }
        }
    }
}
