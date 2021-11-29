using Application.DTOs.Book.SearchContext;
using Application.Interfaces.Repositories.BookRepo;
using Domain.Entities.BookEntity;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class BookRepositoryAsync : GenericRepositoryAsync<Book>, IBookRepositoryAsync
    {
        private readonly DbSet<Book> _book;
        public BookRepositoryAsync(DataBaseContext dbcontext) : base(dbcontext)
        {
            _book = dbcontext.Set<Book>();
        }
        /// <summary>
        /// Get list of books 
        /// if you need the book you can search with title,author and description 
        /// </summary>
        /// <param name="searchContext"></param>
        /// <returns></returns>
        public Task<IQueryable<Book>> GetBook(BookSearchContext searchContext)
        {
            var list = _book.Where(a =>
                (string.IsNullOrEmpty(searchContext.Title)||a.Title.Contains(searchContext.Title))
            && (string.IsNullOrEmpty(searchContext.Description) || a.Title.Contains(searchContext.Description))
            && (string.IsNullOrEmpty(searchContext.Author) || a.Title.Contains(searchContext.Author))
            );

            return Task.Run(()=> { return list; });

        }

        public Task<Book> GetBookWithId(Guid id)
        {
            var row = _book.FirstOrDefault(a => a.Id == id);
            return Task.FromResult(row);
        }
    }
}
