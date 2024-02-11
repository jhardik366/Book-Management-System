using BookManagement.Models;
using System;
using System.Collections.Generic;

namespace BookManagement.Interface
{
    public interface IBook
    {
        public List<Book> GetBookDetails();
        public Book GetBookDetails(Guid id);
        public void AddBook(Book book);
        public void UpdateBook(Book book);
        public Book DeleteBook(Guid id);
        public bool IsBookExist(Guid id);
    }
}
