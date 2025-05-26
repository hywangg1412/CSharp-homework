﻿namespace OOP_LibraryManagement.Service.Interface
{
    public interface IBorrowable
    {
        DateTime? BorrowDate { get; set; }
        DateTime? ReturnDate { get; set; }
        bool IsAvailable { get; set; }
        void Borrow() { }
        void Return() { }
    }
}
