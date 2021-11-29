using Application.DTOs.Book.CreateDTO;
using Application.Interfaces.Repositories.BookRepo;
using Application.Interfaces.Services.IBook.Commands.CreateBookService;
using AutoMapper;
using Domain.Entities.BookEntity;
using Infrastructure.BusinessService.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService.Services.BookServices.Commands.CreateBookService
{
    public class CreateBookService : ICreateBookService
    {
        private readonly IBookRepositoryAsync _bookRepository;
        private readonly IMapper _mapper;
        public CreateBookService(IBookRepositoryAsync bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<ResultDto<Book>> CreateBook(RequestCreateBookDTO book)
        {
            var model = _mapper.Map<Book>(book);
            model.Id=Guid.NewGuid();
            var resultdto = new ResultDto<Book>();

            try
            {
                var enitity = await _bookRepository.AddAsync(model);
                resultdto.IsSuccess = true;
                resultdto.Data = enitity;
            }
            catch (Exception ex) {
             
                resultdto.IsSuccess = false;
                resultdto.Message=ex.Message;
            }
            var result = await Task.FromResult( resultdto);
            return result;
        }
    }
}
