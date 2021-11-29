using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Book
{
    public class BookDTO
    {
        /// <summary>
        /// Book's Id
        /// Will be generated after registration book
        /// </summary>
        public Guid Id { get; set; }
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
