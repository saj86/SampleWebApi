using Application.DTOs.BasicDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Book.CreateDTO
{
    public class RequestCreateBookDTO : BasicDTO<RequestCreateBookDTO>
    {
        /// <summary>
        /// Title of book
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        ///Brief summary of the book
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Authors book
        ///Separate multiple authors with ","
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Cover page of book
        /// </summary>
        public byte[] CoverImage { get; set; }
        /// <summary>
        /// Price of book
        /// </summary>
        public decimal Price { get; set; }
    }
}
