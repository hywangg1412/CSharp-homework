namespace OOP_LibraryManagement.Model
{
    public class Magazine : LibraryItem
    {
        public int IssueNumber { get; set; }
        public string Publisher { get; set; }

        public Magazine() { }

        public Magazine(int id, string title, DateTime publicationYear, int issueNumber, string publisher) : base(id, title, publicationYear)
        {
            this.IssueNumber = issueNumber;
            this.Publisher = publisher;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"{Id} - {Title} - {PublicationYear} - {IssueNumber} - {Publisher}");
        }
    }
}
