using Application.DTOs.Book;
using Application.Interfaces.Repositories.BookRepo;
using Application.Interfaces.Services.IBook.Queries;
using AutoMapper;
using Domain.Entities.BookEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Application.DTOs.Book.SearchContext;

namespace BusinessService.Services.BookServices.Queries
{
    public class GetBookService : IGetBookService
    {
        private readonly IBookRepositoryAsync _bookRepositoryAsync;
        private readonly IMapper _mapper;
        public GetBookService(IBookRepositoryAsync bookRepository, IMapper mapper)
        {
            _bookRepositoryAsync = bookRepository;
            _mapper=mapper;
        }

        public Task<List<BookDTO>> GetBook(BookSearchContext searchContext)
        {
            var result = _bookRepositoryAsync.GetBook(searchContext).Result.Select(a=>new BookDTO
            {
                Id=a.Id,
                Title = a.Title,
                Author = a.Author,
                CoverImage = a.CoverImage,
                Description = a.Description,
                Price = a.Price,
            }).ToList();
            return Task.FromResult(result);
        }
    }
}
