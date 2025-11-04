using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    namespace Application.DTOs
    {
        public class BookWithCategoriesDto
        {
            public int BookId { get; set; }
            public string Title { get; set; } = string.Empty;
            public string Author { get; set; } = string.Empty;
            public List<CategoryDto> Categories { get; set; } = new();
        }
    }

}
