using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string NameCategory { get; set; } = string.Empty;
        public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
    }
}
