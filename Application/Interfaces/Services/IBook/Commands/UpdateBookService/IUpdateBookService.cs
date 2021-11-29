using Application.DTOs.Book.UpdateDTO;
using Application.Wrappers;
using Infrastructure.BusinessService.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.IBook.Commands.UpdateBookService
{
    public interface IUpdateBookService
    {
        Task<ResultDto> UpdateBook(RequestUpdateBookDTO request);

    }
}
