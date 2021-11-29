using Application.DTOs.Book;
using Application.DTOs.Book.SearchContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.IBook.Queries
{
    public interface IGetBookService
    {
        Task<List<BookDTO>> GetBook(BookSearchContext searchContext);
    }
}
