using Application.DTOs.Book.DeleteDTO;
using Application.Exceptions;
using Application.Interfaces.Repositories.BookRepo;
using Application.Interfaces.Services.IBook.Commands.DeleteBookService;
using AutoMapper;
using Infrastructure.BusinessService.Dto;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService.Services.BookServices.Commands.DeleteBookService
{

    public class DeleteBookService : IDeleteBookService
    {
        private readonly IBookRepositoryAsync _bookRepository;
        private readonly IMapper _mapper;
        public DeleteBookService(IBookRepositoryAsync bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;

        }
        public Task<ResultDto> DeleteBook(RequestDeleteBookDTO book)
        {
            var row=_bookRepository.GetBookWithId(book.Id).Result;
            var result = new ResultDto();
            if (row == null)
            {
                result.IsSuccess = false;
                result.Message = "Book Not Found";
               

            }
            else
            {
                try
                {
                    _bookRepository.DeleteAsync(row);

                    result.IsSuccess = true;
                    result.Message = "Delete row successful";
                }
                catch 
                {
                   
                    result.IsSuccess = false;
                    result.Message = "Problem to delete, contact to administrator";
                    result.IsSuccess = false;
                }
            }

            return Task.FromResult(result);
            
        }
    }
}
