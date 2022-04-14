﻿using BookRepository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookRepository.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();
    }
}