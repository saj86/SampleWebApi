using Application.DTOs.Book.UpdateDTO;
using Application.Interfaces.Repositories.BookRepo;
using Application.Interfaces.Services.IBook.Commands.UpdateBookService;
using AutoMapper;
using Domain.Entities.BookEntity;
using Infrastructure.BusinessService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService.Services.BookServices.Commands.UpdateBookService
{
    public class UpdateBookService : IUpdateBookService
    {
        private readonly IBookRepositoryAsync _bookRepository;
        private readonly IMapper _mapper;
        public UpdateBookService(IBookRepositoryAsync bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;

        }
        public Task<ResultDto> UpdateBook(RequestUpdateBookDTO request)
        {
            var row = _bookRepository.GetBookWithId(request.Id).Result;
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
                    var newRow = _mapper.Map<Book>(request);
                    _bookRepository.UpdateAsync(newRow);
                    result.IsSuccess = true;
                    result.Message = "Update row successful";
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
