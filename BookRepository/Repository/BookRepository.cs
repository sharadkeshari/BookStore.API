using BookRepository.Data;
using BookRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRepository.Repository
{
    public class BookRepository:IBookRepository
    {
        private BookStoreContext _bookStoreContext;

        public BookRepository(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var records = await _bookStoreContext.Books.Select(m=>new BookModel { Description= m.Description, Title=m.Title, Id=m.Id }).ToListAsync();
            return records;
        }

        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            var record = await _bookStoreContext.Books.Where(m=>m.Id==bookId).Select(m => new BookModel { Description = m.Description, Title = m.Title, Id = m.Id }).FirstOrDefaultAsync();
            return record;
        }

        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            var book = new Books
            {
                Title = bookModel.Title,
                Description = bookModel.Description,
            };

            await _bookStoreContext.Books.AddAsync(book);
            await _bookStoreContext.SaveChangesAsync();
            return book.Id;
        }
    }
}
