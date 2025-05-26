using System;
using System.Collections.Generic;
using System.Linq;
using OOP_LibraryManagement.Model;
using OOP_LibraryManagement.Ultis;

namespace OOP_LibraryManagement.Services
{
    public class RecordService
    {
        private List<Borrowing> _borrowings;
        private int _nextId;

        public RecordService()
        {
            _borrowings = new List<Borrowing>();
            _nextId = 1;
        }

        public bool BorrowItem(string itemId, string itemType, string borrowerName, string borrowerId, int daysToBorrow)
        {
            try
            {
                // Check if item is already borrowed
                if (_borrowings.Any(b => b.ItemId == itemId && b.Status == "Borrowed"))
                {
                    GlobalUltis.PrintError("This item is already borrowed!");
                    return false;
                }

                // Check if borrower has too many active borrowings (e.g., max 5 items)
                int activeBorrowings = _borrowings.Count(b => 
                    b.BorrowerId == borrowerId && 
                    b.Status == "Borrowed");

                if (activeBorrowings >= 5)
                {
                    GlobalUltis.PrintError("Borrower has reached the maximum limit of active borrowings!");
                    return false;
                }

                // Create new borrowing record
                var borrowing = new Borrowing
                {
                    Id = _nextId++,
                    ItemId = itemId,
                    ItemType = itemType,
                    BorrowerName = borrowerName,
                    BorrowerId = borrowerId,
                    BorrowDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(daysToBorrow),
                    Status = "Borrowed"
                };

                _borrowings.Add(borrowing);
                return true;
            }
            catch (Exception ex)
            {
                GlobalUltis.PrintError($"Error while borrowing item: {ex.Message}");
                return false;
            }
        }

        public bool ReturnItem(int borrowingId)
        {
            try
            {
                var borrowing = _borrowings.FirstOrDefault(b => b.Id == borrowingId && b.Status == "Borrowed");
                
                if (borrowing == null)
                {
                    GlobalUltis.PrintError("Borrowing record not found or item already returned!");
                    return false;
                }

                borrowing.Status = "Returned";
                borrowing.ReturnDate = DateTime.Now;
                return true;
            }
            catch (Exception ex)
            {
                GlobalUltis.PrintError($"Error while returning item: {ex.Message}");
                return false;
            }
        }

        public List<Borrowing> GetCurrentBorrowings()
        {
            return _borrowings.Where(b => b.Status == "Borrowed").ToList();
        }

        public List<Borrowing> GetBorrowingHistory()
        {
            return _borrowings.ToList();
        }

        public List<Borrowing> SearchBorrowings(string searchTerm)
        {
            searchTerm = searchTerm.ToLower();
            return _borrowings.Where(b => 
                b.BorrowerName.ToLower().Contains(searchTerm) || 
                b.BorrowerId.ToLower().Contains(searchTerm) ||
                b.ItemId.ToLower().Contains(searchTerm)).ToList();
        }

        public bool IsItemAvailable(string itemId)
        {
            return !_borrowings.Any(b => b.ItemId == itemId && b.Status == "Borrowed");
        }

        public int GetBorrowerActiveCount(string borrowerId)
        {
            return _borrowings.Count(b => b.BorrowerId == borrowerId && b.Status == "Borrowed");
        }
    }
} 