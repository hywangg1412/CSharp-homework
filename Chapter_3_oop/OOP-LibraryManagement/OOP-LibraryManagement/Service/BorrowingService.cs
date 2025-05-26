using OOP_LibraryManagement.Model;
using OOP_LibraryManagement.Service.Interface;
using OOP_LibraryManagement.Ultis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_LibraryManagement.Service
{
    public class BorrowingService : IBorrowingService
    {
        private readonly List<BorrowingRecord> borrowingRecords;
        private readonly Library library;
        private int nextRecordId;

        public BorrowingService(Library library)
        {
            this.library = library;
            borrowingRecords = new List<BorrowingRecord>();
            nextRecordId = 1;
        }

        public void BorrowItem(int itemId, string borrowerName)
        {
            try
            {
                // Validate input
                if (string.IsNullOrEmpty(borrowerName))
                {
                    GlobalUltis.PrintError("Borrower name cannot be empty");
                    return;
                }

                // Find item
                var item = library.itemsList.FirstOrDefault(i => i.Id == itemId);
                if (item == null)
                {
                    GlobalUltis.PrintError("Item not found");
                    return;
                }

                // Check if item is borrowable
                if (item is not IBorrowable borrowableItem)
                {
                    GlobalUltis.PrintError("This item cannot be borrowed");
                    return;
                }

                // Check if item is available
                if (!borrowableItem.IsAvailable)
                {
                    GlobalUltis.PrintError("Item is not available for borrowing");
                    return;
                }

                // Check if borrower has overdue items
                if (HasOverdueItems(borrowerName))
                {
                    GlobalUltis.PrintError("Cannot borrow: You have overdue items");
                    return;
                }

                // Create borrowing record
                var record = new BorrowingRecord(
                    itemId: item.Id,
                    itemTitle: item.Title,
                    borrowerName: borrowerName,
                    borrowDate: DateTime.Now,
                    dueDate: DateTime.Now.AddDays(14),
                    libraryLocation: "Main Library"
                );

                // Add to records
                borrowingRecords.Add(record);

                // Update item status
                borrowableItem.Borrow();

                GlobalUltis.PrintSuccessMessage($"Item borrowed successfully. Due date: {record.DueDate:dd/MM/yyyy}");
            }
            catch (Exception ex)
            {
                GlobalUltis.PrintError($"Error while borrowing item: {ex.Message}");
            }
        }

        public void ReturnItem(int recordId)
        {
            try
            {
                // Find record
                var record = borrowingRecords.FirstOrDefault(r => r.ItemId == recordId);
                if (record == null)
                {
                    GlobalUltis.PrintError("Borrowing record not found");
                    return;
                }

                // Find item
                var item = library.itemsList.FirstOrDefault(i => i.Id == record.ItemId);
                if (item == null)
                {
                    GlobalUltis.PrintError("Item not found");
                    return;
                }

                // Update record
                var returnedRecord = record.Return(DateTime.Now);
                var index = borrowingRecords.IndexOf(record);
                borrowingRecords[index] = returnedRecord;

                // Update item status
                if (item is IBorrowable borrowableItem)
                {
                    borrowableItem.Return();
                }

                GlobalUltis.PrintSuccessMessage("Item returned successfully");
                if (returnedRecord.LateFee > 0)
                {
                    GlobalUltis.PrintError($"Late fee: ${returnedRecord.LateFee:F2}");
                }
            }
            catch (Exception ex)
            {
                GlobalUltis.PrintError($"Error while returning item: {ex.Message}");
            }
        }

        public void DisplayAllRecords()
        {
            try
            {
                if (!borrowingRecords.Any())
                {
                    GlobalUltis.PrintError("No borrowing records found");
                    return;
                }

                Console.WriteLine("\nAll Borrowing Records:");
                foreach (var record in borrowingRecords)
                {
                    record.DisplayInfo();
                }
            }
            catch (Exception ex)
            {
                GlobalUltis.PrintError($"Error while displaying records: {ex.Message}");
            }
        }

        public void DisplayActiveBorrowings()
        {
            try
            {
                var activeBorrowings = borrowingRecords.Where(r => !r.IsReturned);
                if (!activeBorrowings.Any())
                {
                    GlobalUltis.PrintError("No active borrowings found");
                    return;
                }

                Console.WriteLine("\nActive Borrowings:");
                foreach (var record in activeBorrowings)
                {
                    record.DisplayInfo();
                }
            }
            catch (Exception ex)
            {
                GlobalUltis.PrintError($"Error while displaying active borrowings: {ex.Message}");
            }
        }

        public void DisplayBorrowerHistory(string borrowerName)
        {
            try
            {
                var borrowerRecords = borrowingRecords.Where(r => r.BorrowerName == borrowerName);
                if (!borrowerRecords.Any())
                {
                    GlobalUltis.PrintError($"No borrowing history found for {borrowerName}");
                    return;
                }

                Console.WriteLine($"\nBorrowing History for {borrowerName}:");
                foreach (var record in borrowerRecords)
                {
                    record.DisplayInfo();
                }
            }
            catch (Exception ex)
            {
                GlobalUltis.PrintError($"Error while displaying borrower history: {ex.Message}");
            }
        }

        public void DisplayOverdueItems()
        {
            try
            {
                var overdueItems = borrowingRecords
                    .Where(r => !r.IsReturned && DateTime.Now > r.DueDate)
                    .ToList();

                if (!overdueItems.Any())
                {
                    GlobalUltis.PrintSuccessMessage("No overdue items found");
                    return;
                }

                Console.WriteLine("\nOverdue Items:");
                foreach (var record in overdueItems)
                {
                    record.DisplayInfo();
                    var daysOverdue = (DateTime.Now - record.DueDate).Days;
                    Console.WriteLine($"Days overdue: {daysOverdue}");
                    Console.WriteLine("------------------------");
                }
            }
            catch (Exception ex)
            {
                GlobalUltis.PrintError($"Error while displaying overdue items: {ex.Message}");
            }
        }

        private bool HasOverdueItems(string borrowerName)
        {
            return borrowingRecords
                .Any(r => r.BorrowerName == borrowerName && 
                         !r.IsReturned && 
                         DateTime.Now > r.DueDate);
        }
    }
} 