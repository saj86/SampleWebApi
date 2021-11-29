using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Book.SearchContext
{
    public class BookSearchContext
    {
        /// <summary>
        /// Seach based on book's title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Search based on summary
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Search base on author
        /// </summary>
        public string Author { get; set; }

    }
}
