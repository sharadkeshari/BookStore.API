using AutoMapper;
using BookRepository.Data;
using BookRepository.Models;
using Microsoft.AspNetCore.JsonPatch;
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
        private readonly IMapper applicationMapper;

        public BookRepository(BookStoreContext bookStoreContext,IMapper applicationMapper)
        {
            _bookStoreContext = bookStoreContext;
            this.applicationMapper = applicationMapper;
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            //without auto mapper
            //var records = await _bookStoreContext.Books.Select(m=>new BookModel { Description= m.Description, Title=m.Title, Id=m.Id }).ToListAsync();

            //with auto mapper
            var records = await _bookStoreContext.Books.ToListAsync();

            return applicationMapper.Map<List<BookModel>>(records);
        }

        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            //without auto mapper
            //var record = await _bookStoreContext.Books.Where(m=>m.Id==bookId).Select(m => new BookModel { Description = m.Description, Title = m.Title, Id = m.Id }).FirstOrDefaultAsync();
            
            //with Auto mapper
            var record=await _bookStoreContext.Books.FirstOrDefaultAsync(m=>m.Id==bookId);
            return applicationMapper.Map<BookModel>(record);
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

        public async Task UpdateBookAsync(int bookId,BookModel bookModel)
        {
            var book = await _bookStoreContext.Books.FindAsync(bookId);
            if(book != null)
            {
                book.Title=bookModel.Title;
                book.Description=bookModel.Description;
                await _bookStoreContext.SaveChangesAsync();
            }
        }

        public async Task UpdateBookSingleDataBaseCallAsync(int bookId, BookModel bookModel)
        {
            var book = new Books
            {
                Id = bookId,
                Title = bookModel.Title,
                Description = bookModel.Description,
            };
            _bookStoreContext.Books.Update(book);
            
            await _bookStoreContext.SaveChangesAsync();
        }

        public async Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel)
        {
            var book = await _bookStoreContext.Books.FindAsync(bookId);
            if (book != null)
            {
                bookModel.ApplyTo(book);
                await _bookStoreContext.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(int bookId)
        {
            //if id is not primary key then below code is followed
            var book = await _bookStoreContext.Books.Where(b=>b.Id==bookId).FirstOrDefaultAsync();
            if (book != null)
            {
                _bookStoreContext.Books.Remove(book);
                await _bookStoreContext.SaveChangesAsync();
            }
        }

        public async Task DeleteBookWithIdAsync(int bookId)
        {
            var book=new Books { Id = bookId };
            _bookStoreContext.Books.Remove(book);
            await _bookStoreContext.SaveChangesAsync();
        }
    }
}
