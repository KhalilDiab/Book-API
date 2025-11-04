using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    namespace Application.DTOs
    {
        public class BookCategoryDto
        {
            public int BookId { get; set; }
            public int CategoryId { get; set; }

            public string? BookTitle { get; set; }
            public string? CategoryName { get; set; }
        }
    }

}
