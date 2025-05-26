using OOP_LibraryManagement.Service.Interface;
using OOP_LibraryManagement.Ultis;

namespace OOP_LibraryManagement.Model
{
    public class DVD : LibraryItem, IBorrowable
    {
        private DateTime? borrowDate;
        private DateTime? returnDate;
        private bool isAvailable = true;

        public string Director { get; set; }
        public int Runtime { get; set; }
        public int AgeRating { get; set; }

        public DVD() { }

        public DVD(int id, string title, DateTime publicationYear, string director, int runTime, int ageRating) : base(id, title, publicationYear)
        {
            this.Director = director;
            this.Runtime = runTime;
            this.AgeRating = ageRating;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"{Id} - {Title} - {PublicationYear} - {Director} - {Runtime} - {AgeRating}");
        }

        public override decimal CalculateLateReturnFee(int daysLate)
        {
            return daysLate * 1.00m;
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
                GlobalUltis.PrintError("DVD is not available for borrowing.");
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
                GlobalUltis.PrintError("DVD already available in the library.");
            }
        }
    }

}
