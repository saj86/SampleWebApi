using Application.DTOs.BasicDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Book.UpdateDTO
{
    public class RequestUpdateBookDTO : BasicDTO<RequestUpdateBookDTO>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public byte[] CoverImage { get; set; }
        public decimal Price { get; set; }
    }
}
