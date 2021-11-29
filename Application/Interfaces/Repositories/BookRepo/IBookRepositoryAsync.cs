using Application.DTOs.Book.SearchContext;
using Domain.Entities.BookEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.BookRepo
{
    public interface IBookRepositoryAsync : IGenericRepositoryAsync<Book>
    {
        Task<IQueryable<Book>> GetBook(BookSearchContext searchContext);
        Task<Book> GetBookWithId(Guid id);

    }
}
