using Application.DTOs.Book.CreateDTO;
using Domain.Entities.BookEntity;
using Infrastructure.BusinessService.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.IBook.Commands.CreateBookService
{
    public interface ICreateBookService
    {
        Task<ResultDto<Book>> CreateBook(RequestCreateBookDTO book);
    }
}
