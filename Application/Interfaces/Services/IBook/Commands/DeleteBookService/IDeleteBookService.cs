using Application.DTOs.Book.DeleteDTO;
using Infrastructure.BusinessService.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.IBook.Commands.DeleteBookService
{
    public interface IDeleteBookService
    {
        Task<ResultDto> DeleteBook(RequestDeleteBookDTO book);

    }
}
