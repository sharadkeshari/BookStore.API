using AutoMapper;
using BookRepository.Data;
using BookRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRepository.Helper
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BookModel>().ReverseMap();
        }
    }
}
