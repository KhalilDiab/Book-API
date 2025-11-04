
namespace Application.DTOs
{
    public class BookWithCategoryDto
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Categories { get; set; } = string.Empty;
        
        
    }
}
