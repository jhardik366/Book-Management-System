using BookManagement.Interface;
using BookManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookManagement.Repository
{
    public class BookRepository : IBook
    {
        private readonly DatabaseContext _dbContext;

        public BookRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddBook(Book book)
        {
            try
            {
                _dbContext.Book.Add(book);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Book DeleteBook(Guid id)
        {
            try
            {
                var book = _dbContext.Book.Find(id);

                if (book != null)
                {
                    _dbContext.Book.Remove(book);
                    _dbContext.SaveChanges();
                    return book;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public List<Book> GetBookDetails()
        {
            try
            {
                return _dbContext.Book.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Book GetBookDetails(Guid id)
        {
            try
            {
                var book = _dbContext.Book.Find(id);
                if (book != null)
                {
                    return book;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public bool IsBookExist(Guid id)
        {
            return _dbContext.Book.Any(e => e.BookId == id);
        }

        public void UpdateBook(Book book)
        {
            try
            {
                _dbContext.Entry(book).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
