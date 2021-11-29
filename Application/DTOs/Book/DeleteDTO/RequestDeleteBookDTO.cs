using Application.DTOs.BasicDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Book.DeleteDTO
{
    public class RequestDeleteBookDTO : BasicDTO<RequestDeleteBookDTO>
    {
        /// <summary>
        /// Book's Id
        /// Removing book is possible with entering Id
        /// </summary>
        public Guid Id { get; set; }
    }
}
