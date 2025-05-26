using OOP_LibraryManagement.Model;

namespace OOP_LibraryManagement.Service.Interface
{
    public interface IBorrowingService
    {
        void BorrowItem(int itemId, string borrowerName);
        void ReturnItem(int recordId);
        void DisplayAllRecords();
        void DisplayActiveBorrowings();
        void DisplayBorrowerHistory(string borrowerName);
        void DisplayOverdueItems();
    }
} 