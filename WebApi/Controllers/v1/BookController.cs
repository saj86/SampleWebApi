using Application.DTOs.Book;
using Application.DTOs.Book.CreateDTO;
using Application.DTOs.Book.DeleteDTO;
using Application.DTOs.Book.SearchContext;
using Application.DTOs.Book.UpdateDTO;
using Application.Interfaces.Services.IBook.Commands.CreateBookService;
using Application.Interfaces.Services.IBook.Commands.DeleteBookService;
using Application.Interfaces.Services.IBook.Commands.UpdateBookService;
using Application.Interfaces.Services.IBook.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    public class BookController : BaseApiController
    {
        private readonly IGetBookService _getBookService;
        private readonly ICreateBookService _createBookService;
        private readonly IDeleteBookService _deleteBookService;
        private readonly IUpdateBookService _updateBookService;
        public BookController(IGetBookService getBasicDataService,
            ICreateBookService createBookService,
            IDeleteBookService deleteBookService,
            IUpdateBookService updateBookService)
        {
            _getBookService = getBasicDataService;
            _createBookService = createBookService;
            _deleteBookService = deleteBookService;
            _updateBookService = updateBookService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet]
        //[EnableCors("MyPolicy")]
        public async Task<List<BookDTO>> Get(BookSearchContext search)
        {
            return await _getBookService.GetBook(search);
        }
        [HttpPost("Insert")]
        public async Task<IActionResult> Post(RequestCreateBookDTO req)
        {

            var res = await _createBookService.CreateBook(req);
            //Check Satus result
            if (res.IsSuccess)
                return Ok(res.Data);
            else
                return BadRequest(res.Message);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put(RequestUpdateBookDTO req)
        {
           
            if (req.Id==Guid.Empty)
            {
                return BadRequest();
            }
            var result = await _updateBookService.UpdateBook(req);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            else
            {
                return NotFound(result.Message);
            }
        }
        /// <summary>
        /// Removing Book
        /// </summary>
        /// <param name="deleteDto"></param>
        /// <returns></returns>
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(RequestDeleteBookDTO deleteDto)
        {
            var result = await _deleteBookService.DeleteBook(deleteDto);
            if (result.IsSuccess)
                return Ok(result.Message);
            else
                return NotFound(result.Message);
        }
    }
}
