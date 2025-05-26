namespace OOP_LibraryManagement.Model
{
    public record BorrowingRecord
    {
        public int ItemId { get; set; }
        public string ItemTitle { get; set; }
        public string BorrowerName { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime DueDate { get; set; }
        public string LibraryLocation { get; init; }
        public bool IsReturned { get; private set; }
        public decimal LateFee { get; private set; }

        public BorrowingRecord(int itemId, string itemTitle, string borrowerName, DateTime borrowDate, DateTime dueDate, string libraryLocation)
        {
            ItemId = itemId;
            ItemTitle = itemTitle;
            BorrowerName = borrowerName;
            BorrowDate = borrowDate;
            DueDate = dueDate;
            ReturnDate = DateTime.MinValue;
            LibraryLocation = libraryLocation;
            IsReturned = false;
            LateFee = 0;
        }

        //public BorrowingRecord Return(DateTime returnDate)
        //{
        //    var record = this with
        //    {
        //        ReturnDate = returnDate,
        //        IsReturned = true
        //    };

        //    if (returnDate > DueDate)
        //    {
        //        var daysLate = (returnDate - DueDate).Days;
        //        record.LateFee = daysLate * 1.0m; // $1 per day late fee
        //    }

        //    return record;
        //}

        public void DisplayInfo()
        {
            Console.WriteLine($"Item ID: {ItemId}");
            Console.WriteLine($"Title: {ItemTitle}");
            Console.WriteLine($"Borrower: {BorrowerName}");
            Console.WriteLine($"Borrow Date: {BorrowDate:dd/MM/yyyy}");
            Console.WriteLine($"Due Date: {DueDate:dd/MM/yyyy}");
            Console.WriteLine($"Status: {(IsReturned ? "Returned" : "Borrowed")}");
            if (IsReturned)
            {
                Console.WriteLine($"Return Date: {ReturnDate:dd/MM/yyyy}");
                if (LateFee > 0)
                {
                    Console.WriteLine($"Late Fee: ${LateFee:F2}");
                }
            }
            Console.WriteLine($"Location: {LibraryLocation}");
            Console.WriteLine("------------------------");
        }
    }
}