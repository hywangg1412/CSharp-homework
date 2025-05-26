namespace OOP_LibraryManagement.Model
{
    public abstract class LibraryItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublicationYear { get; set; }

        public LibraryItem() { }

        public LibraryItem(int id, string title, DateTime publicationYear)
        {
            this.Id = id;
            this.Title = title;
            this.PublicationYear = publicationYear;
        }

        public abstract void DisplayInfo();


        public virtual decimal CalculateLateReturnFee(int daysLate)
        {
            return daysLate * 0.50m;
        }
    }
}
